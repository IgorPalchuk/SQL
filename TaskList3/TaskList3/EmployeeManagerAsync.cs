using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList3
{
    internal class EmployeeManagerAsync
    {
        static string connectionString = @"Data Source=WIN-U2JKJ34RRUI\SSQLSERVER;Initial Catalog=EmployeeDB;Integrated Security=True";
        public async Task InsertEmployeeAsync(string firstName, string lastName, string position, int salary)
        {
            string sqlExpression = "INSERT INTO Employees(FirstName, LastName, Position, Salary) VALUES (@firstName,@lastName,@position,@salary)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand(sqlExpression, con);
                cmd.Parameters.Add(new SqlParameter("@firstName", firstName));
                cmd.Parameters.Add(new SqlParameter("@lastName", lastName));
                cmd.Parameters.Add(new SqlParameter("@position", position));
                cmd.Parameters.Add(new SqlParameter("@salary", salary));
                int number = await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"{number} rows affected");
            }

        }
        public async Task UpdateEmployeeAsync(int Id)
        {
            Console.WriteLine("Write new salary: ");
            int salary = int.Parse(Console.ReadLine());
            string sqlExpression = $"UPDATE Employees SET Salary = @salary WHERE EmployeeID = @Id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand(sqlExpression, con);
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.Parameters.Add(new SqlParameter("@salary", salary));
                int number = await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"{number} rows updated");
            }

        }
        public async Task DeleteEmployeeAsync(int Id)
        {

            string sqlExpression = $"DELETE Employees WHERE EmployeeID = @Id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand(sqlExpression, con);
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                int number = await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"{number} rows deleted");
            }

        }
        public async Task ReadEmployees()
        {
            string sqlExpression = "SELECT * FROM Employees";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand(sqlExpression, con);
                var reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}");
                    while (await reader.ReadAsync())
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
