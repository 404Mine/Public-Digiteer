using System.ComponentModel.DataAnnotations;

namespace task_manager_api
{
    public class TaskItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }

    public class TaskItemRequests
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }
}