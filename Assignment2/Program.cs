using Assignment2;
using System;
using static Assignment2.PersonDb;

class Program
{
    static PersonDb personDb = new PersonDb();

    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to the Person Management System");

        while (true)
        {
            Console.WriteLine("\n Please select an action:");
            Console.WriteLine("1. Add person");
            Console.WriteLine("2. Find person");
            Console.WriteLine("3. Update person");
            Console.WriteLine("4. Delete person");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");
            int choice = 0;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddPerson();
                        break;
                    case 2:
                        FindPerson();
                        break;
                    case 3:
                        UpdatePerson();
                        break;
                    case 4:
                        DeletePerson();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }

    static void AddPerson()
    {
        Console.Write("\nEnter person ID: ");
        int id = int.MinValue;
        while (!int.TryParse(Console.ReadLine(), out id) || personDb.FindPerson(id) != null || id < 0)
        {
            Console.WriteLine("Invalid input, either the ID is not a valid positive number or it already exists.");
            Console.Write("Enter person ID: ");
        }

        
    Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(firstName) || firstName.Any(char.IsDigit))
        {
            Console.WriteLine("Invalid input, first name cannot be empty or contain digits.");
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
        }

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(lastName) || lastName.Any(char.IsDigit))
        {
            Console.WriteLine("Invalid input, last name cannot be empty or contain digits.");
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();
        }

        Console.Write("Enter birth date (YYYY-MM-DD): ");
        DateTime birthDate = DateTime.MinValue;
        while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
        {
            Console.WriteLine("Invalid input, enter a valid birth date (YYYY-MM-DD).");
            Console.Write("Enter birth date (YYYY-MM-DD): ");
        }

        personDb.AddPerson(id, firstName, lastName, birthDate);
        Console.WriteLine("Person added successfully.");
    }

    static void FindPerson()
    {
        Console.Write("\nEnter person ID: ");
        int id = int.MinValue;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input, ID must be a number.");
            Console.Write("Enter person ID: ");
        }

        Person person = personDb.FindPerson(id);
        if (person == null)
        {
            Console.WriteLine("Person not found");
        }
        else
        {
            Console.WriteLine($"ID: {person.Id}");
            Console.WriteLine($"First name: {person.FirstName}");
            Console.WriteLine($"Last name: {person.LastName}");
            Console.WriteLine($"Birth date: {person.BirthDate:yyyy-MM-dd}");
        }
    }
    static void UpdatePerson()
    {
        Console.Write("\nEnter person ID: ");
        int id;
        try
        {
            id = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number for the person ID.");
            return;
        }

        Person person = personDb.FindPerson(id);
        if (person == null)
        {
            Console.WriteLine("Person not found");
            return;
        }

        Console.Write("Enter new first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter new last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter new birth date (YYYY-MM-DD): ");
        try
        {
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            personDb.UpdatePerson(id, firstName, lastName, birthDate);
            Console.WriteLine("Person updated successfully.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid date in the format YYYY-MM-DD.");
            return;
        }
    }

    static void DeletePerson()
        {
            Console.Write("\nEnter person ID: ");
            int id = int.Parse(Console.ReadLine());

            Person person = personDb.FindPerson(id);
            if (person == null)
            {
                Console.WriteLine("Person not found");
                return;
            }

            Console.Write("Are you sure you want to delete this person (y/n)? ");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "yes")
            {
                personDb.DeletePerson(id);
                Console.WriteLine("Person deleted");
            }
            else
            {
                Console.WriteLine("Deletion cancelled");
            }
        }
    }
