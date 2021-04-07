using System.Collections;
using System.Collections.Generic;

public class Question
{
    public string question;
    public string buttonName;
    public List<string> answers = new List<string>();

    public void SetQuestion(string a) { question = a; }
    public string GetQuestion() { return question; }
    public void AddAnswer(string answ) { answers.Add(answ); }
    public List<string> GetAnswers() { return answers; }
    public void RemoveLastAnswer() { answers.RemoveAt(answers.Count - 1); }
    public void RemoveAnswerAt(int i) { answers.RemoveAt(i); }
}
