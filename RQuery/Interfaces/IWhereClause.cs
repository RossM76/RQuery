using RQuery.Base;

namespace RQuery.Interfaces
{
    public interface IWhereClause<T>  where T : RQueryDto
    {
        IOperator<T> Where(string columnName);
    }
}