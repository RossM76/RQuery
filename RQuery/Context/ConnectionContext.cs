using System;
using System.Data;
using RQuery.Base;
using RQuery.Operations;

namespace RQuery.Context
{
    public sealed class ConnectionContext<T> where T : RQueryDto
    {
        internal ConnectionContext() { }

        public Operation<T> WithConnection(Func<IDbConnection> connectionFactory)
        {
            RQuery.Connection = connectionFactory.Invoke();
            RQuery.Command = RQuery.Connection.CreateCommand();
            return new Operation<T>();
        }
    }
}
