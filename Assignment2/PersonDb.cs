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

        public PersonDb(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public PersonDb()
        {
        }

        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }

            public Person(int id, string firstName, string lastName, DateTime birthDate)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                BirthDate = birthDate;
            }
        }

        // METHOD - ADD PERSON
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

        // METHOD - FIND PERSON
        public Person FindPerson(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Person WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int foundId = (int)reader["id"];
                            string firstName = (string)reader["first_name"];
                            string lastName = (string)reader["last_name"];
                            DateTime birthDate = (DateTime)reader["birth_date"];

                            return new Person(foundId, firstName, lastName, birthDate);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        // METHOD - UPDATE PERSON
        public void UpdatePerson(int id, string firstName, string lastName, DateTime birthDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Person SET first_name = @firstName, last_name = @lastName, birth_date = @birthDate WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@birthDate", birthDate);

                    command.ExecuteNonQuery();
                }
            }
        }

        // METHOD - DELETE PERSON
        public void DeletePerson(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Person WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("No person was found with the specified ID.");
                    }
                    else
                    {
                        Console.WriteLine("Person was successfully deleted.");
                    }
                }
            }
        }


    }
}
