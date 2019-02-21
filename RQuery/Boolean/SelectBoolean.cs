using RQuery.Base;
using RQuery.EndOfStatement;
using RQuery.Interfaces;
using RQuery.Operators;

namespace RQuery.Operands
{
    public sealed class SelectBoolean<T> : Query<T>, IBoolean<T> where T : RQueryDto
    {
        internal SelectBoolean() { }

        public IOperator<T> And(string columnName)
        {
            BooleanCommon.ProvideAnd(columnName);
            return new SelectOperator<T>();
        }

        public IOperator<T> Or(string columnName)
        {
            BooleanCommon.ProvideOr(columnName);
            return new SelectOperator<T>();
        }
    }
}