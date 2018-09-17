using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    public ScoreManager theScoreManager;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;
    public EndMenu theEndMenu;
    private QuizManager theQuizManager;
    // Use this for initialization
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
        theQuizManager = FindObjectOfType<QuizManager>();

    }

    public void RestartGame()
    {
        if (theQuizManager.GameMode == 0) { theScoreManager.scoreIncreasing = false; }
        thePlayer.gameObject.SetActive(false);

        theEndMenu.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCo");
    }
    public void Reset()
    {
        theEndMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }


        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        if (theQuizManager.GameMode == 0)
        {
            theScoreManager.scoreCount = 0;
            theScoreManager.scoreIncreasing = true;
        }

    }
}
