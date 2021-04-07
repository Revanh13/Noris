using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Variables
    [Header("Main lists")]
    public List<GameObject> questionButtons = new List<GameObject>(); // Лист с кнопками вопросов
    private List<Question> questions = new List<Question>();
    private int currentQuestion = 0;  // Текущий выбранный вопрос

    public Transform addButtonQuestion; // Кнопка спавна кнопок
    public GameObject buttonQuestionPrefab;  // Префаб кнопки вопроса
    public Transform spawnPointButton; // Позиция спавна кнопки вопроса
    public Transform ParentButtonQuestions; // Родительский объект для кнопки вопроса
    
    #endregion

    private void Start() 
    {
        // При старте нужно заполнять листы с кнопками и questions
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
        var button = Instantiate(buttonQuestionPrefab, spawnPointButton.position, Quaternion.identity);
        button.transform.SetParent(ParentButtonQuestions);
        // Фича прикольная, но не нужна здесь
        if (name == String.Empty)
            button.GetComponentInChildren<Text>().text = "Вопрос " + questionButtons.Count.ToString();
        else button.GetComponentInChildren<Text>().text = name;
        questionButtons.Add(button);

        Question question = new Question();
        questions.Add(question);

        Vector3 newPosSpawn = spawnPointButton.position;
        newPosSpawn.y -= 60f;
        spawnPointButton.position = newPosSpawn;
        addButtonQuestion.position = new Vector3(addButtonQuestion.position.x, addButtonQuestion.position.y - 60, 0);
    }

    // Кнопка сохранения введных полей в объект question
    public void SaveQuestion()
    {
        
    }
}
