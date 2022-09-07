using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teaAPI.Attributes;
using teaAPI.Models;

namespace teaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class TodosController : ControllerBase
    {
        private readonly teaDBContext _context;

        public TodosController(teaDBContext context)
        {
            _context = context;
        }

        // GET: api/Todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodo()
        {
            return await _context.Todo
                .ToListAsync();
        }

        // GET: api/Todos/5
     /*   [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await _context.Todo.Include(p => p.Category).FirstOrDefaultAsync(p => p.TodoId == id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }*/

        [HttpGet("{day}/{month}/{year}")]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodobyMonth(int day,int month,int year)
        {
            var todo = await _context.Todo.Where(x=>x.TodoDate.Day==day&&x.TodoDate.Month==month&&x.TodoDate.Year==year)
                .ToListAsync();

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        // PUT: api/Todos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, Todo todo)
        {
            if (id != todo.TodoId)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Todos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            _context.Todo.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { id = todo.TodoId }, todo);
        }

        // DELETE: api/Todos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> DeleteTodo(int id)
        {
            var todo = await _context.Todo.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.TodoId == id);
        }
    }
}
