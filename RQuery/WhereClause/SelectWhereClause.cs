using RQuery.Base;
using RQuery.Interfaces;
using RQuery.Operators;

namespace RQuery.WhereClause
{
    public sealed class SelectWhereClause<T> : IWhereClause<T> where T : RQueryDto
    {
        internal SelectWhereClause() { }
        public IOperator<T> Where(string columnName)
        {
            RQuery.GeneratedSql.Append($" WHERE {columnName}");
            return new SelectOperator<T>();
        }
    }
}