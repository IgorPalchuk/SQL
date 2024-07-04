using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaskList3
{
    public class EmployeeManager
    {
        static string connectionString = @"Data Source=WIN-U2JKJ34RRUI\SSQLSERVER;Initial Catalog=EmployeeDB;Integrated Security=True";
        public void InsertEmployee(string firstName, string lastName, string position, int salary)
        {
            string sqlExpression = "INSERT INTO Employees(FirstName, LastName, Position, Salary) VALUES (@firstName,@lastName,@position,@salary)";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, con);
                cmd.Parameters.Add(new SqlParameter("@firstName", firstName));
                cmd.Parameters.Add(new SqlParameter("@lastName", lastName));
                cmd.Parameters.Add(new SqlParameter("@position", position));
                cmd.Parameters.Add(new SqlParameter("@salary", salary));
                int number = cmd.ExecuteNonQuery();
                Console.WriteLine($"{number} rows affected");
            }
           
        }
        public void UpdateEmployee(int Id)
        {
            Console.WriteLine("Write new salary: ");
            int salary = int.Parse(Console.ReadLine());
            string sqlExpression = $"UPDATE Employees SET Salary = @salary WHERE EmployeeID = @Id";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand( sqlExpression, con);
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.Parameters.Add(new SqlParameter("@salary", salary));
                int number = cmd.ExecuteNonQuery();
                Console.WriteLine($"{number} rows updated");
            }
            
        }
        public void DeleteEmployee(int Id)
        {
            
            string sqlExpression = $"DELETE Employees WHERE EmployeeID = @Id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, con);
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                int number = cmd.ExecuteNonQuery();
                Console.WriteLine($"{number} rows deleted");
            }

        }
        public void ReadEmployees()
        {
            string sqlExpression = "SELECT * FROM Employees";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, con);
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}");
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        string firstName = reader.GetString(1);
                        string lastName = reader.GetString(2);
                        string position = reader.GetString(3);
                        int salary = reader.GetInt32(4);
                        Console.WriteLine($"{Id}\t{firstName}\t{lastName}\t{position}\t{salary}");
                    }
                    reader.Close();
                }
            }

        }
    }
}
