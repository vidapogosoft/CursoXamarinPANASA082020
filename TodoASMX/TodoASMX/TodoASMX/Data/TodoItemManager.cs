using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using TodoASMX.Model;

namespace TodoASMX.Data
{
    public class TodoItemManager
    {
        ISoapService soapService;

        public TodoItemManager(ISoapService service)
        {
            soapService = service;
        }

        public Task<List<TodoItem>> GetTodoItemsAsync()
        {
            return soapService.RefreshDataAsync();
        }


        public Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
        {
            return soapService.SaveTodoItemAsync(item, isNewItem);
        }
    }
}
