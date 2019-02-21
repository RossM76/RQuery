using System.Collections.Generic;
using System.Linq;
using RQuery.Base;
using RQuery.Enums;
using RQuery.Interfaces;

namespace RQuery.EndOfStatement
{
    public class Query<T> : IEndOfStatement<T> where T: RQueryDto
    {
        internal Query() { }

        public int Execute()
        {
            return ReturnQuery().Count();
        }

        public IEnumerable<T> ReturnQuery()
        {
            if (RQuery.DatabaseDialectType == DatabaseDialectType.MySql) RQuery.GeneratedSql.Append(";");
            return Execution.Execute<T>();
        }
    }
}