using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Threading.Tasks;
using System.Diagnostics;
using System.Web.Services.Protocols;
using TodoASMX.Data;
using TodoASMX.Model;

namespace TodoASMX.Droid
{
    public class SoapService :ISoapService
    {
        ASMXService.TodoServices todoServices;

        TaskCompletionSource<bool> getRequestComplete = null;
        TaskCompletionSource<bool> saveRequestComplete = null;
        TaskCompletionSource<bool> delRequestComplete = null;


        public List<TodoItem> Items { get; set; } = new List<TodoItem>();

        public SoapService()
        {
            todoServices = new ASMXService.TodoServices();
            todoServices.Url = Constants.SoapUrl;

            todoServices.GetTodoItemsCompleted += TodoServices_GetTodoItemsCompleted;
        }

        static TodoItem FromASMXServiceTodoItem(ASMXService.TodoItem item)
        {
            return new TodoItem
            {
                ID = item.ID,
                Name = item.Name,
                Notes = item.Notes,
                Done = item.Done
             };
        }

        private void TodoServices_GetTodoItemsCompleted(object sender, ASMXService.GetTodoItemsCompletedEventArgs e)
        {

            try
            {
                getRequestComplete = getRequestComplete ?? new TaskCompletionSource<bool>();

                Items = new List<TodoItem>();

                foreach ( var item in e.Result )
                {
                    Items.Add(FromASMXServiceTodoItem(item));
                }

                getRequestComplete?.TrySetResult(true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"Error {0}", ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task ISoapService.DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        async Task<List<TodoItem>> ISoapService.RefreshDataAsync()
        {
            getRequestComplete = new TaskCompletionSource<bool>();
            todoServices.GetTodoItemsAsync();
            await getRequestComplete.Task;
            return Items;
        }

        Task ISoapService.SaveTodoItemAsync(TodoItem item, bool isNewItem)
        {
            throw new NotImplementedException();
        }
    }
}