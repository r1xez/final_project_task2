using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0 && args[0] == "--admin")
        {
            AdminConsole.RunAdminTool();
            return;
        }

        Console.WriteLine("Welcome to the Quiz App!");
        User currentUser = null;

        while (currentUser == null)
        {
            Console.WriteLine("\n1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Choose option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    currentUser = RegistrationManager.Login();
                    if (currentUser == null)
                        Console.WriteLine("Invalid credentials. Try again.");
                    break;
                case "2":
                    currentUser = RegistrationManager.Register();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        bool isAdmin = currentUser.Username == "admin";

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Start New Quiz");
            Console.WriteLine("2. View My Results");
            Console.WriteLine("3. View Top 20 Results");
            Console.WriteLine("4. Change Password");
            Console.WriteLine("5. Change Birth Date");
            if (isAdmin) Console.WriteLine("6. Admin: Add/Edit Quiz");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    QuizManager.StartQuiz(currentUser);
                    break;
                case "2":
                    QuizManager.ShowUserResults(currentUser);
                    break;
                case "3":
                    Console.Write("Enter category: ");
                    string category = Console.ReadLine();
                    QuizManager.ShowTopResults(category);
                    break;
                case "4":
                    RegistrationManager.ChangePassword(currentUser);
                    break;
                case "5":
                    RegistrationManager.ChangeBirthDate(currentUser);
                    break;
                case "6" when isAdmin:
                    QuizManager.AdminAddQuiz();
                    break;
                case "0":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}