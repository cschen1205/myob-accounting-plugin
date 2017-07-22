﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;

namespace Accounting.Db.SqlClient.Elements
{
    public class SqlClientDbDeleteStatement : DbDeleteStatement
    {
        public SqlClientDbDeleteStatement(DbManager mgr)
            : base(mgr)
        {
            
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("DELETE FROM {0}", DbMgr.FieldAlias(mTable));

            string where_text = WhereText;
            if (where_text != "")
            {
                sb.AppendFormat(" WHERE {0}", where_text);
            }

            return sb.ToString();
        }
    }
}
