using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public static int scoreValue;
    public Text ScoreText;
    
    public void Start(){
        ScoreText.GetComponent<Text>();
    }
    public void Update()
    {
        ScoreText.text = "Score " + scoreValue.ToString();
    }
}
