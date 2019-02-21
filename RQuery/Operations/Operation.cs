using RQuery.Base;
using RQuery.EndOfStatement;
using RQuery.WhereClause;

namespace RQuery.Operations
{
    public sealed class Operation<T> where T : RQueryDto
    {
        internal Operation() { }

        public SelectWhereClause<T> Select()
        {
            var selectClause =
                $"SELECT {RQuery.DtoInstance.CreateColumnList()} FROM {RQuery.DtoInstance.GetTableName()}";

            RQuery.GeneratedSql.Append(selectClause);
            return new SelectWhereClause<T>();
        }

        public NonQuery<T> Insert(T instance)
        {
            RQuery.DtoInstance = instance;
            RQuery.GeneratedSql.Append($"INSERT INTO {instance.GetTableName()} ({instance.CreateColumnList(true)}) VALUES ({instance.CreateInsertValuesList()}) ");
            return new NonQuery<T>();
        }

        public UpdateWhereClause<T> Update(T instance, params string[] columnsToUpdate)
        {
            RQuery.DtoInstance = instance;
            RQuery.GeneratedSql.Append($"UPDATE {instance.GetTableName()} SET {instance.CreateUpdateValuesList(columnsToUpdate)}");

            return new UpdateWhereClause<T>();
        }

        public NonQuery<T> Delete(T instance)
        {
            RQuery.DtoInstance = instance;
            var parameter = RQuery.AddParameter(instance.GetIdentityColumnValue(), instance.GetIdentityColumnName());
            RQuery.GeneratedSql.Append($"DELETE FROM {instance.GetTableName()} WHERE {instance.GetIdentityColumnName()} = {parameter}");
            return new NonQuery<T>();
        }

        public DeleteWhereClause<T> Delete()
        {
            RQuery.GeneratedSql.Append($"DELETE FROM {RQuery.DtoInstance.GetTableName()}");
            return new DeleteWhereClause<T>();
        }
    }
}