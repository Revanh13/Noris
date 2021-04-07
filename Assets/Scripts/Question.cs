using System.Collections;
using System.Collections.Generic;

public class Question
{
    public string question;
    public string buttonName;
    public List<string> answers = new List<string>();

    public void SetQuestion(string a) { question = a; }
    public string GetQuestion() { return question; }
    public void SetButtonName(string a) { buttonName = a; }
    public string GetButtonName() { return buttonName; }
    public void SetAnswer(string answ) { answers.Add(answ); }
    public void SetAnswers(List<string> a) {}
    public List<string> GetAnswers() { return answers; }
    public void RemoveLastAnswer() { answers.RemoveAt(answers.Count - 1); }
    public void RemoveAnswerAt(int i) { answers.RemoveAt(i); }
}
