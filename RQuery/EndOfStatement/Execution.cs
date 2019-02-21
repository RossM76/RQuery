using System;
using System.Collections.Generic;
using System.Data;
using RQuery.Base;

namespace RQuery.EndOfStatement
{
    internal static class Execution
    {
        public static IEnumerable<T> Execute<T>() where T : RQueryDto
        {
            using (var con = RQuery.Connection)
            {
                if (con.State != ConnectionState.Open) con.Open();
                SetCommandText();

                var reader = RQuery.Command.ExecuteReader();
                var result = CastReaderDataToEntities<T>(reader);
                return result;
            }
        }

        public static int Execute()
        {
            using (var con = RQuery.Connection)
            {
                if (con.State != ConnectionState.Open) con.Open();
                SetCommandText();

                var result = RQuery.Command.ExecuteNonQuery();
                return result;
            }
        }

        private static void SetCommandText()
        {
            RQuery.Command.CommandType = CommandType.Text;
            RQuery.Command.CommandText = RQuery.GeneratedSql.ToString();
        }

        private static IEnumerable<T> CastReaderDataToEntities<T>(IDataReader reader) where T : RQueryDto
        {
            var result = Array.Empty<T>();

            while (reader.Read())
            {
                Array.Resize(ref result, result.Length+1);
                var entity = MapColumnsToProperties<T>(reader);
                result[result.Length -1] = entity;
            }

            return result;
        }

        private static T MapColumnsToProperties<T>(IDataRecord reader) where T : RQueryDto
        {
            var entity = Activator.CreateInstance<T>();
            var columnNames = entity.GetColumnNames();

            foreach (var columnName in columnNames)
            {
                var value = reader[columnName];
                var property = entity.GetPropertyByIsColumnAttribute(columnName);
                property.SetValue(entity, value);
            }

            return entity;
        }
    }
}