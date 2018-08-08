using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public string mainMenuLevel;
    public string gameLe;

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }


}
