using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using TodoAPI.Models;


namespace TodoAPI.Interfaces
{
    public interface IToDoRepository
    {
        bool DoesItemExist(string id);
        IEnumerable<TodoItems> All { get; }
        TodoItems Find(string id);
        void Insert(TodoItems item);
        void Update(TodoItems item);
        void Delete(string id);
    }
}
