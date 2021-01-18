using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.Utils
{
    public class QueryBuilder
    {
        public QueryBuilder() { }

        public string ConstructorSelectAll(string table)
        {
            return "select * from " + table + " where state = 1;";
        }        
    }
}
