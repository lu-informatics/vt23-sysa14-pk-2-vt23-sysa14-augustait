using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class PersonDb
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=Lidl;User ID=UserLidl;Password=123;Encrypt=False;TrustServerCertificate=True;";
        // private string connectionString = "Data Source=localhost;Initial Catalog=Lidl;User ID=UserLidl;Password=123;";

        public PersonDb(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddPerson(int id, string firstName, string lastName, DateTime birthDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Person (id, first_name, last_name, birth_date) VALUES (@id, @firstName, @lastName, @birthDate)", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@birthDate", birthDate);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}