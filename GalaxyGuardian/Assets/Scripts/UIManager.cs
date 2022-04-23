using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject warnTimeMenu;

    private void OnEnable()
    {
        Player.OnPlayerDeath += EnableGameOverMenu;
        MainMenu.OnWarnTime += EnableWarnTimeMenu;
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath -= EnableGameOverMenu;
        MainMenu.OnWarnTime -= EnableWarnTimeMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        WaveCounter.waveCounter = 0;
        Score.scoreValue = 0;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void EnableWarnTimeMenu()
    {
        warnTimeMenu.SetActive(true);
    }

    public void RestartTimer()
    {
        MainMenu.WarnTime += 5;
    }

    void Update()
    {
        if (!MainMenu.Warned && Time.realtimeSinceStartup >= MainMenu.WarnTime)
        {
            MainMenu.Warned = true;
            Debug.Log("You should stop playing!!!");
            EnableWarnTimeMenu();
        }
    }
}
