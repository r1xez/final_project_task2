using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class FileManager
{
    private static readonly string usersFile = "users.txt";
    private static readonly string resultsFile = "results.txt";
    private static readonly string quizzesFile = "quizzes.txt";

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
                if (parts.Length == 3)
                {
                    users.Add(new User
                    {
                        Username = parts[0],
                        PasswordHash = parts[1],
                        BirthDate = DateTime.Parse(parts[2])
                    });
                }
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
                if (parts.Length == 4)
                {
                    results.Add(new QuizResult
                    {
                        Username = parts[0],
                        QuizCategory = parts[1],
                        CorrectAnswers = int.Parse(parts[2]),
                        Date = DateTime.Parse(parts[3])
                    });
                }
            }
        }
        return results;
    }

    public static void SaveQuizzes(Dictionary<string, List<Question>> quizzes)
    {
        using (StreamWriter writer = new StreamWriter(quizzesFile))
        {
            foreach (var quiz in quizzes)
            {
                writer.WriteLine($"==={quiz.Key}===");
                foreach (var question in quiz.Value)
                {
                    writer.WriteLine(question.Text);
                    writer.WriteLine(string.Join("|", question.Options));
                    writer.WriteLine(string.Join(",", question.CorrectAnswers));
                }
                writer.WriteLine("===END===");
            }
        }
    }

    public static Dictionary<string, List<Question>> LoadQuizzes()
    {
        Dictionary<string, List<Question>> quizzes = new Dictionary<string, List<Question>>();
        if (File.Exists(quizzesFile))
        {
            string[] lines = File.ReadAllLines(quizzesFile);
            string currentCategory = null;
            List<Question> currentQuestions = new List<Question>();
            Question currentQuestion = null;
            int lineType = 0; 

            foreach (var line in lines)
            {
                if (line.StartsWith("===") && line.EndsWith("==="))
                {
                    if (line != "===END===")
                    {
                        if (currentCategory != null && currentQuestions.Count > 0)
                        {
                            quizzes.Add(currentCategory, currentQuestions);
                        }
                        currentCategory = line.Trim('=');
                        currentQuestions = new List<Question>();
                    }
                    continue;
                }

                if (currentQuestion == null)
                {
                    currentQuestion = new Question { Text = line };
                    lineType = 2;
                }
                else if (lineType == 2)
                {
                    currentQuestion.Options = line.Split('|').ToList();
                    lineType = 3;
                }
                else if (lineType == 3)
                {
                    currentQuestion.CorrectAnswers = line.Split(',').Select(int.Parse).ToList();
                    currentQuestions.Add(currentQuestion);
                    currentQuestion = null;
                    lineType = 1;
                }
            }

            if (currentCategory != null && currentQuestions.Count > 0)
            {
                quizzes.Add(currentCategory, currentQuestions);
            }
        }
        return quizzes;
    }
}