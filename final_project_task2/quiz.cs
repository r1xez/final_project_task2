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
                new Question { Text = "Who was the first president of the United States?", Options = new List<string> { "George Washington", "Abraham Lincoln", "Thomas Jefferson", "John Adams" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What year did World War II end?", Options = new List<string> { "1943", "1945", "1947", "1950" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Who was the last president of the Soviet Union?", Options = new List<string> { "Mikhail Gorbachev", "Boris Yeltsin", "Joseph Stalin", "Vladimir Putin" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "Which empire was ruled by Julius Caesar?", Options = new List<string> { "Roman Empire", "Ottoman Empire", "Mongol Empire", "Byzantine Empire" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "In which year did the Titanic sink?", Options = new List<string> { "1900", "1912", "1925", "1931" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Who was the first human to journey into outer space?", Options = new List<string> { "Neil Armstrong", "Yuri Gagarin", "John Glenn", "Valentina Tereshkova" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What was the main cause of the American Civil War?", Options = new List<string> { "Slavery", "Imperialism", "The economy", "Taxes" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "Which country was the first to grant women the right to vote?", Options = new List<string> { "New Zealand", "United States", "United Kingdom", "Canada" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "Which war ended with the Treaty of Versailles?", Options = new List<string> { "World War I", "World War II", "American Civil War", "Napoleonic Wars" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "In what year did the Berlin Wall fall?", Options = new List<string> { "1987", "1989", "1991", "1995" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Which ancient civilization built the pyramids?", Options = new List<string> { "Mesopotamia", "Egypt", "Greece", "Rome" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Who was the first emperor of China?", Options = new List<string> { "Qin Shi Huang", "Genghis Khan", "Emperor Wu", "Tang Taizong" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "Which event started World War I?", Options = new List<string> { "Assassination of Archduke Franz Ferdinand", "Invasion of Poland", "Bombing of Pearl Harbor", "Attack on France" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What year did the French Revolution begin?", Options = new List<string> { "1789", "1799", "1776", "1804" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "Which battle was the turning point in the American Revolution?", Options = new List<string> { "Battle of Bunker Hill", "Battle of Saratoga", "Battle of Gettysburg", "Battle of Yorktown" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Who discovered America?", Options = new List<string> { "Christopher Columbus", "Leif Erikson", "Marco Polo", "Ferdinand Magellan" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "Which country did the United States gain independence from?", Options = new List<string> { "France", "Spain", "Great Britain", "Mexico" }, CorrectAnswers = new List<int> { 2 } },
                new Question { Text = "Who was the leader of Nazi Germany during World War II?", Options = new List<string> { "Adolf Hitler", "Joseph Stalin", "Benito Mussolini", "Winston Churchill" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "Which event marked the end of the Cold War?", Options = new List<string> { "The fall of the Berlin Wall", "The collapse of the Soviet Union", "The Cuban Missile Crisis", "The Korean War" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What year did World War I start?", Options = new List<string> { "1912", "1914", "1916", "1918" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Which country was ruled by Alexander the Great?", Options = new List<string> { "Greece", "Persia", "Macedonia", "Rome" }, CorrectAnswers = new List<int> { 2 } }
            }
        },

        { "Geography", new List<Question>
            {
                new Question { Text = "What is the capital of France?", Options = new List<string> { "Paris", "London", "Berlin", "Madrid" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "Which continent is the largest?", Options = new List<string> { "Asia", "Africa", "North America", "Europe" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What is the longest river in the world?", Options = new List<string> { "Amazon River", "Nile River", "Yangtze River", "Mississippi River" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Which country has the most population?", Options = new List<string> { "India", "China", "United States", "Russia" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What is the smallest country in the world?", Options = new List<string> { "Monaco", "San Marino", "Vatican City", "Liechtenstein" }, CorrectAnswers = new List<int> { 2 } },
                new Question { Text = "Which country is known as the Land of the Rising Sun?", Options = new List<string> { "China", "Japan", "South Korea", "Thailand" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Which country is the Sahara Desert located in?", Options = new List<string> { "Egypt", "Morocco", "Saudi Arabia", "All of the above" }, CorrectAnswers = new List<int> { 3 } },
                new Question { Text = "What is the capital of Canada?", Options = new List<string> { "Ottawa", "Toronto", "Montreal", "Vancouver" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What is the largest ocean in the world?", Options = new List<string> { "Atlantic Ocean", "Indian Ocean", "Arctic Ocean", "Pacific Ocean" }, CorrectAnswers = new List<int> { 3 } },
                new Question { Text = "Which country is known for the Great Barrier Reef?", Options = new List<string> { "United States", "Australia", "Brazil", "Egypt" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What is the highest mountain in the world?", Options = new List<string> { "Mount Kilimanjaro", "Mount Everest", "Mount Fuji", "K2" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Which country has the most islands?", Options = new List<string> { "Sweden", "Canada", "United States", "Indonesia" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What is the longest river in South America?", Options = new List<string> { "Amazon River", "Orinoco River", "Parana River", "Magdalena River" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "Which city is known as the City of Love?", Options = new List<string> { "Rome", "Paris", "New York", "Venice" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Which continent is known as the 'Dark Continent'?", Options = new List<string> { "Africa", "Asia", "Europe", "South America" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "Which country is the Eiffel Tower located in?", Options = new List<string> { "Italy", "France", "Germany", "United Kingdom" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "Which continent has the most countries?", Options = new List<string> { "Africa", "Asia", "Europe", "North America" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What is the capital of Japan?", Options = new List<string> { "Beijing", "Seoul", "Tokyo", "Hanoi" }, CorrectAnswers = new List<int> { 2 } }
            }
        },

        { "Mathematics", new List<Question>
            {
                new Question { Text = "What is 5 + 7?", Options = new List<string> { "10", "12", "13", "14" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What is the square root of 64?", Options = new List<string> { "6", "7", "8", "9" }, CorrectAnswers = new List<int> { 2 } },
                new Question { Text = "What is 12 x 11?", Options = new List<string> { "120", "132", "140", "144" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What is the value of pi?", Options = new List<string> { "3.14", "3.15", "3.13", "3.16" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What is 15 ÷ 3?", Options = new List<string> { "4", "5", "6", "7" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What is the value of 2^3?", Options = new List<string> { "6", "8", "10", "12" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What is 3 + 3 x 3?", Options = new List<string> { "12", "9", "18", "15" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What is 20 ÷ 4 + 5?", Options = new List<string> { "10", "15", "12", "20" }, CorrectAnswers = new List<int> { 2 } },
                new Question { Text = "What is the perimeter of a square with side length 5?", Options = new List<string> { "10", "15", "20", "25" }, CorrectAnswers = new List<int> { 2 } },
                new Question { Text = "What is the area of a rectangle with length 4 and width 6?", Options = new List<string> { "24", "20", "12", "10" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What is the formula for the area of a circle?", Options = new List<string> { "πr^2", "2πr", "πd", "πd^2" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What is the square of 9?", Options = new List<string> { "81", "18", "27", "72" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What is 100 ÷ 5?", Options = new List<string> { "20", "25", "30", "35" }, CorrectAnswers = new List<int> { 1 } },
                new Question { Text = "What is 3 x (2 + 4)?", Options = new List<string> { "12", "15", "18", "21" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What is the value of 7²?", Options = new List<string> { "49", "56", "63", "72" }, CorrectAnswers = new List<int> { 0 } },
                new Question { Text = "What is the sum of the angles in a triangle?", Options = new List<string> { "180°", "90°", "360°", "270°" }, CorrectAnswers = new List<int> { 0 } }
            }
        }
    };

    public static void ShowTopResults(string category)
    {
        var topResults = results.Where(r => r.QuizCategory == category)
                               .OrderByDescending(r => r.CorrectAnswers)
                               .ThenBy(r => r.Date)
                               .Take(20);

        Console.WriteLine($"\nTop 20 Results for {category}:");
        int position = 1;
        foreach (var result in topResults)
        {
            Console.WriteLine($"{position}. {result.Username}: {result.CorrectAnswers} correct answers on {result.Date:yyyy-MM-dd}");
            position++;
        }
    }

    public static void StartQuiz(User user)
    {
        Console.WriteLine("\nAvailable categories:");
        foreach (var category in quizzes.Keys)
        {
            Console.WriteLine($"- {category}");
        }
        Console.WriteLine("- Mixed (random questions from all categories)");
        Console.Write("Choose a category: ");
        string chosenCategory = Console.ReadLine();

        List<Question> questionsToAsk = new List<Question>();

        if (chosenCategory.Equals("Mixed", StringComparison.OrdinalIgnoreCase))
        {
            var allQuestions = quizzes.Values.SelectMany(x => x).ToList();
            var random = new Random();
            questionsToAsk = allQuestions.OrderBy(x => random.Next()).Take(20).ToList();
            chosenCategory = "Mixed";
        }
        else if (quizzes.ContainsKey(chosenCategory))
        {
            questionsToAsk = quizzes[chosenCategory].Take(20).ToList();
        }
        else
        {
            Console.WriteLine("Invalid category!");
            return;
        }

        int correctAnswers = 0;
        int questionNumber = 1;

        foreach (var question in questionsToAsk)
        {
            Console.WriteLine($"\nQuestion {questionNumber}/{questionsToAsk.Count}");
            Console.WriteLine(question.Text);
            for (int i = 0; i < question.Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Options[i]}");
            }

            Console.Write("Your answer (comma separated if multiple): ");
            string[] userAnswers = Console.ReadLine().Split(',');

            List<int> userAnswersInt = new List<int>();
            foreach (var answer in userAnswers)
            {
                if (int.TryParse(answer.Trim(), out int num) && num > 0 && num <= question.Options.Count)
                {
                    userAnswersInt.Add(num - 1); 
                }
            }

            if (userAnswersInt.OrderBy(a => a).SequenceEqual(question.CorrectAnswers.OrderBy(a => a)))
            {
                correctAnswers++;
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            questionNumber++;
        }

        Console.WriteLine($"\nQuiz finished! You got {correctAnswers}/{questionsToAsk.Count} correct.");

        QuizResult result = new QuizResult
        {
            Username = user.Username,
            QuizCategory = chosenCategory,
            CorrectAnswers = correctAnswers,
            Date = DateTime.Now
        };

        results.Add(result);
        FileManager.SaveResults(results);

        ShowUserPosition(result);
    }

    private static void ShowUserPosition(QuizResult result)
    {
        var categoryResults = results
            .Where(r => r.QuizCategory == result.QuizCategory)
            .OrderByDescending(r => r.CorrectAnswers)
            .ThenBy(r => r.Date)
            .ToList();

        int position = categoryResults.FindIndex(r =>
            r.Username == result.Username &&
            r.Date == result.Date) + 1;

        Console.WriteLine($"Your position in {result.QuizCategory} category: {position}");
    }

    public static void ShowUserResults(User user)
    {
        var userResults = results
            .Where(r => r.Username == user.Username)
            .OrderByDescending(r => r.Date);

        Console.WriteLine($"\nYour Quiz Results:");
        foreach (var result in userResults)
        {
            Console.WriteLine($"{result.QuizCategory}: {result.CorrectAnswers} correct answers on {result.Date:yyyy-MM-dd}");
        }
    }

    public static void AdminAddQuiz()
    {
        Console.WriteLine("\nEnter Quiz Category:");
        string category = Console.ReadLine();

        if (quizzes.ContainsKey(category))
        {
            Console.WriteLine("This category already exists. Do you want to add questions to it? (Y/N)");
            if (Console.ReadLine().ToUpper() != "Y")
            {
                return;
            }
        }
        else
        {
            quizzes[category] = new List<Question>();
        }

        while (true)
        {
            Console.WriteLine("\nEnter question text (or 'done' to finish):");
            string questionText = Console.ReadLine();
            if (questionText.ToLower() == "done") break;

            Console.WriteLine("Enter options separated by '|':");
            string optionsInput = Console.ReadLine();
            List<string> options = optionsInput.Split('|').ToList();

            Console.WriteLine("Enter correct answer numbers (comma separated, 1-based index):");
            string answersInput = Console.ReadLine();
            List<int> correctAnswers = answersInput.Split(',')
                .Select(int.Parse)
                .Select(x => x - 1) 
                .ToList();

            quizzes[category].Add(new Question
            {
                Text = questionText,
                Options = options,
                CorrectAnswers = correctAnswers
            });
        }

        FileManager.SaveQuizzes(quizzes);
        Console.WriteLine("Quiz saved successfully!");
    }
}