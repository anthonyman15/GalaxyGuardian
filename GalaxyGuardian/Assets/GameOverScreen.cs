using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    Text ScoreText;
    public void SetUp()
    {
        gameObject.SetActive(true);
        ScoreText.text = "S" + Score.scoreValue.ToString();
    }
}