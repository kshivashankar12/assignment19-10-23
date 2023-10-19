using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Store person data");
            Console.WriteLine("2. Read person data");
            Console.WriteLine("3. Append one more record");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option (1/2/3/4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StorePersonData();
                    break;
                case "2":
                    ReadPersonData();
                    break;
                case "3":
                    AppendPersonData();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void StorePersonData()
    {
        try
        {
            using (StreamWriter file = new StreamWriter("person_data.txt"))
            {
                Console.Write("Enter the number of people you want to store data for: ");
                int personCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < personCount; i++)
                {
                    Console.Write("Enter person's name: ");
                    string personName = Console.ReadLine();
                    Console.Write("Enter person's address: ");
                    string personAddress = Console.ReadLine();
                    Console.Write("Enter city: ");
                    string city = Console.ReadLine();
                    Console.Write("Enter country: ");
                    string country = Console.ReadLine();

                    file.WriteLine($"{personName},{personAddress},{city},{country}");
                }

                Console.WriteLine("Data has been successfully stored in the file.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }

    static void ReadPersonData()
    {
        try
        {
            if (File.Exists("person_data.txt"))
            {
                using (StreamReader file = new StreamReader("person_data.txt"))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] personData = line.Split(',');
                        string personName = personData[0];
                        string personAddress = personData[1];
                        string city = personData[2];
                        string country = personData[3];

                        Console.WriteLine($"Name: {personName}");
                        Console.WriteLine($"Address: {personAddress}");
                        Console.WriteLine($"City: {city}");
                        Console.WriteLine($"Country: {country}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }

    static void AppendPersonData()
    {
        try
        {
            using (StreamWriter file = File.AppendText("person_data.txt"))
            {
                Console.Write("Enter person's name: ");
                string personName = Console.ReadLine();
                Console.Write("Enter person's address: ");
                string personAddress = Console.ReadLine();
                Console.Write("Enter city: ");
                string city = Console.ReadLine();
                Console.Write("Enter country: ");
                string country = Console.ReadLine();

                file.WriteLine($"{personName},{personAddress},{city},{country}");
                Console.WriteLine("Data has been successfully appended to the file.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
}
