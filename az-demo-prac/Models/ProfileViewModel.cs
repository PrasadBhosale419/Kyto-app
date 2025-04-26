using az_demo_prac.Models;
using TaskStatus = az_demo_prac.Models.TaskStatus;

namespace az_demo_prac.Models
{
    public class ProfileViewModel
    {
        public User User { get; set; }
        public int TaskCount { get; set; }
        public decimal MoneyEarned { get; set; }

        public List<CompletedTaskDto> CompletedTasks { get; set; }
        public List<PostedTaskDto> PostedTasks { get; set; }
        public List<UserServiceDto> UserServices { get; set; }
    }

    public class CompletedTaskDto
    {
        public string TaskName { get; set; }
        public decimal Price { get; set; }
    }

    public class PostedTaskDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public decimal Price { get; set; }
        public TaskStatus TaskStatus { get; set; }
    }

    public class UserServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}

