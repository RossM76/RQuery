namespace RQuery.Operators
{
    internal static class OperatorCommon
    {
        public static void ProvideIsEqualTo(object value)
        {
            var parameterName = RQuery.AddParameter(value);
            RQuery.GeneratedSql.Append($" = {parameterName}");
        }

        public static void ProvideIsNotEqualTo(object value)
        {
            var parameterName = RQuery.AddParameter(value);
            RQuery.GeneratedSql.Append($" <> {parameterName}");
        }

        public static void ProvideIsLessThan(object value)
        {
            var parameterName = RQuery.AddParameter(value);
            RQuery.GeneratedSql.Append($" < {parameterName}");
        }

        public static void ProvideIsGreaterThan(object value)
        {
            var parameterName = RQuery.AddParameter(value);
            RQuery.GeneratedSql.Append($" > {parameterName}");
        }

        public static void ProvideIsNull()
        {
            RQuery.GeneratedSql.Append(" IS NULL");
        }
    }
}
