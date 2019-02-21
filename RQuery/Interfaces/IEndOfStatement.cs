using System.Collections.Generic;
using RQuery.Base;

namespace RQuery.Interfaces
{
    public interface IEndOfStatement<out T> where T : RQueryDto
    {
        int Execute();
        IEnumerable<T> ReturnQuery();
    }
}