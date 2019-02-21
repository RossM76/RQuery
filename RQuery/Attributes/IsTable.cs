using System;

namespace RQuery.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IsTable : Attribute
    {
        public string TableName { get; internal set; }
        public IsTable(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(tableName);

            TableName = tableName;
        }
    }
}
