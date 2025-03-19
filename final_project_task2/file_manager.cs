using System;
using System.Collections.Generic;
using System.IO;

public static class FileManager
{
    private static readonly string usersFile = "users.txt";
    private static readonly string resultsFile = "results.txt";

    public static void SaveUsers(List<User> users)
    {
        using (StreamWriter writer = new StreamWriter(usersFile))
        {
            foreach (var user in users)
            {
                writer.WriteLine($"{user.Username}|{user.PasswordHash}|{user.BirthDate:yyyy-MM-dd}");
            }
        }
    }

    public static List<User> LoadUsers()
    {
        List<User> users = new List<User>();
        if (File.Exists(usersFile))
        {
            foreach (var line in File.ReadAllLines(usersFile))
            {
                string[] parts = line.Split('|');
                users.Add(new User { Username = parts[0], PasswordHash = parts[1], BirthDate = DateTime.Parse(parts[2]) });
            }
        }
        return users;
    }

    public static void SaveResults(List<QuizResult> results)
    {
        using (StreamWriter writer = new StreamWriter(resultsFile))
        {
            foreach (var result in results)
            {
                writer.WriteLine($"{result.Username}|{result.QuizCategory}|{result.CorrectAnswers}|{result.Date:yyyy-MM-dd HH:mm:ss}");
            }
        }
    }

    public static List<QuizResult> LoadResults()
    {
        List<QuizResult> results = new List<QuizResult>();
        if (File.Exists(resultsFile))
        {
            foreach (var line in File.ReadAllLines(resultsFile))
            {
                string[] parts = line.Split('|');
                results.Add(new QuizResult
                {
                    Username = parts[0],
                    QuizCategory = parts[1],
                    CorrectAnswers = int.Parse(parts[2]),
                    Date = DateTime.Parse(parts[3])
                });
            }
        }
        return results;
    }
}
