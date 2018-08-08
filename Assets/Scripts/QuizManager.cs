using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public QuestionClass[] questions;
    public InfoClass[] infos;

    private int questionNumber = 0;

    public Text QuestionDisplay;

    public AnswerObject[] answerObjects;

    private BoxManager theBoxManager;
    private ScoreManager theScoreManager;
    public Image questionImage;
    public GameManager theGameManager;

    public int GameMode;

    public Text theinfoText1;
    public Text theinfoText2;

    // Use this for initialization
    void Start()
    {
        UpdateQuestion();
        theBoxManager = FindObjectOfType<BoxManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theGameManager = FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateQuestion()

    {
        if (GameMode == 0)
        {
            if (questionNumber < questions.Length)
            {


                QuestionDisplay.text = questions[questionNumber].questionText;
                questionImage.sprite = questions[questionNumber].questionSprite;

                for (int i = 0; i < answerObjects.Length; i++)
                {
                    answerObjects[i].answerInfo = questions[questionNumber].answers[i];
                    answerObjects[i].UpdateSelf();


                }
            }
            else
            {
                theGameManager.RestartGame();
                Debug.Log("End");
                questionNumber = 0;
                UpdateQuestion();
            }
        }
        else
        {
            if (questionNumber < infos.Length)
            {
                theinfoText1.text = infos[questionNumber].infoText1;
                theinfoText2.text = infos[questionNumber].infoText2;
                questionImage.sprite = infos[questionNumber].infoSprite;
            }
            else
            {
                theGameManager.RestartGame();
                Debug.Log("End");
                questionNumber = 0;
                UpdateQuestion();
            }
        }



    }

    public void IncrementQuestion()
    {
        questionNumber++;
        UpdateQuestion();
    }
    public void ReceiveAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            //Debug.Log("Yes");
            theScoreManager.AddScore();
        }
        else
        {
            //Debug.Log("No");
            theScoreManager.DecScore();
        }
        questionNumber++;
        //Debug.Log(questionNumber);
        StartCoroutine(ShowCorrect());


    }

    IEnumerator ShowCorrect()
    {
        for (int i = 0; i < answerObjects.Length; i++)
        {
            if (answerObjects[i].answerInfo.isCorrect)
            {
                answerObjects[i].GetComponent<Text>().color = Color.green;

            }
            else
            {
                answerObjects[i].GetComponent<Text>().color = Color.red;
            }

        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < answerObjects.Length; i++)
        {
            answerObjects[i].GetComponent<Text>().color = Color.black;
        }
        theBoxManager.DisableQuestionHolder();
        UpdateQuestion();
    }
}
[System.Serializable]

public class AnswersClass
{
    public string answerText;
    public bool isCorrect;
}


[System.Serializable]
public class QuestionClass
{
    public string questionText;
    public List<AnswersClass> answers = new List<AnswersClass>();
    public Sprite questionSprite;
}
[System.Serializable]
public class InfoClass
{
    public string infoText1;
    public string infoText2;
    public Sprite infoSprite;
}