namespace ManyToManyLinqSample.Models
{
    public partial class EmployeeSchedule
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Crew Crew { get; set; }
        public bool IsLeader { get; set; }
        public System.DateTime Date { get; set; }
    }
}
