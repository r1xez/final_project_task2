using System;
using System.Collections.Generic;
using System.Linq;

public static class QuizManager
{
    private static List<QuizResult> results = FileManager.LoadResults();

    private static Dictionary<string, List<Question>> quizzes = new Dictionary<string, List<Question>>
    {
        { "History", new List<Question>
            {
                new Question { Text = "Who was the first president of the United States?", Options = new List<string> { "George Washington", "Abraham Lincoln", "Thomas Jefferson", "John Adams" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What year did World War II end?", Options = new List<string> { "1943", "1945", "1947", "1950" }, CorrectAnswers = new List<int> { 2 } }
            }
        },
        { "Geography", new List<Question>
            {
                new Question { Text = "What is the capital of France?", Options = new List<string> { "Paris", "London", "Berlin", "Madrid" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Which continent is the largest?", Options = new List<string> { "Asia", "Africa", "North America", "Europe" }, CorrectAnswers = new List<int> { 1 } }
            }
        },
        { "Biology", new List<Question>
            {
                new Question { Text = "What is the powerhouse of the cell?", Options = new List<string> { "Nucleus", "Ribosome", "Mitochondria", "Chloroplast" }, CorrectAnswers = new List<int> { 3 } },
                new Question { Text = "What is the process by which plants make their food?", Options = new List<string> { "Respiration", "Photosynthesis", "Fermentation", "Digestion" }, CorrectAnswers = new List<int> { 2 } }
            }
        }
    };

    public static void ShowTopResults()
    {
        var topResults = results.OrderByDescending(r => r.CorrectAnswers).Take(20);
        Console.WriteLine("\nTop 20 Results:");
        foreach (var result in topResults)
        {
            Console.WriteLine($"{result.Username}: {result.CorrectAnswers} correct answers ({result.QuizCategory})");
        }
    }

    public static void StartQuiz(User user)
    {
        Console.WriteLine("\nAvailable categories:");
        foreach (var category in quizzes.Keys)
        {
            Console.WriteLine($"- {category}");
        }
        Console.Write("Choose a category: ");
        string chosenCategory = Console.ReadLine();

        if (!quizzes.ContainsKey(chosenCategory))
        {
            Console.WriteLine("Invalid category!");
            return;
        }

        List<Question> questions = quizzes[chosenCategory];
        int correctAnswers = 0;

        foreach (var question in questions)
        {
            Console.WriteLine("\n" + question.Text);
            for (int i = 0; i < question.Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Options[i]}");
            }

            Console.Write("Your answer (comma separated if multiple): ");
            string[] userAnswers = Console.ReadLine().Split(',');

            List<int> userAnswersInt = new List<int>();
            foreach (var answer in userAnswers)
            {
                if (int.TryParse(answer.Trim(), out int num))
                {
                    userAnswersInt.Add(num);
                }
            }

            if (userAnswersInt.OrderBy(a => a).SequenceEqual(question.CorrectAnswers.OrderBy(a => a)))
            {
                correctAnswers++;
            }
        }

        Console.WriteLine($"\nQuiz finished! You got {correctAnswers}/{questions.Count} correct.");

        QuizResult result = new QuizResult
        {
            Username = user.Username,
            QuizCategory = chosenCategory,
            CorrectAnswers = correctAnswers,
            Date = DateTime.Now
        };

        results.Add(result);
        FileManager.SaveResults(results);
    }
}
