using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TaskManager.Models;
using TaskManager.Data;
using task_manager_api;

using task_manager_api;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace TaskManager.API
{
    [Route("tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET /tasks request
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _context.Tasks
                .Select(t => new TaskItemViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsDone = t.IsDone
                }).ToListAsync();

            return Ok(tasks);
        }

        // POST /tasks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskItemRequests request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tasks = new TaskItem
            {
                Title = request.Title,
                IsDone = request.IsDone,
                UserId = 1                  //acutally is bad due to hardcode but there's no authentication functionality yet so... for temp use only
            };

            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();

            var viewModel = new TaskItemViewModel
            {
                Id = tasks.Id,
                Title = tasks.Title,
                IsDone = tasks.IsDone
            };

            return CreatedAtAction(nameof(Get), new { id = tasks.Id }, viewModel);
        }

        // PUT /tasks
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskItemRequests request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _context.Tasks.FindAsync(id);
            if (task == null) 
                return NotFound(new { Message = $"Task with ID {id} not found" });      //validation message return for informative returns

            task.Title = request.Title;
            task.IsDone = request.IsDone;

            await _context.SaveChangesAsync();

            return Ok(new TaskItemViewModel
            {
                Id = task.Id,
                Title = task.Title,
                IsDone = task.IsDone
            });
        }

        // DELETE /tasks
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
