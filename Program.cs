using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MSSQLDiagnosis
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            string queryString = ConfigurationManager.AppSettings["SQLStatement"];

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    var count = command.ExecuteScalar();
                    Console.WriteLine("Everything seems good. Record count for query is {0}", count);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Click any key to close.");
                Console.ReadLine();
            }
        }
    }
}
