using RQuery.Base;

namespace RQuery.Interfaces
{
    public interface IOperator<T> where T : RQueryDto
    {
        IBoolean<T> EqualTo(object value);
        IBoolean<T> NotEqualTo(object value);
        IBoolean<T> IsGreaterThan(object value);
        IBoolean<T> IsLessThan(object value);
        IBoolean<T> IsNull();
    }
}