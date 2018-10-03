using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{

    public int scoreToGive;

    private ScoreManager theScoreManager;
    private QuizManager theQuizManager;
    private GameObject theQuestionHolder;
    private BoxManager theBoxManager;
    private PlayerController thePlayerController;

    // Use this for initialization
    void Start()
    {
        theQuestionHolder = GameObject.FindGameObjectWithTag("QuestionHolder");
        theScoreManager = FindObjectOfType<ScoreManager>();
        theQuizManager = FindObjectOfType<QuizManager>();
        theBoxManager = FindObjectOfType<BoxManager>();
        theBoxManager.DisableQuestionHolder();
        thePlayerController = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theBoxManager.EnableQuestionHolder();
            Destroy(gameObject);
            if (theQuizManager.GameMode == 1)
            {
                thePlayerController.ToggleRunning();
            }

        }

    }
}
