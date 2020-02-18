using ManyToManyLinqSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            GenerateOperations();
            GenerateCrews();
            GenerateEmployeeSchedules();
            GenerateJobSchedules();
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

        private void GenerateOperations()
        {
            var rand = new System.Random();
            int count = OperationTypes.Count;
            for (int i = 1; i < 1200; i++)
            {
                var type = OperationTypes[rand.Next(1, count)];
                Operations.Add(new Operation()
                {
                    Id = i,
                    Active = true,
                    Deleted = false,
                    Priority = rand.Next(1, 10),
                    Type = type
                });
            }
        }

        private void GenerateCrews()
        {
            var rand = new System.Random();
            for (int i = 1; i < 15; i++)
            {
                var PIN = rand.Next(1000, 9999);
                var leader = Employees[i * 2];
                Crews.Add(new Crew()
                {
                    Id = i,
                    Name = $"{PIN} {leader.Name}"
                });
            }
        }

        private void GenerateEmployeeSchedules()
        {
            var rand = new System.Random();
            foreach (var employee in Employees)
            {
                var date = DateTime.Today.AddYears(-1).AddDays(7);
                int id = employee.Id;
                for (int i = 0; i < 265; i++)
                {
                    date = GetNextBusinessDay(date);
                    var crew = Crews[rand.Next(1, Crews.Count)];

                    EmployeeSchedules.Add(new EmployeeSchedule()
                    {
                        Id = id + i,
                        Crew = crew,
                        Employee = employee,
                        Date = date,
                        IsLeader = i % 10 == 0
                    });
                }
            }
        }

        private void GenerateJobSchedules()
        {
            var date = DateTime.Today.AddYears(-1).AddDays(7);
            for (int i = 0; i < 261; i++)
            {
                date = GetNextBusinessDay(date);

                foreach (var crew in Crews)
                {
                    int id = crew.Id;
                    int operationId = id % Operations.Count;
                    operationId = operationId == 0 ? 1 : operationId;
                    var op = Operations[operationId];

                    JobSchedules.Add(new JobSchedule()
                    {
                        Id = id,
                        Date = date,
                        Crew = crew,
                        Operation = op
                    });
                } 
            }
        }

        private DateTime GetNextBusinessDay(DateTime date)
        {
            date = date.AddDays(1);
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                date = date.AddDays(1);
            }
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
            }
            return date;
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
                "Mercy Bara",
                "Elmer Sinner",
                "Mauricio Buescher",
                "Cornelius Vendetti",
                "Frederick Mackson",
                "Dave Jasinski",
                "Roger Gillis",
                "Jaime Zucco",
                "Trey Swinney",
                "Boyd Elmendorf",
                "Zack Shiffer",
                "Dick Saechao",
                "Hans Pyne",
                "Russel Lanasa",
                "Kasey Mccollough",
                "Vincent Milliman",
                "Shawn Grandberry",
                "Murray Walford",
                "Moises Thill",
                "Lewis Schwebach",
                "Enoch Beery",
                "Carter Roark",
                "Rubin Buckle",
                "Dallas Prochnow",
                "Randal Luebbers",
                "Ralph Klos",
                "Fritz Mark",
                "Dane Sundberg",
                "Ivan Kitchens",
                "Patricia Woodall",
                "Dee Purdie",
                "Lucas Seales",
                "Burton Blankinship",
                "Alonzo Lusk",
                "Frank Square",
                "Clarence Pipes",
                "Morgan Billick",
                "Marcos Foronda",
                "Cornell Columbus",
                "Michale Fritzler",
                "Cecil Nishimoto",
                "Darrel Carberry",
                "Isaias Miceli",
                "Zane Koehn",
                "Judson Spraggs",
                "Ezequiel Rowse",
                "Will Dupree",
                "Jess Masterson",
                "Bob Trombly",
                "Mckinley Fickes",
                "Ted Pennel"
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
