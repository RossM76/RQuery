using RQuery.Base;
using RQuery.Interfaces;
using RQuery.Operands;

namespace RQuery.Operators
{
    public class SelectOperator<T> : IOperator<T> where T : RQueryDto
    {
        internal SelectOperator() { }

        public IBoolean<T> EqualTo(object value)
        {
            OperatorCommon.ProvideIsEqualTo(value);
            return new SelectBoolean<T>();
        }

        public IBoolean<T> NotEqualTo(object value)
        {
            OperatorCommon.ProvideIsNotEqualTo(value);
            return new SelectBoolean<T>();
        }

        public IBoolean<T> IsGreaterThan(object value)
        {
            OperatorCommon.ProvideIsGreaterThan(value);
            return new SelectBoolean<T>();
        }

        public IBoolean<T> IsLessThan(object value)
        {
            OperatorCommon.ProvideIsLessThan(value);
            return new SelectBoolean<T>();
        }

        public IBoolean<T> IsNull()
        {
            OperatorCommon.ProvideIsNull();
            return new SelectBoolean<T>();
        }
    }
}