using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using PublicHelpClass;
using Model;
using Excel2SqlSchema.Helper;
using Microsoft.Data.ConnectionUI;
using System.IO;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace Excel2SqlSchema
{
    public partial class Form1 : Form
    {
        List<Table> tables;
        string DBName;
        private bool DropIfExists
        {
            get
            {
                return rbDropIfExists.Checked;
            }
        }

        public Form1()
        {
            InitializeComponent();
            Init();

            //Table table1 = new Table();
            //table1.Name = "TableTest1";
            //table1.Description = "描述";
            //table1.Columns.Add(new Column()
            //{
            //    Name = "id",
            //    Type = "int",
            //    IsCanNull = false,
            //    IsIdentity = true,
            //    IsPrimaryKey = true,
            //    Description = "ID"
            //});
            //table1.Columns.Add(new Column()
            //{
            //    Name = "sex",
            //    Type = "varchar(45)",
            //    DefaultValue = "m",
            //    Description = "性别",
            //    IsCanNull = false,
            //    IsIdentity = false,
            //    IsPrimaryKey = false
            //});


            //string a = MySqlHelper.GenerateCreateSql(table1);

            //TreeNode topNode = new TreeNode("所有表");
            //topNode.ExpandAll();
            //foreach (Table table in new List<Table>() { table1})
            //{
            //    TreeNode children = new TreeNode(table.Name);
            //    children.Name = table.Name;
            //    topNode.Nodes.Add(children);
            //}
            //tvTree.Nodes.Add(topNode);
        }

        private void Init()
        {
            //HighlightingManager.Manager.AddHighlightingStrategy(
            //HighlightingManager.Manager.FindHighlighterForFile("Resources\\SyntaxModes.xml"));
            //IHighlightingStrategy highter = HighlightingStrategyFactory.CreateHighlightingStrategyForFile("");
            //HighlightingManager.Manager.AddSyntaxModeFileProvider(new AppSyntaxModeProvider());
            //teSql.SetHighlighting("SQL");
            //teSql.Refresh();
        }

        /// <summary>
        /// 打开Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            // 打开文件
            openExcelDialog.ShowDialog();
            if (openExcelDialog.FileName != "")
            {
                string fileName = openExcelDialog.FileName;

                lblFilePath.Text = fileName;
                DBName = Path.GetFileNameWithoutExtension(fileName);
                ReadExcel(fileName);
            }
        }

        /// <summary>
        /// 读取Excel
        /// </summary>
        /// <param name="fileName"></param>
        private void ReadExcel(string fileName)
        {
            Excel.ApplicationClass xlApp = new ApplicationClass();
            if (xlApp == null)
            {
                return;
            }
            //xlApp.Visible = true; // 调试时打开

            // 工作簿
            Workbook book = xlApp.Workbooks.Open(openExcelDialog.FileName);

            // 读取所有Sheet至Tables
            tables = new List<Table>();
            foreach (Worksheet sheet in book.Worksheets)
            {
                Range SchemaRange;
                bool isSchema = VarifySheet(sheet, out SchemaRange);
                if (isSchema)
                {
                    Table table = ReadSheet(sheet, SchemaRange);
                    tables.Add(table);
                }
            }

            // 关闭Excel
            book.Close();

            // 处理Tables
            LoadTableTree(tables);
        }

        /// <summary>
        /// 加载Tables
        /// </summary>
        /// <param name="tables"></param>
        private void LoadTableTree(List<Table> tables)
        {
            // 加载表列表树
            TreeNode topNode = new TreeNode("所有表");
            foreach (Table table in tables)
            {
                TreeNode children = new TreeNode(table.Name);
                children.Name = table.Name;
                topNode.Nodes.Add(children);
            }
            topNode.ExpandAll();

            tvTree.Nodes.Clear();
            tvTree.Nodes.Add(topNode);

            // 加载CreateSql
            LoadCreateSql(tables);
        }

        /// <summary>
        /// 加载CreateSql
        /// </summary>
        /// <param name="tables"></param>
        private void LoadCreateSql(List<Table> tables)
        {
            string createSql = GenerateCreateSql(tables);
            tbSql.Text = createSql;
        }

        private string GenerateCreateSql(List<Table> tables)
        {
            StringBuilder sbSql = new StringBuilder();

            // 注释
            sbSql.AppendLine("--");
            sbSql.AppendLine("-- Generate from " + DBName);
            sbSql.AppendLine("--");
            sbSql.AppendLine();

            // Sql
            foreach (Table table in tables)
            {
                // 表注释
                sbSql.AppendLine("--");
                sbSql.AppendLine("-- Table " + table.Name);
                sbSql.AppendLine("--");
                sbSql.AppendLine(MySqlHelper.GenerateCreateSql(table, DropIfExists, !DropIfExists));
                sbSql.AppendLine();
            }

            return sbSql.ToString();
        }

        private Table ReadSheet(Worksheet sheet, Range SchemaRange)
        {
            Table table = new Table();
            table.Name = ((Range)(sheet.Cells[1, 2])).Value2.ToString();
            table.Description = ((Range)(sheet.Cells[2, 2])).Value2.ToString();

            for (int rowIndex = sheet.UsedRange.Row + 4; rowIndex <= sheet.UsedRange.Row + sheet.UsedRange.Rows.Count - 1; rowIndex++)
            {
                Column column = new Column();
                column.Name = GetValue(sheet, rowIndex, 1);
                column.Type = GetValue(sheet, rowIndex, 2);
                //column.Length = GetValue(sheet, rowIndex, 3);
                //column.Decimals = GetValue(sheet, rowIndex, 4);
                column.IsCanNull = GetValue(sheet, rowIndex, 3) == "Y";
                column.IsPrimaryKey = GetValue(sheet, rowIndex, 4) == "Y";
                column.DefaultValue = GetValue(sheet, rowIndex, 5);
                column.IsIdentity = GetValue(sheet, rowIndex, 6) == "Y";
                column.Description = GetValue(sheet, rowIndex, 7);

                table.Columns.Add(column);
            }
            string errmsg = "";
            textBox1.Text = JsonHelperClass.ObjectToJson<Table>(table, ref errmsg);

            return table;
        }

        private bool VarifySheet(Worksheet sheet, out Range SchemaRange)
        {
            SchemaRange = sheet.get_Range(sheet.Cells[5, 7], sheet.Cells[6, 7]);

            if (sheet.UsedRange.Rows.Count < 5 || sheet.UsedRange.Columns.Count < 7)
            {
                return false;
            }
            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取Sheet内的值
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public string GetValue(Worksheet sheet, int rowIndex, int columnIndex)
        {
            if (rowIndex < sheet.UsedRange.Row || rowIndex > sheet.UsedRange.Row + sheet.UsedRange.Rows.Count - 1
                || columnIndex < sheet.UsedRange.Column || columnIndex > sheet.UsedRange.Column + sheet.UsedRange.Columns.Count - 1)
            {
                return "";
            }
            else
            {
                object obj = ((Range)sheet.Cells[rowIndex, columnIndex]).Value2;
                if (obj == null)
                {
                    return "";
                }
                else
                {
                    return obj.ToString();
                }
            }
        }

        /// <summary>
        /// 数据库连接配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnConfig_Click(object sender, EventArgs e)
        {
            DataConnectionDialog dlg = new DataConnectionDialog();

            DataSource.AddStandardDataSources(dlg);

            //dlg.DataSources.Add(DataSource.SqlDataSource);
            //dlg.DataSources.Add(DataSource.AccessDataSource);
            //dlg.DataSources.Add(DataSource.OdbcDataSource);
            //dlg.DataSources.Add(DataSource.OracleDataSource);
            //dlg.DataSources.Add(DataSource.SqlFileDataSource);


            DataSource mysqlDS = new DataSource("MySql", "MySql");
            //DataProvider mysqlDP = new DataProvider("mysql provider", "mysql p", "m");
            DataProvider mysqlDB = new DataProvider("m", "m", "m", "m", typeof(MySql.Data.MySqlClient.MySqlConnection));
            mysqlDS.Providers.Add(mysqlDB);

            dlg.DataSources.Add(mysqlDS);


            //dlg.SelectedDataSource = Microsoft.Data.ConnectionUI.DataSource.SqlDataSource;
            //dlg.SelectedDataProvider = Microsoft.Data.ConnectionUI.DataProvider.SqlDataProvider;

            //赋值一个已存在的连接字符串给界面控件  
            //dlg.ConnectionString = this.ConnectString;  


            DataConnectionDialog.Show(dlg);

            if (dlg.ConnectionString != "")
            {
                textBox1.AppendText(dlg.ConnectionString);
            }
        }

        private void btnOpenEditor_Click(object sender, EventArgs e)
        {
            new TextEditorSample.TextEditorForm().ShowDialog();
        }

        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string tableName = tvTree.SelectedNode.Name;
            if (tableName == "")
            {
                LoadCreateSql(tables);
            }
            else
            {
                foreach (Table table in tables)
                {
                    if (table.Name == tableName)
                    {
                        LoadCreateSql(new List<Table>() { table });
                    }
                }
            }
        }
    }
}
