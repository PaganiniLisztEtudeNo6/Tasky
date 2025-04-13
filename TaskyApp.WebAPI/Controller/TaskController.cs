using Microsoft.AspNetCore.Mvc; // เพิ่มการใช้งาน ASP.NET Core MVC
using TaskyApp.Infrastructure.Persistence; // สำหรับการใช้งาน AppDbContext
using TaskyApp.Domain.Entities; // สำหรับการใช้งาน TaskItem

namespace TaskyApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _context.TaskItems.ToList();
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskItem task)
        {
            _context.TaskItems.Add(task);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }
    }
}
