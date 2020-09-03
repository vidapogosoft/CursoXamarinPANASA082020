using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TodoAPI.Interfaces;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public class TodoRepository : IToDoRepository
    {
        private List<TodoItems> _toDoList;


        public TodoRepository()
        {
            InitializeData();
        }

        public IEnumerable<TodoItems> All
        { get { return _toDoList; } }


        public void Delete(string id)
        {
            _toDoList.Remove(this.Find(id));
        }

        public bool DoesItemExist(string id)
        {
            return _toDoList.Any(item => item.ID == id);
        }

        public TodoItems Find(string id)
        {
            return _toDoList.FirstOrDefault(item=> item.ID == id);
        }

        public void Insert(TodoItems item)
        {
            _toDoList.Add(item);
        }

        public void Update(TodoItems item)
        {
            var todoItem = this.Find(item.ID);
            var index = _toDoList.IndexOf(todoItem);
            _toDoList.RemoveAt(index);
            _toDoList.Insert(index, item);
        }

        private void InitializeData()
        {
            _toDoList = new List<TodoItems>();

            var todoItem1 = new TodoItems
            {
                ID = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                Name = "Learn app development",
                Notes = "Xamarin University",
                Done = true
            };


            var todoItem2 = new TodoItems
            {
                ID = "6bb8a868-d93b7-94ebce87e243",
                Name = "Api development",
                Notes = "MVA University",
                Done = false
            };

            var todoItem3 = new TodoItems
            {
                ID = "CC8a968-d93b7-94ebce87e290",
                Name = "Publish Apps in Market",
                Notes = "Sipecom",
                Done = false
            };

            _toDoList.Add(todoItem1);
            _toDoList.Add(todoItem2);
            _toDoList.Add(todoItem3);

        }
    }
}
