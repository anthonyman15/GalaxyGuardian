using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWave : MonoBehaviour
{
    public static int waveCounter;
    
    public Text WaveText;
    
    // Start is called before the first frame update
    void Start()
    {
        WaveText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        WaveText.text = "Wave " + waveCounter.ToString();
    }
}
