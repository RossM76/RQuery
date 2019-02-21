using RQuery.Base;
using RQuery.Interfaces;
using RQuery.Operators;

namespace RQuery.WhereClause
{
    public sealed class UpdateWhereClause<T> : IWhereClause<T> where T : RQueryDto
    {
        internal UpdateWhereClause() { }
        public IOperator<T> Where(string columnName)
        {
            RQuery.GeneratedSql.Append($" WHERE {columnName}");
            return new UpdateOperator<T>();
        }
    }
}