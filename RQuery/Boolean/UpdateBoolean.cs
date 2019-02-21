using RQuery.Base;
using RQuery.EndOfStatement;
using RQuery.Interfaces;
using RQuery.Operators;

namespace RQuery.Operands
{
    public sealed class UpdateBoolean<T> : NonQuery<T>, IBoolean<T> where T : RQueryDto
    {
        internal UpdateBoolean() { }

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