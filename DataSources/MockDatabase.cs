using ManyToManyLinqSample.Models;
using System.Collections.Generic;

namespace ManyToManyLinqSample.DataSources
{
    public class MockDatabase
    {
        public MockDatabase()
        {
            Crews = new List<Crew>();
            Employees = new List<Employee>();
            EmployeeSchedules = new List<EmployeeSchedule>();
            JobSchedules = new List<JobSchedule>();
            Operations = new List<Operation>();
            OperationTypes = new List<OperationType>();
        }
        
        public List<Crew> Crews { get; set; }
        public List<Employee> Employees { get; set; }
        public List<EmployeeSchedule> EmployeeSchedules { get; set; }
        public List<JobSchedule> JobSchedules { get; set; }
        public List<Operation> Operations { get; set; }
        public List<OperationType> OperationTypes { get; set; }

        public void CreateMockData()
        {
            GenerateEmployees();
            GenerateOperationTypes();
        }

        private void GenerateEmployees()
        {
            int i = 1;
            foreach (var item in RandomNames())
            {
                Employees.Add(new Employee() { Id = i, Name = item });
                i++;
            }
        }

        private void GenerateOperationTypes()
        {
            int i = 1;
            foreach (var item in OperationTypeNames())
            {
                OperationTypes.Add(new OperationType() { Id = i, Name = item });
                i++;
            }
        }

        public string[] RandomNames()
        {
            //Thanks to http://listofrandomnames.com/
            return new string[]
            {
                "Jaye Amendola",
                "Cathrine Antoine",
                "Jenny Derosier",
                "Forest Short",
                "Clifton Maynard",
                "Kaci Mcgonigle",
                "Hubert Jovel",
                "Fae Kukla",
                "Lory Alcina",
                "Kevin Pflum",
                "Stefan Thiele",
                "Dorathy Weissman",
                "Renita Endsley",
                "Kaylee Gain",
                "Kirk Caputo",
                "Gia Thorn",
                "Ellis Linscott",
                "Hai Varughese",
                "Bernadine Trantham",
                "Sulema Hagedorn",
                "Barabara Nazzaro",
                "Gertrud Pineiro",
                "Mac Aden",
                "Ruthe Garlick",
                "Lashell Ganey",
                "Gaye Hamed",
                "Gabriele Fazenbaker",
                "Kareem Mccammon",
                "Shannan Schachter",
                "Mercy Bara"
            };
        }

        public string[] OperationTypeNames()
        {
            return new string[]
            {
                "Concrete",
                "Millwright ",
                "Finishup- Millwright",
                "Inspection",
                "Billing",
                "Finishup- Bin",
                "Bin Erection",
                "Concrete- Custom",
                "Millwright, No Crane",
                "Floors/Unloads/Repairs",
                "Dryer Service"
            };
        }
    }
}
