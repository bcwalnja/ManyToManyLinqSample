namespace ManyToManyLinqSample.Models
{
    public partial class Operation
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public OperationType Type { get; set; }
    }
}
