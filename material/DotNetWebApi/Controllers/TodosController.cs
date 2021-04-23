using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DotNetWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetWebApi.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TodosController : Controller
    {
        private readonly ILogger<TodosController> _logger;
        private ToDoDbContext _context;

        public TodosController(ILogger<TodosController> logger, object hello, 
            List<object> todos, ToDoDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
            dbContext.Database.EnsureCreated();

            logger.LogDebug("Hello", hello);
            Console.WriteLine(hello);

            Console.WriteLine("Todo:", todos.Count);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var _todos = _context.ToDos.ToList<object>();

            _logger.LogInformation("GET");
            Console.WriteLine(_todos);

            return Ok(_todos);
        }
        // => Ok(new object[] { 1, "2", DateTime.Now });

        [HttpPost]
        public IActionResult Post([FromBody] ToDoItem input)
        {
            // id
            // { "Comprar pan", "Hacer pagos", "..."  }
            //        0             1        n

            _context.ToDos.Add(input);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            // System.Linq
            ToDoItem found = _context.ToDos.Find(id);

            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var found = _context.ToDos.Find(id);

            if (found != null)
            {
                _context.ToDos.Remove(found); // _todos[id] = null;
                _context.SaveChanges();

                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] object input)
        {
            return Ok();
        }
    }
}