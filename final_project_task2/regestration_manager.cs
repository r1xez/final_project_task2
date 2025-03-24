using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public static class RegistrationManager
{
    private static List<User> users = FileManager.LoadUsers();
    private const string AdminPasswordHash = "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg="; 

    public static bool VerifyAdminPassword(string password)
    {
        return HashPassword(password) == AdminPasswordHash;
    }

    public static User Login()
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        string hash = HashPassword(password);
        return users.Find(u => u.Username == username && u.PasswordHash == hash);
    }

    public static User Register()
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        if (users.Exists(u => u.Username == username))
        {
            Console.WriteLine("This username is already taken!");
            return null;
        }

        Console.Write("Password: ");
        string password = Console.ReadLine();

        DateTime birthDate;
        while (true)
        {
            Console.Write("Birth Date (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                break;
            Console.WriteLine("Invalid date format. Please try again.");
        }

        User newUser = new User
        {
            Username = username,
            PasswordHash = HashPassword(password),
            BirthDate = birthDate
        };

        users.Add(newUser);
        FileManager.SaveUsers(users);

        return newUser;
    }

    public static void ChangePassword(User user)
    {
        Console.Write("Current password: ");
        string currentPassword = Console.ReadLine();

        if (HashPassword(currentPassword) != user.PasswordHash)
        {
            Console.WriteLine("Incorrect current password!");
            return;
        }

        Console.Write("New password: ");
        string newPassword = Console.ReadLine();

        user.PasswordHash = HashPassword(newPassword);
        FileManager.SaveUsers(users);
        Console.WriteLine("Password changed successfully!");
    }

    public static void ChangeBirthDate(User user)
    {
        Console.Write("Enter new birth date (yyyy-mm-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
        {
            user.BirthDate = newDate;
            FileManager.SaveUsers(users);
            Console.WriteLine("Birth date updated successfully!");
        }
        else
        {
            Console.WriteLine("Invalid date format.");
        }
    }

    private static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}