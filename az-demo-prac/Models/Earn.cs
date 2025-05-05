namespace az_demo_prac.Models
{
    public class Earn
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public int UserId { get; set; }

        public string TaskDetails { get; set; }

        public string FlatNo { get; set; }

        public string Addressline1 { get; set; }

        public string? Addressline2 { get; set; }

        public TaskStatus TaskStatus { get; set; }

        public int Completedby { get; set; }

        public double Price { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public bool IsDeprecated { get; set; }
    }

    public enum TaskStatus
    {
        None=0,
        Unaccepted,
        Accepted,
        Completed
    }
}
