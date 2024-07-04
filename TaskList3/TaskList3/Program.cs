using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskList3

{ internal class Program
{

        static string connectionString = @"Data Source=WIN-U2JKJ34RRUI\SSQLSERVER;Initial Catalog=EmployeeDB;Integrated Security=True";
        static void Main(string[] args)
        {
        EmployeeManager user = new EmployeeManager();
            //user.InsertEmployee("Igor", "Chort", "lox", 4000);
            //user.UpdateEmployee(8);
            //user.DeleteEmployee(8);
            EmployeeManagerLINQ employee = new EmployeeManagerLINQ();
            //employee.InsertEmployeeLINQ("Igor", "Chort", "lox", 4000);
            //employee.UpdateEmployeeLINQ(10);
            //employee.DeleteEmployeeLINQ(10);
            employee.ReadEmployeesLINQ();
            //user.ReadEmployees();

           // using(SqlConnection con = new SqlConnection(connectionString))
            {
               // string command = "INSERT INTO Employees VALUES('Igor' , 'Palchuk', 'manager', 5000)";
               // con.Open();
               // SqlCommand cmd = new SqlCommand(command, con);
               // int number =  cmd.ExecuteNonQuery();
               // Console.WriteLine(number);

               // string update = "UPDATE Employees SET Salary = 2000";
               // cmd = new SqlCommand(update, con);
                // int number = cmd.ExecuteNonQuery();
                //Console.WriteLine(number);

               // string delete = "DELETE Employees WHERE EmployeeId = 1";
              //  cmd = new SqlCommand(delete, con);
               // int number = cmd.ExecuteNonQuery();
               // Console.WriteLine(number);

              //  string retrieve = "SELECT * FROM Employees";
              //  cmd = new SqlCommand(retrieve, con);
              //  var reader = cmd.ExecuteReader();
              //
              //  if(reader.HasRows)
              //  {
              //      Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}");
              //      while(reader.Read())
              //      {
              //         int id = reader.GetInt32(0);
              //         string firstName = reader.GetString(1);
              //         string lastName = reader.GetString(2);
              //         string position = reader.GetString(3);
              //         int salary = reader.GetInt32(4);
              //         Console.WriteLine($"{id}\t{firstName}\t{lastName}\t{position}\t{salary}");
              //      }   
              //  }
              //  reader.Close();

              //  string proc = "sp_InsertUser";
              //  using (SqlCommand com = new SqlCommand(proc, con))
              //  {
              //      
              //      com.CommandType = System.Data.CommandType.StoredProcedure;
              //
              //      com.Parameters.Add(new SqlParameter("@firstName", "Alex"));
              //      com.Parameters.Add(new SqlParameter("@lastName", "Iwobi"));
              //      com.Parameters.Add(new SqlParameter("@position", "Engineer"));
              //      com.Parameters.Add(new SqlParameter("@salary", 5000));
              //
              //      com.ExecuteNonQuery();
              //  }
              //

              //  SqlTransaction transaction= con.BeginTransaction();
              //  SqlCommand sqlCommand = con.CreateCommand();
              //  sqlCommand.Transaction = transaction;
              //
              //  try
              //  {
              //      sqlCommand.CommandText = "INSERT INTO Employees VALUES('Daniel', 'Wilson', 'Administrator', 52000)";
              //      sqlCommand.ExecuteNonQuery();
              //
              //      sqlCommand.CommandText = "INSERT INTO Employees VALUES('Michael', 'Brown', 'Designer', 45000)";
              //      sqlCommand.ExecuteNonQuery();
              //
              //      transaction.Commit();
              //      Console.WriteLine("Inserted");
              //
              //  }
              //  catch (Exception ex)
              //  {
              //      Console.WriteLine(ex.Message);
              //      transaction.Rollback();
              //  }
              //

            }

        }
    }
}
