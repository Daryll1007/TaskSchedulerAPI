namespace TaskSchedulerAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string? TaskDescription { get; set; }  
        public string? AssignedTo { get; set; }       
        public string? Priority { get; set; }         
        public string? Status { get; set; }           
        public string? Category { get; set; }         
        public string? Notes { get; set; }            
        public string? CreatedBy { get; set; }        
        public List<string>? Tags { get; set; }       
    }
}
