using System;
using System.Linq;

namespace RQuery.Operands
{
    internal static class BooleanCommon
    {
        internal static void ProvideAnd(string columnName)
        {
            ValidateColumn(columnName);
            RQuery.GeneratedSql.Append($" AND {columnName}");
        }

        internal static void ProvideOr(string columnName)
        {
            ValidateColumn(columnName);
            RQuery.GeneratedSql.Append($" OR {columnName}");
        }

        internal static void ValidateColumn(string columnName)
        {
            var isValid = RQuery.DtoInstance.GetColumnNames().Any(c => c == columnName);

            if (!isValid)
                throw new InvalidOperationException($"Column name {columnName} does not exist as an IsColumn attribute on object type {RQuery.DtoInstance.GetType().Name}");
        }
    }
}
