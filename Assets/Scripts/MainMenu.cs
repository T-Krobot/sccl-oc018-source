using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string playGameLevel;

    // Use this for initialization
    public void PlayGame()
    {
        SceneManager.LoadScene("Game 1");

    }

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}