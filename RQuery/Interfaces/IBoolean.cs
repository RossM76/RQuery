using RQuery.Base;

namespace RQuery.Interfaces
{
    public interface IBoolean<T> : IEndOfStatement<T> where T : RQueryDto
    {
        IOperator<T> And(string columnName);
        IOperator<T> Or(string columnName);        
    }
}