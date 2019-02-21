using System;
using System.Data;
using System.Text;
using RQuery.Base;
using RQuery.Context;
using RQuery.Enums;

namespace RQuery
{
    public static class RQuery
    {
        internal static IDbConnection Connection;
        internal static IDbCommand Command;
        internal static StringBuilder GeneratedSql;
        internal static RQueryDto DtoInstance;        

        public static DatabaseDialectType DatabaseDialectType { get; set; }

        public static ConnectionContext<T> ForType<T>() where T : RQueryDto
        {
            GeneratedSql = new StringBuilder();
            DtoInstance = Activator.CreateInstance<T>();
            return new ConnectionContext<T>();
        }

        internal static string AddParameter(object value)
        {
            return AddParameter(value, $"{Command.Parameters.Count}{Math.Abs(value.GetHashCode())}");
        }

        internal static string AddParameter(object value, string columnName)
        {
            var parameter = Command.CreateParameter();
            parameter.ParameterName = columnName;
            parameter.Value = value;
            Command.Parameters.Add(parameter);
            return $"@{columnName}";
        }
    }
}
