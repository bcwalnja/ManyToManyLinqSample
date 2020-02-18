namespace ManyToManyLinqSample.Models
{
    public partial class JobSchedule
    {
        public int Id { get; set; }
        public Operation Operation { get; set; }
        public System.DateTime Date { get; set; }
        public Crew Crew { get; set; }
    }
}
