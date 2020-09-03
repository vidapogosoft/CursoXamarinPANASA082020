using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TodoAPI.Interfaces;
using TodoAPI.Models;


namespace TodoAPI.Controllers
{

    public enum ErrorCode
    {
        TodoItemNameAndNotesRequired,
        TodoItemIDInUse,
        RecordNotFound,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }

    [Route("api/[controller]")]
    public class TodoItemsController : Controller
    {
        private readonly IToDoRepository _toDoRepository;

        public TodoItemsController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }


        // GET: api/TodoItems
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_toDoRepository.All); 
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TodoItems
        [HttpPost]
        public IActionResult Create([FromBody] TodoItems item) {
            try {

                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }

                bool itemExists = _toDoRepository.DoesItemExist(item.ID);

                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, 
                        ErrorCode.TodoItemIDInUse.ToString());
                } _toDoRepository.Insert(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            } return Ok(item); }


        // PUT: api/TodoItems/5
        [HttpPut]
        public IActionResult Edit([FromBody] TodoItems item)
        {
            try { if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _toDoRepository.Find(item.ID);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _toDoRepository.Update(item);
            } catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var item = _toDoRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _toDoRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }

    }
}
