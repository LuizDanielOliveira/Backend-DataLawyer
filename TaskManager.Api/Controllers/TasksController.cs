using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(tasks);
        }

        // GET: api/tasks
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask([FromBody] TaskItem newTask)
        {
            newTask.CreatedAt = DateTime.UtcNow;
            if (newTask.TimerHours > 0)
                newTask.TimerStart = DateTime.UtcNow;

            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
        }

        // PUT: api/tasks
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem updatedTask)
        {
            if (id != updatedTask.Id)
                return BadRequest("ID da URL difere do ID da tarefa.");

            var existingTask = await _context.Tasks.FindAsync(id);
            if (existingTask == null)
                return NotFound();

            existingTask.Title       = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.TimerHours  = updatedTask.TimerHours;
            existingTask.TimerStart  = updatedTask.TimerStart;
            if (updatedTask.Status == "Concluída" && existingTask.Status != "Concluída")
            {
                existingTask.Status = "Concluída";
                existingTask.CompletedAt = DateTime.UtcNow;
            }
            else
            {
         
                existingTask.Status = updatedTask.Status;
                if (updatedTask.Status != "Concluída")
                {
                    existingTask.CompletedAt = null;
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/tasks
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/tasks
        [HttpPut("{id}/renew")]
        public async Task<IActionResult> RenewTimer(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            task.TimerStart = DateTime.UtcNow;
            task.RenewCount++;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
