using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Text.RegularExpressions;

namespace Excel2SqlSchema.Helper
{
    public class MySqlHelper
    {
        // SET FOREIGN_KEY_CHECKS=0;

        /// <summary>
        /// 生成CreateSQL语句
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string GenerateCreateSql(Table table, bool dropIfExists, bool ifNotExists)
        {
            StringBuilder sbSql = new StringBuilder();
            if (dropIfExists)
            {
                sbSql.AppendFormat("DROP TABLE IF EXISTS `{0}`;", table.Name);
                sbSql.AppendLine();
            }

            sbSql.AppendFormat(ParserOptions("CREATE [TEMPORARY] TABLE [IF NOT EXISTS] `{0}` (", false, ifNotExists), table.Name);
            sbSql.AppendLine();

            List<string> primaryKeys = new List<string>();
            List<string> columnDefs = new List<string>();
            foreach (Column column in table.Columns)
            {
                StringBuilder sbColumnDef = new StringBuilder();

                // col_name type
                sbColumnDef.AppendFormat(" `{0}` {1} ", column.Name, column.Type);

                // [NOT NULL | NULL]
                if (column.IsCanNull)
                {
                    sbColumnDef.Append("NULL ");
                }
                else
                {
                    sbColumnDef.Append("NOT NULL ");
                }

                // [DEFAULT default_value]
                if (column.DefaultValue != null && column.DefaultValue != "")
                {
                    sbColumnDef.AppendFormat("DEFAULT '{0}' ", column.DefaultValue);
                }

                // [AUTO_INCREMENT]
                if (column.IsIdentity)
                {
                    sbColumnDef.Append("AUTO_INCREMENT ");
                }

                // [UNIQUE [KEY] | [PRIMARY] KEY]

                // [COMMENT 'string']
                if (column.Description != null && column.Description != "")
                {
                    sbColumnDef.AppendFormat("COMMENT '{0}' ", column.Description);
                }

                // [reference_definition]


                // 加入
                columnDefs.Add(sbColumnDef.ToString().TrimEnd());

                // 约束
                if (column.IsPrimaryKey)
                {
                    primaryKeys.Add("`" + column.Name + "`");
                }
            }

            // 约束   PRIMARY KEY (`id`, `new_tablecol`),
            string primaryStr = string.Join(", ", primaryKeys.ToArray());
            columnDefs.Add("  PRIMARY KEY (" + primaryStr + ")");

            sbSql.Append(string.Join("," + Environment.NewLine, columnDefs.ToArray()));
            sbSql.AppendLine(")");

            // COMMENT = 'string'
            if (table.Description != null && table.Description != "")
            {
                sbSql.AppendFormat("COMMENT = '{0}' ", table.Description);
            }

            return sbSql.ToString().TrimEnd() + ";" + Environment.NewLine;
        }

        /// <summary>
        /// 设置可选项
        /// </summary>
        /// <param name="str"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        private static string ParserOptions(string str, params bool[] parms)
        {
            Regex regex = new Regex("\\[(.*?)\\] ");

            MatchCollection matches = regex.Matches(str);

            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                bool isSet = parms[i];

                if (isSet)
                {
                    str = str.Replace(match.Groups[0].Value, match.Groups[1].Value + " ");
                }
                else
                {
                    str = str.Replace(match.Groups[0].Value, "");
                }
            }

            return str;
        }
    }
}
