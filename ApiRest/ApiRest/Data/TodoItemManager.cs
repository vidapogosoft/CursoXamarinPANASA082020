using System;
using System.Collections.Generic;
using System.Text;

using ApiRest.Model;
using System.Threading.Tasks;

namespace ApiRest.Data
{
    public class TodoItemManager
    {

        IRestServices _restServices;


        public TodoItemManager( IRestServices services)
        {
            _restServices = services;
        }

        public Task<List<TodoItems>> GetTodoItem()
        {
            return _restServices.GetData();
        }

        public Task SaveTodoItem (TodoItems item, bool isnew = false)
        {
            return _restServices.SaveTodoItem(item, isnew);
        }


    }
}
