using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskSchedulerAPI.Data; 
using TaskSchedulerAPI.Models; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
public class TaskSchedulerController : ControllerBase
{
    private readonly TaskSchedulerContext _context;

    public TaskSchedulerController(TaskSchedulerContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetTaskItems()
    {
        return Ok(_context.TaskItems.ToList());
    }

    
    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetTaskItem(int id)
    {
        var taskItem = _context.TaskItems.Find(id);
        if (taskItem == null)
        {
            return NotFound();
        }
        return Ok(taskItem);
    }

    
    [HttpPost]
    public ActionResult<TaskItem> CreateTaskItem(TaskItem taskItem)
    {
        if (taskItem == null)
        {
            return BadRequest("TaskItem is null.");
        }

        _context.TaskItems.Add(taskItem);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.Id }, taskItem);
    }

    
    [HttpPut("{id}")]
    public IActionResult UpdateTaskItem(int id, TaskItem taskItem)
    {
        if (id != taskItem.Id)
        {
            return BadRequest();
        }

        _context.Entry(taskItem).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TaskItems.Any(e => e.Id == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public IActionResult DeleteTaskItem(int id)
    {
        var taskItem = _context.TaskItems.Find(id);
        if (taskItem == null)
        {
            return NotFound();
        }

        _context.TaskItems.Remove(taskItem);
        _context.SaveChanges();

        return NoContent();
    }
}
