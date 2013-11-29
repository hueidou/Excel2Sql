namespace Excel2SqlSchema
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenExcel = new System.Windows.Forms.Button();
            this.openExcelDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnConnConfig = new System.Windows.Forms.Button();
            this.tbNameSpace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportSql = new System.Windows.Forms.Button();
            this.btnExportModelClasses = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tvTree = new System.Windows.Forms.TreeView();
            this.rbDropIfExists = new System.Windows.Forms.RadioButton();
            this.rbIfNotExists = new System.Windows.Forms.RadioButton();
            this.btnOpenEditor = new System.Windows.Forms.Button();
            this.tbSql = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOpenExcel
            // 
            this.btnOpenExcel.Location = new System.Drawing.Point(12, 42);
            this.btnOpenExcel.Name = "btnOpenExcel";
            this.btnOpenExcel.Size = new System.Drawing.Size(75, 23);
            this.btnOpenExcel.TabIndex = 0;
            this.btnOpenExcel.Text = "打开Excel";
            this.btnOpenExcel.UseVisualStyleBackColor = true;
            this.btnOpenExcel.Click += new System.EventHandler(this.btnOpenExcel_Click);
            // 
            // openExcelDialog
            // 
            this.openExcelDialog.Filter = "表格文件|*.xls;*.xlsx";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(116, 43);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(0, 12);
            this.lblFilePath.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(575, 119);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(366, 418);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnConnConfig
            // 
            this.btnConnConfig.Location = new System.Drawing.Point(609, 38);
            this.btnConnConfig.Name = "btnConnConfig";
            this.btnConnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConnConfig.TabIndex = 3;
            this.btnConnConfig.Text = "数据库连接";
            this.btnConnConfig.UseVisualStyleBackColor = true;
            this.btnConnConfig.Click += new System.EventHandler(this.btnConnConfig_Click);
            // 
            // tbNameSpace
            // 
            this.tbNameSpace.Location = new System.Drawing.Point(575, 78);
            this.tbNameSpace.Name = "tbNameSpace";
            this.tbNameSpace.Size = new System.Drawing.Size(118, 21);
            this.tbNameSpace.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "命名空间：";
            // 
            // btnExportSql
            // 
            this.btnExportSql.Location = new System.Drawing.Point(714, 67);
            this.btnExportSql.Name = "btnExportSql";
            this.btnExportSql.Size = new System.Drawing.Size(75, 23);
            this.btnExportSql.TabIndex = 6;
            this.btnExportSql.Text = "导出Sql";
            this.btnExportSql.UseVisualStyleBackColor = true;
            // 
            // btnExportModelClasses
            // 
            this.btnExportModelClasses.Location = new System.Drawing.Point(825, 67);
            this.btnExportModelClasses.Name = "btnExportModelClasses";
            this.btnExportModelClasses.Size = new System.Drawing.Size(75, 23);
            this.btnExportModelClasses.TabIndex = 7;
            this.btnExportModelClasses.Text = "导出实体类";
            this.btnExportModelClasses.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(953, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tvTree
            // 
            this.tvTree.Location = new System.Drawing.Point(12, 119);
            this.tvTree.Name = "tvTree";
            this.tvTree.Size = new System.Drawing.Size(176, 418);
            this.tvTree.TabIndex = 10;
            this.tvTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            // 
            // rbDropIfExists
            // 
            this.rbDropIfExists.AutoSize = true;
            this.rbDropIfExists.Checked = true;
            this.rbDropIfExists.Location = new System.Drawing.Point(194, 57);
            this.rbDropIfExists.Name = "rbDropIfExists";
            this.rbDropIfExists.Size = new System.Drawing.Size(155, 16);
            this.rbDropIfExists.TabIndex = 14;
            this.rbDropIfExists.TabStop = true;
            this.rbDropIfExists.Text = "[DROP TABLE IF EXISTS]";
            this.rbDropIfExists.UseVisualStyleBackColor = true;
            // 
            // rbIfNotExists
            // 
            this.rbIfNotExists.AutoSize = true;
            this.rbIfNotExists.Location = new System.Drawing.Point(194, 79);
            this.rbIfNotExists.Name = "rbIfNotExists";
            this.rbIfNotExists.Size = new System.Drawing.Size(113, 16);
            this.rbIfNotExists.TabIndex = 15;
            this.rbIfNotExists.Text = "[IF NOT EXISTS]";
            this.rbIfNotExists.UseVisualStyleBackColor = true;
            // 
            // btnOpenEditor
            // 
            this.btnOpenEditor.Location = new System.Drawing.Point(472, 37);
            this.btnOpenEditor.Name = "btnOpenEditor";
            this.btnOpenEditor.Size = new System.Drawing.Size(75, 23);
            this.btnOpenEditor.TabIndex = 17;
            this.btnOpenEditor.Text = "打开编辑器";
            this.btnOpenEditor.UseVisualStyleBackColor = true;
            this.btnOpenEditor.Click += new System.EventHandler(this.btnOpenEditor_Click);
            // 
            // tbSql
            // 
            this.tbSql.Location = new System.Drawing.Point(195, 119);
            this.tbSql.Multiline = true;
            this.tbSql.Name = "tbSql";
            this.tbSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSql.Size = new System.Drawing.Size(374, 418);
            this.tbSql.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 549);
            this.Controls.Add(this.tbSql);
            this.Controls.Add(this.btnOpenEditor);
            this.Controls.Add(this.rbIfNotExists);
            this.Controls.Add(this.rbDropIfExists);
            this.Controls.Add(this.tvTree);
            this.Controls.Add(this.btnExportModelClasses);
            this.Controls.Add(this.btnExportSql);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNameSpace);
            this.Controls.Add(this.btnConnConfig);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnOpenExcel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenExcel;
        private System.Windows.Forms.OpenFileDialog openExcelDialog;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnConnConfig;
        private System.Windows.Forms.TextBox tbNameSpace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportSql;
        private System.Windows.Forms.Button btnExportModelClasses;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TreeView tvTree;
        private System.Windows.Forms.RadioButton rbDropIfExists;
        private System.Windows.Forms.RadioButton rbIfNotExists;
        private System.Windows.Forms.Button btnOpenEditor;
        private System.Windows.Forms.TextBox tbSql;
    }
}

