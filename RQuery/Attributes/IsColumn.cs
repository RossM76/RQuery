using System;

namespace RQuery.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IsColumn : Attribute
    {
        public string ColumnName { get; internal set; }

        public IsColumn(string columnName)
        {
            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentNullException(nameof(columnName));

            ColumnName = columnName;            
        }
    }
}
