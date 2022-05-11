using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game1");
    }
    public void Stats()
    {
        SceneManager.LoadScene("Info");
    }
    public void Exit()
    {
        Application.Quit();
    }
}


