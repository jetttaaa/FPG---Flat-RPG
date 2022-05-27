using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatsShown : MonoBehaviour
{
    public Text Text;
    float HP = 30f;
    float DMG = 5f;
    float DEF = 1f;
    public float WaveCount;
    public void UpdateStats()
    {
        HP = 30f;
        DMG = 5f;
        DEF = 1f;
        WaveCount = GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>().WaveCounter;
        for (int i = 1; i < WaveCount; i++) HP += Mathf.Floor(HP / 20f);
        for (int i = 1; i < WaveCount; i++) DMG += Mathf.Round(DMG / 20f * 1000.0f) / 1000.0f;
        for (int i = 1; i < WaveCount; i++) DEF += Mathf.Round(DEF / 20f * 1000.0f) / 1000.0f;
        Text.text = "HP: " + HP + "\nDMG: " + DMG + "\nDEF: " + DEF;
    }
}
