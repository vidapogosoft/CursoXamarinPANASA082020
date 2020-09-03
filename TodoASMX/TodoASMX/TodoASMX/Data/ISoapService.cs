using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using TodoASMX.Model;

namespace TodoASMX.Data
{
    public interface ISoapService
    {
        Task<List<TodoItem>> RefreshDataAsync();

        Task SaveTodoItemAsync(TodoItem item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);
    }
}
