using System;
using System.Collections.Generic;

public class User
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public DateTime BirthDate { get; set; }
}

public class QuizResult
{
    public string Username { get; set; }
    public string QuizCategory { get; set; }
    public int CorrectAnswers { get; set; }
    public DateTime Date { get; set; }
}

public class Question
{
    public string Text { get; set; }
    public List<string> Options { get; set; } = new List<string>();
    public List<int> CorrectAnswers { get; set; } = new List<int>();
}