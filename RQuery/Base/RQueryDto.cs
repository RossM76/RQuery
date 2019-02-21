using System;
using System.Linq;
using System.Reflection;
using System.Text;
using RQuery.Attributes;

namespace RQuery.Base
{
    public abstract class RQueryDto
    {
        internal string[] GetColumnNames(bool excludeIdentity = false)
        {
            var properties =  GetType().GetProperties();
            var columns = properties
                .Where(p => (p.GetCustomAttribute<IsIdentity>() == null || !excludeIdentity) &&
                            p.GetCustomAttribute<IsColumn>() != null)
                .Select(c => c.GetCustomAttribute<IsColumn>());

            var columnNames = columns.Where(c=> c !=null).Select(cn => cn.ColumnName).ToArray();

            return columnNames;
        }

        internal string CreateColumnList(bool excludeIdentity = false)
        {
            return CreateColumnList(GetColumnNames(excludeIdentity));
        }
        internal string CreateColumnList(string[] columnNames)
        {
            var selectList = new StringBuilder();

            for (var i = 0; i < columnNames.Length; i++)
            {
                selectList.Append($"{columnNames[i]}");

                if (i + 1 < columnNames.Length)
                    selectList.Append(",");
            }

            return selectList.ToString();
        }

        internal string CreateInsertValuesList()
        {
            var propertiesWithColumnAttr =
                GetType().GetProperties().Where(p => p.GetCustomAttribute<IsColumn>() != null).ToArray();

            var valueList = new StringBuilder();

            if (propertiesWithColumnAttr.Length == 0)
                throw new InvalidOperationException("There are no IsColumn attributes on this object");

            for (var index = 0; index < propertiesWithColumnAttr.Length; index++)
            {
                var property = propertiesWithColumnAttr[index];
                var column = property.GetCustomAttribute<IsColumn>();
                var value = property.GetValue(this);
                var parameterName = RQuery.AddParameter(value, column.ColumnName);
                valueList.Append($"@{parameterName}");

                if (index + 1 < propertiesWithColumnAttr.Length)
                    valueList.Append(",");
            }

            return valueList.ToString();
        }

        internal string GetTableName()
        {
            var attr = GetType().GetCustomAttribute<IsTable>();
            
            if (attr == null)
                throw new InvalidOperationException("Object does not contain an IsTable attribute");

            return attr.TableName;
        }

        internal PropertyInfo GetPropertyByIsColumnAttribute(string columnName)
        {
            var properties = GetType().GetProperties();
            var propertyInfo = properties.FirstOrDefault(c => c.GetCustomAttribute<IsColumn>()?.ColumnName == columnName);
            return propertyInfo;
        }

        internal object GetIdentityColumnValue()
        {
            var identityColumn = GetIdentityColumnProperty();
            var value = identityColumn.GetValue(this);

            if (value == null)
                throw new InvalidOperationException("There is no value assigned to the identity");

            return value;
        }

        internal PropertyInfo GetIdentityColumnProperty()
        {
            var properties = GetType().GetProperties();
            var identityProperty = properties.FirstOrDefault(p => (p.GetCustomAttribute<IsIdentity>() != null) &&
                                                          p.GetCustomAttribute<IsColumn>() != null);
                
            return identityProperty;
        }

        internal string GetIdentityColumnName()
        {
            var identityColumnAttribute = GetIdentityColumnProperty()?.GetCustomAttribute<IsColumn>();

            if (identityColumnAttribute == null)
                throw new InvalidOperationException("There is no IsIdentity attribute on this object");

            return identityColumnAttribute.ColumnName;
        }

        internal string CreateUpdateValuesList(string[] columnsToUpdate)
        {
            var updateList = new StringBuilder();
            var columnNames = GetColumnNames(true).Where(cn => columnsToUpdate.Length == 0 || columnsToUpdate.Any(cu => cu == cn)).ToArray();

            if (columnNames.Length == 0)
                throw new InvalidOperationException("Could not generate column names. If you specified a column list make sure it matches the IsColumn attributes on your object, otherwise ensure that there are IsColumn attributes applied");

            for (var index = 0; index < columnNames.Length; index++)
            {
                var columnName = columnNames[index];
                var property = GetPropertyByIsColumnAttribute(columnName);

                if (property == null) continue;
                
                var value = property.GetValue(this);
                var parameterName = RQuery.AddParameter(value, columnName);

                updateList.Append($"{columnName} = {parameterName}");

                if (index + 1 < columnNames.Length)
                    updateList.Append(",");
            }

            return updateList.ToString();
        }
    }
}
