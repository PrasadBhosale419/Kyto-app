namespace az_demo_prac.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Discipline TaskDiscipline { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public bool IsDeprecated { get; set; }
    }

    public enum Discipline
    {
        None = 0,
        Cleaning,
        Repairing,
        Grooming,
        Tours,
        Cooking,
        Teaching
    }
}
