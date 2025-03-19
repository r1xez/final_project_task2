using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Quiz!");
        User user = null;

        while (user == null)
        {
            Console.Write("1. Login\n2. Register\nChoose option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                user = RegistrationManager.Login();
                if (user == null) Console.WriteLine("Invalid credentials, try again.");
            }
            else if (choice == "2")
            {
                user = RegistrationManager.Register();
            }
        }

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Start Quiz");
            Console.WriteLine("2. Show My Results");
            Console.WriteLine("3. Show Top 20 Results");
            Console.WriteLine("4. Change Settings");
            Console.WriteLine("5. Exit");

            Console.Write("Your choice: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    QuizManager.StartQuiz(user);
                    break;
                case "2":
                    Console.WriteLine("Results will be implemented...");
                    break;
                case "3":
                    QuizManager.ShowTopResults();
                    break;
                case "4":
                    Console.WriteLine("Settings not implemented yet...");
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
