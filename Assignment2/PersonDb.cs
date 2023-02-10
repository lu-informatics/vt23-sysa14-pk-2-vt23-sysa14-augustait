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
        private string _connectionString;

        public PersonDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPerson(int id, string firstName, string lastName, DateTime birthDate)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
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