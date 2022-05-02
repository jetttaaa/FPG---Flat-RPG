using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUpdate : MonoBehaviour
{
    public Text TextWave;
    public int WaveCount;
    void Update()
    {
        if (this.isActiveAndEnabled) WaveCount = GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>().WaveCounter;
        TextWave.text = "Wave " + WaveCount.ToString();
    }
}
