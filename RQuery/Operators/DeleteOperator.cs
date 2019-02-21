using RQuery.Base;
using RQuery.Interfaces;
using RQuery.Operands;

namespace RQuery.Operators
{
    public sealed class DeleteOperator<T> : IOperator<T> where T : RQueryDto
    {
        internal DeleteOperator() { }

        public IBoolean<T> EqualTo(object value)
        {
            OperatorCommon.ProvideIsEqualTo(value);
            return new DeleteBoolean<T>();
        }

        public IBoolean<T> NotEqualTo(object value)
        {
            OperatorCommon.ProvideIsNotEqualTo(value);
            return new DeleteBoolean<T>();
        }

        public IBoolean<T> IsGreaterThan(object value)
        {
            OperatorCommon.ProvideIsGreaterThan(value);
            return new DeleteBoolean<T>();
        }

        public IBoolean<T> IsLessThan(object value)
        {
            OperatorCommon.ProvideIsLessThan(value);
            return new DeleteBoolean<T>();
        }

        public IBoolean<T> IsNull()
        {
            OperatorCommon.ProvideIsNull();
            return new DeleteBoolean<T>();
        }
    }
}
