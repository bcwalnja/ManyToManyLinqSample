using ManyToManyLinqSample.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyLinqSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
            
            MockDatabase db = CreateDatabase();

            ReadOutCreatedData(db);

            var employee = db.Employees[0];
            Console.WriteLine($"First Employee: {employee.Name}");
            Console.ReadLine();

            var empSched = db.EmployeeSchedules.Where(x => x.Date >= DateTime.Today && x.Employee == employee);
            Console.WriteLine($"{employee.Name}'s Schedules:");
            foreach (var item in empSched)
            {
                Console.WriteLine($"{item.Id}: Crew {item.Crew.Name}, Date {item.Date:MMM dd}");
            }
            Console.ReadLine();

            Console.WriteLine($"Let's try to find {employee.Name}'s scheduled operations:");
            Console.ReadLine();

            var opList = Utilities.CrewMemberUtility.GetOperationsByEmployee(db, employee);
            foreach (var item in opList)
            {
                Console.WriteLine($"Operation: {item.Id} {item.Type.Name}");
            }

            Console.WriteLine($"Let's try to find {employee.Name}'s crew members for today:");


            End();
        }

        private static void Start()
        {
            Console.WriteLine("Welcome to Many to Many Linq Sample");
            Console.WriteLine("This program was created to help with an SO question");
            Console.WriteLine("Press any key to generate random data: ");
            Console.ReadLine();
        }

        private static void End()
        {
            Console.WriteLine("Press any key to close");
            Console.ReadLine();
        }

        private static MockDatabase CreateDatabase()
        {
            var db = new MockDatabase();
            try
            {
                db.CreateMockData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            return db;
        }

        private static void ReadOutCreatedData(MockDatabase db)
        {
            Console.WriteLine("Finished creating:");
            Console.WriteLine($"{db.Crews.Count} Crews");
            Console.WriteLine($"{db.Employees.Count} Employees");
            Console.WriteLine($"{db.EmployeeSchedules.Count} EmployeeSchedules");
            Console.WriteLine($"{db.JobSchedules.Count} JobSchedules");
            Console.WriteLine($"{db.Operations.Count} Operations");
            Console.WriteLine($"{db.OperationTypes.Count} OperationTypes");
        }
    }
}
