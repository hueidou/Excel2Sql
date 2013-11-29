using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Table
    {
        public Table()
        {
            Columns = new List<Column>();
        }

        /// <summary>
        /// 表名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        public string Description { get; set; }

        public List<Column> Columns { get; set; }
    }

    public class Column
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        //public string Length { get; set; }

        //public string Decimals { get; set; }

        public string DefaultValue { get; set; }

        public bool IsPrimaryKey { get; set; }
        public bool IsCanNull { get; set; }
        public bool IsIdentity { get; set; }

        /*
 
         private int id;//id
            private String tableName;// 表名
            private String filedName;// 字段名
            private String filedName2;// 字段名
            private String filedType;// 类型
            private int filedLength;// 长度
            private int precision;// 精度
            private String deVlaue;// 默认值
            private boolean hasLength;// 是否有长度
            private boolean hasPrecision;// 是否有精度
            private boolean isPrimaryKey;// 是否是主键
            private boolean isCanNull;//是否可以为空
            private boolean IsIdentity;//是否是标识
            private String desc;//字段说明
            private String foreignKey;//外键*/
    }
}
