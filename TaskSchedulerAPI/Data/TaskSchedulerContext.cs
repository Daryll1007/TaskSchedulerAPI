using Microsoft.EntityFrameworkCore;
using TaskSchedulerAPI.Models; 

namespace TaskSchedulerAPI.Data
{
    public class TaskSchedulerContext : DbContext
    {
        public TaskSchedulerContext(DbContextOptions<TaskSchedulerContext> options)
            : base(options)
        {
        }

        
        public DbSet<TaskItem> TaskItems { get; set; } 
    }
}
