using System;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonDb personDb = new PersonDb ("Data Source=localhost;Initial Catalog=Lidl;User ID=UserLidl;Password=123;Encrypt=False;TrustServerCertificate=True;");

            Console.WriteLine("Enter the ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter the birth date (yyyy-MM-dd):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            personDb.AddPerson(id, firstName, lastName, birthDate);

            Console.WriteLine("Person added successfully!");
        }
    }
}
