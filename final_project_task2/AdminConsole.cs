using System;
using System.Collections.Generic;
using System.Linq;

public static class AdminConsole
{
    public static void RunAdminTool()
    {
        Console.WriteLine("=== Admin Utility ===");

        if (!AuthenticateAdmin())
        {
            Console.WriteLine("Login failed. Access denied.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\nAdmin Menu:");
            Console.WriteLine("1. Add new quiz");
            Console.WriteLine("2. Edit existing quiz");
            Console.WriteLine("3. Delete quiz");
            Console.WriteLine("4. View all quizzes");
            Console.WriteLine("5. Exit");
            Console.Write("Choose option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    QuizManager.AdminAddQuiz();
                    break;
                case "2":
                    EditExistingQuiz();
                    break;
                case "3":
                    DeleteQuiz();
                    break;
                case "4":
                    ViewAllQuizzes();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    private static bool AuthenticateAdmin()
    {
        Console.Write("Admin username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        return username == "admin" && RegistrationManager.VerifyAdminPassword(password);
    }

    private static void EditExistingQuiz()
    {
        var quizzes = FileManager.LoadQuizzes();

        Console.WriteLine("\nAvailable quizzes:");
        foreach (var quizCategory in quizzes.Keys)
        {
            Console.WriteLine($"- {quizCategory} ({quizzes[quizCategory].Count} questions)");
        }

        Console.Write("\nEnter quiz name to edit: ");
        string categoryToEdit = Console.ReadLine();

        if (!quizzes.ContainsKey(categoryToEdit))
        {
            Console.WriteLine("Quiz not found!");
            return;
        }

        Console.WriteLine($"\nEditing quiz: {categoryToEdit}");
        Console.WriteLine("1. Add new question");
        Console.WriteLine("2. Delete question");
        Console.WriteLine("3. Edit question");
        Console.Write("Choose option: ");

        switch (Console.ReadLine())
        {
            case "1":
                AddQuestionToQuiz(categoryToEdit);
                break;
            case "2":
                DeleteQuestionFromQuiz(categoryToEdit);
                break;
            case "3":
                EditQuestionInQuiz(categoryToEdit);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private static void AddQuestionToQuiz(string category)
    {
        var quizzes = FileManager.LoadQuizzes();
        var questions = quizzes[category];

        Console.WriteLine("\nAdding new question:");
        Console.Write("Question text: ");
        string text = Console.ReadLine();

        Console.Write("Answer options (separated by '|'): ");
        var options = Console.ReadLine()?.Split('|').ToList() ?? new List<string>();

        Console.Write("Correct answers (numbers separated by comma, starting from 1): ");
        var correctAnswers = Console.ReadLine()?
            .Split(',')
            .Where(x => int.TryParse(x, out _))
            .Select(int.Parse)
            .Select(x => x - 1)
            .ToList() ?? new List<int>();

        questions.Add(new Question
        {
            Text = text,
            Options = options,
            CorrectAnswers = correctAnswers
        });

        quizzes[category] = questions;
        FileManager.SaveQuizzes(quizzes);
        Console.WriteLine("Question added successfully!");
    }

    private static void DeleteQuestionFromQuiz(string category)
    {
        var quizzes = FileManager.LoadQuizzes();
        var questions = quizzes[category];

        Console.WriteLine("\nQuestion list:");
        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {questions[i].Text}");
        }

        Console.Write("Enter question number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= questions.Count)
        {
            questions.RemoveAt(index - 1);
            quizzes[category] = questions;
            FileManager.SaveQuizzes(quizzes);
            Console.WriteLine("Question deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid question number!");
        }
    }

    private static void EditQuestionInQuiz(string category)
    {
        var quizzes = FileManager.LoadQuizzes();
        var questions = quizzes[category];

        Console.WriteLine("\nQuestion list:");
        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {questions[i].Text}");
        }

        Console.Write("Enter question number to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= questions.Count)
        {
            var question = questions[index - 1];

            Console.WriteLine("\nCurrent question:");
            Console.WriteLine($"Text: {question.Text}");
            Console.WriteLine($"Options: {string.Join(", ", question.Options)}");
            Console.WriteLine($"Correct answers: {string.Join(", ", question.CorrectAnswers.Select(x => x + 1))}");

            Console.WriteLine("\nEnter new data (leave empty to keep current):");
            Console.Write("New question text: ");
            string newText = Console.ReadLine();
            if (!string.IsNullOrEmpty(newText))
            {
                question.Text = newText;
            }

            Console.Write("New options (separated by '|'): ");
            string newOptions = Console.ReadLine();
            if (!string.IsNullOrEmpty(newOptions))
            {
                question.Options = newOptions.Split('|').ToList();
            }

            Console.Write("New correct answers (numbers separated by comma): ");
            string newAnswers = Console.ReadLine();
            if (!string.IsNullOrEmpty(newAnswers))
            {
                question.CorrectAnswers = newAnswers.Split(',')
                    .Where(x => int.TryParse(x, out _))
                    .Select(int.Parse)
                    .Select(x => x - 1)
                    .ToList();
            }

            quizzes[category] = questions;
            FileManager.SaveQuizzes(quizzes);
            Console.WriteLine("Question updated successfully!");
        }
        else
        {
            Console.WriteLine("Invalid question number!");
        }
    }

    private static void DeleteQuiz()
    {
        var quizzes = FileManager.LoadQuizzes();

        Console.WriteLine("\nAvailable quizzes:");
        foreach (var quizCategory in quizzes.Keys)
        {
            Console.WriteLine($"- {quizCategory}");
        }

        Console.Write("\nEnter quiz name to delete: ");
        string categoryToDelete = Console.ReadLine();

        if (quizzes.Remove(categoryToDelete))
        {
            FileManager.SaveQuizzes(quizzes);
            Console.WriteLine("Quiz deleted successfully!");
        }
        else
        {
            Console.WriteLine("Quiz not found!");
        }
    }

    private static void ViewAllQuizzes()
    {
        var quizzes = FileManager.LoadQuizzes();

        Console.WriteLine("\nList of all quizzes:");
        foreach (var category in quizzes.Keys)
        {
            Console.WriteLine($"\n=== {category} ===");
            foreach (var question in quizzes[category])
            {
                Console.WriteLine($"\nQuestion: {question.Text}");
                Console.WriteLine($"Options: {string.Join(", ", question.Options)}");
                Console.WriteLine($"Correct answers: {string.Join(", ", question.CorrectAnswers.Select(x => x + 1))}");
            }
        }
    }
}