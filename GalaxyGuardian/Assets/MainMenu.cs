using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static float StartTime;
    public static float WarnTime;
    public static bool Warned = false;
    public static event Action OnWarnTime;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartTime = Time.realtimeSinceStartup;
        WarnTime = StartTime + 5;
        // WarnTime = StartTime + (10 * 60);
    }
    public void GoToSettingMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
