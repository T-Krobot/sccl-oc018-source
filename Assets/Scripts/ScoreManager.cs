using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;

    public float scoreCount;
    public float hiScoreCount;
    public float pointsPerSecond;

    public bool scoreIncreasing;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        scoreText.text = "新加坡动物园\n" + Mathf.Round(scoreCount);


    }

    public void AddScore()
    {
        scoreCount += 20;
    }

    public void DecScore()
    {
        scoreCount -= 20;
    }
}
