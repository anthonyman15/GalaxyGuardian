using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public static int waveCounter = 0;
    Text wave;
    void Start()
    {
        wave = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        wave.text = "Wave " + waveCounter;
    }
}
