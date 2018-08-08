using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerObject : MonoBehaviour
{

    public AnswersClass answerInfo;
    private QuizManager quizManager;
    public Text answerDisplay;
    void OnEnable()
    {
        //  answerDisplay = GetComponent<Text>();

    }
    // Use this for initialization
    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSelf()
    {
        answerDisplay.text = answerInfo.answerText;
    }

    public void SubmitAnswer()
    {
        quizManager.ReceiveAnswer(answerInfo.isCorrect);
    }
}
