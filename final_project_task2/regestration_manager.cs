using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public static class RegistrationManager
{
    private static List<User> users = FileManager.LoadUsers();

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
        Console.Write("Birth Date (yyyy-mm-dd): ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());

        User newUser = new User { Username = username, PasswordHash = HashPassword(password), BirthDate = birthDate };
        users.Add(newUser);
        FileManager.SaveUsers(users);

        return newUser;
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
