using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NodeEditorFramework;

public class GameController : MonoBehaviour
{
    #region Variables
    [Header("Main lists")]
    public List<GameObject> questionButtons = new List<GameObject>(); // Лист с кнопками вопросов
    private List<Question> questions = new List<Question>();
    private int currentQuestion = 0;  // Текущий выбранный вопрос

    public Transform addButtonQuestion; // Кнопка спавна кнопок
    public GameObject buttonQuestionPrefab;  // Префаб кнопки вопроса
    public Transform ParentButtonQuestions; // Родительский объект для кнопки вопроса
    
    [Header("Input fields")]
    public InputField buttonNameField;
    public InputField questionField;
    public List<GameObject> answerInputFields = new List<GameObject>();
    public List<GameObject> dropdowns = new List<GameObject>();
    public GameObject answerInputFieldPref;
    public Transform answerParent;
    public Transform addAnswerField;
    public Transform firstAnswerField;
    public GameObject dropdownPref;

    [Header("Nodes")]
    public List<QuestionNode> questionNodes = new List<QuestionNode>();
    public NodeCanvas nodeCanvas;
    
    #endregion

    private void Start() 
    {
        // При старте нужно заполнять листы с кнопками и questions
        // QuestionNode a = new QuestionNode();
        // a.CreateAnswer(3);
        
        // questionNodes.Add(a);

        
    }


    private void FillListQuestions()
    {
        // for(int i = 0; i < questionButtons.Count; i++)
        // {
        //     questions[i] = 
        // }
    }
    
    // Добавление кнопки вопроса
    public void AddButtonQuestion(string name)
    {
        // TODO: сделать добаления названия кнопки
        var button = Instantiate(buttonQuestionPrefab, addButtonQuestion.position, Quaternion.identity);
        button.transform.SetParent(ParentButtonQuestions);
        button.GetComponentInChildren<Text>().text = "Вопрос " + questionButtons.Count.ToString();
        button.name = "QuestionButton" + (questionButtons.Count).ToString();
        button.GetComponent<Button>().onClick.AddListener(delegate { SwitchCurrentQuestion(button.GetComponent<Button>()); });
        questionButtons.Add(button);

        Question question = new Question();
        questions.Add(question);
        
        addButtonQuestion.position = new Vector3(addButtonQuestion.position.x, addButtonQuestion.position.y - 60, 0);
    }

    // Добавление поля для ответа
    public void AddAnswerInputField()
    {
        var inputField = Instantiate(answerInputFieldPref, addAnswerField.position, Quaternion.identity);
        inputField.transform.SetParent(answerParent);
        answerInputFields.Add(inputField);

        var dropdownNew = Instantiate(dropdownPref, new Vector3(addAnswerField.position.x + 400f, addAnswerField.position.y, 0), Quaternion.identity);
        dropdownNew.transform.SetParent(answerParent);
        dropdowns.Add(dropdownNew);
        
        addAnswerField.position = new Vector3(addAnswerField.position.x, addAnswerField.position.y - 100f, 0);
    }

    // Удаление последнего поля ответа
    // public void RemoveLastAnswer()
    // {
    //     int delete = answerInputFields.Count;

    //     Destroy(answerInputFields[delete]);
    //     Destroy(dropdowns[delete]);
    //     answerInputFields.RemoveAt(delete);
    //     dropdowns.RemoveAt(delete);
    //     questions[currentQuestion].RemoveLastAnswer();
    // }

    // Кнопка сохранения введных полей в объект question
    public void SaveQuestion()
    {
        questions[currentQuestion].SetQuestion(questionField.text);
        questions[currentQuestion].SetButtonName(buttonNameField.text);
        
        for (int i = 0; i < answerInputFields.Count; i++)
        {
            Answer ans = new Answer();
            ans.name = answerInputFields[i].GetComponent<InputField>().text;
            questions[currentQuestion].SetAnswer(ans);
        }

        //print(questions[0].answers[2]);
    }

    // Пересоздание необходимого количества полей ответов
    public void RespawnAnswers(int a)
    {
        foreach(GameObject field in answerInputFields) Destroy(field);
        answerInputFields.Clear();
        foreach(GameObject drop in dropdowns) Destroy(drop);
        dropdowns.Clear();
        addAnswerField.position = new Vector3(addAnswerField.position.x, firstAnswerField.position.y, 0);

        for (int i = 0; i < a; i++) AddAnswerInputField();
    }

    // Смена текущего вопроса
    public void SwitchCurrentQuestion(Button button)
    {
        string name = button.name;
        string nameDigit = "";

        for (int i = 0; i < button.name.Length; i++)
        {
            if (char.IsDigit(name[i]))
            {
                nameDigit += name[i];
            }
        }

        currentQuestion = Convert.ToInt32(nameDigit);
        
        buttonNameField.text = questions[currentQuestion].buttonName;
        questionField.text = questions[currentQuestion].GetQuestion();

        RespawnAnswers(questions[currentQuestion].answers.Count);
        for (int i = 0; i < answerInputFields.Count; i++) 
        {
            answerInputFields[i].GetComponent<InputField>().text = questions[currentQuestion].answers[i].name;
        }
    }
}
