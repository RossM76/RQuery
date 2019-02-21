using System.Collections.Generic;
using RQuery.Base;
using RQuery.Enums;
using RQuery.Interfaces;

namespace RQuery.EndOfStatement
{
    public class NonQuery<T> : IEndOfStatement<T> where T : RQueryDto
    {
        internal NonQuery() { }
        public int Execute()
        {
            if (RQuery.DatabaseDialectType == DatabaseDialectType.MySql) RQuery.GeneratedSql.Append(";");
            return Execution.Execute();
        }
        public IEnumerable<T> ReturnQuery()
        {
            Execute();
            return new[] { (T)RQuery.DtoInstance  };
        }
    }
}