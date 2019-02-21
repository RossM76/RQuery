using RQuery.Base;
using RQuery.Interfaces;
using RQuery.Operators;

namespace RQuery.WhereClause
{
    public sealed class DeleteWhereClause<T> : IWhereClause<T> where T : RQueryDto
    {
        internal DeleteWhereClause() { }

        public IOperator<T> Where(string columnName)
        {
            RQuery.GeneratedSql.Append($" WHERE {columnName}");
            return new DeleteOperator<T>();
        }
    }
}