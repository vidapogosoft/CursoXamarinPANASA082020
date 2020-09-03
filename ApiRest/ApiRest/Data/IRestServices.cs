using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiRest.Model;

namespace ApiRest.Data
{
    public interface IRestServices
    {
        Task<List<TodoItems>> GetData();

        Task SaveTodoItem(TodoItems item, bool isnewItem);

        //Task DelTodoItem(string id);

    }
}
