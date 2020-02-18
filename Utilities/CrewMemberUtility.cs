using ManyToManyLinqSample.DataSources;
using ManyToManyLinqSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManyToManyLinqSample.Utilities
{
    public static class CrewMemberUtility
    {
        public static bool IsCrewLeader(MockDatabase db, Operation operation)
        {
            //get all job schedules for this employee
            var employeeSchedules = db.EmployeeSchedules;
            var jobSchedules = db.JobSchedules;

            //find all schedules that match operation
            var jobMatches = jobSchedules.Where(x => x.Operation == operation);

            //get dates for those job schedules
            var dates = jobMatches.Select(x => x.Date);

            //return if any of those dates the employee has schedules with IsLeader = true
            var matches = new List<EmployeeSchedule>();

            foreach (var date in dates)
            {
                matches.AddRange(employeeSchedules.Where(x => x.Date == date));
            }

            var result = matches.Any(x => x.IsLeader);

            return result;
        }

        public static IEnumerable<Operation> GetOperationsByEmployee(MockDatabase db, Employee employee)
        {
            var empSchedMatches = db.EmployeeSchedules.Where(x => x.Date >= DateTime.Today && x.Employee == employee);

            var allJobSched = db.JobSchedules.Where(x => x.Date >= DateTime.Today && x.Crew != null && x.Operation != null);

            var jobSchedMatches = new List<JobSchedule>();
            
            foreach (var empSched in empSchedMatches)
            {
                var matches = allJobSched.Where(x => x.Date == empSched.Date && x.Crew == empSched.Crew);
                jobSchedMatches.AddRange(matches);
            }

            return jobSchedMatches.Select(x => x.Operation).Distinct();
        }
        public static IEnumerable<EmployeeSchedule> FindCrewMembersByEmployeeAndOperation(
            MockDatabase db, Employee employee, Operation operation)
        {
            //Get Employee's employee schedules
            var allEmpSched = db.EmployeeSchedules;
            var empSchedules = allEmpSched.Where(x => x.Date >= DateTime.Today);
            var specificEmpSched = empSchedules.Where(x => x.Employee == employee);

            //Get date list
            var empDates = specificEmpSched.Select(x => x.Date);

            //Get crew list
            var empCrews = specificEmpSched.Select(x => x.Crew);

            //Get Operation's job schedules
            var AllSchedules = db.JobSchedules;
            var jobSchedules = AllSchedules.Where(x => x.Date >= DateTime.Today && x.Operation == operation);

            var matchJobSchedules = new List<JobSchedule>();

            //Narrow job Schedules to employee matches
            foreach (var empSched in specificEmpSched)
            {
                var matches = jobSchedules.Where(x => x.Date == empSched.Date && x.Crew == empSched.Crew);
                matchJobSchedules.AddRange(matches);
            }

            //Desired results are any crew members (employee schedules) for the specific set of dates and crews
            var result = new List<EmployeeSchedule>();

            foreach (var jobSched in matchJobSchedules)
            {
                var matches = empSchedules.Where(x => x.Date == jobSched.Date && x.Crew == jobSched.Crew);
                result.AddRange(matches);
            }

            return result;
        }
    }
}
