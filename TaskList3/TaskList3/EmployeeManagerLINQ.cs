using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace TaskList3
{
    [Table(Name = "Employees" )]    
    public class EmployeeManagerLINQ
    {
        static string connectionString = @"Data Source=WIN-U2JKJ34RRUI\SSQLSERVER;Initial Catalog=EmployeeDB;Integrated Security=True";
        [Column(IsPrimaryKey =true, IsDbGenerated = true)]
        public int EmployeeID { get; set; }
        [Column(Name = "FirstName")]
        public string FirstName { get; set; }
        [Column(Name = "LastName")]
        public string LastName { get; set; }
        [Column(Name = "Position")]
        public string Position { get; set; }
        [Column(Name = "Salary")]
        public int Salary { get; set; }

        public  void InsertEmployeeLINQ(string firstName, string lastName, string position, int salary)
        {
            DataContext dc = new DataContext(connectionString);
            EmployeeManagerLINQ employee = new EmployeeManagerLINQ { FirstName = firstName, LastName = lastName, Position = position, Salary = salary};
            dc.GetTable<EmployeeManagerLINQ>().InsertOnSubmit(employee);
            dc.SubmitChanges();
            Console.WriteLine($"Employee id : {employee.EmployeeID}");
        }
        public void UpdateEmployeeLINQ(int id)
        {
            DataContext dc = new DataContext(connectionString);
            EmployeeManagerLINQ employee =  dc.GetTable<EmployeeManagerLINQ>().First(x => x.EmployeeID == id);
            Console.WriteLine($"Write new salary for employee with {employee.EmployeeID} ID : ");
            int salary = int.Parse(Console.ReadLine());
            employee.Salary = salary;
            dc.SubmitChanges();
            Console.WriteLine($"{employee.EmployeeID}\t{employee.FirstName}\t{employee.LastName}\t{employee.Position}\t{employee.Salary}");
        }
        public void DeleteEmployeeLINQ(int id)
        {
            DataContext dc = new DataContext(connectionString);
            EmployeeManagerLINQ employeeOnDelete = dc.GetTable<EmployeeManagerLINQ>().First(x => x.EmployeeID == id);
            dc.GetTable<EmployeeManagerLINQ>().DeleteOnSubmit(employeeOnDelete);
            dc.SubmitChanges();
            Console.WriteLine($"{employeeOnDelete.EmployeeID}\t{employeeOnDelete.FirstName}\t{employeeOnDelete.LastName}\t{employeeOnDelete.Position}\t{employeeOnDelete.Salary}");
        }
        public void ReadEmployeesLINQ()
        {
            DataContext dc = new DataContext(connectionString);
            var employees = dc.GetTable<EmployeeManagerLINQ>();
            foreach ( var employee in employees )
            {
                Console.WriteLine($"{employee.EmployeeID}\t{employee.FirstName}\t{employee.LastName}\t{employee.Position}\t{employee.Salary}");
            }

        }


    }
}
