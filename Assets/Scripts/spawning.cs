using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class spawning : MonoBehaviour
{

    public GameObject pos1;
    public GameObject pos2;
    public GameObject nopos1;
    public GameObject nopos2;
    public GameObject target;
    public GameObject PausedInWaveMenu;
    public GameObject GameOver;
    public GameObject UpgradeScreen;
    public SaveGame saveStuff;
    public int WaveCounter;
    public bool WaveCleared = false;
    public bool Paused = false;
    public float killed = 0;
    private bool max_set;

    public int max_spawn_num;
    public float spawn_time = 1f;

    public float coins;
    public Text coinsText;

    public int actNum = 0;

    private void Start()
    {
        saveStuff = GetComponent<SaveGame>();
        saveStuff.LoadFile();
        pos1.SetActive(false);
        pos2.SetActive(false);
        Paused = true;
    }
    public void FirstStart()
    {
        Paused = false;
        StartSpawning();
        Time.timeScale = 1;
    }
    public async void StartSpawning()
    {
        max_spawn_num = (WaveCounter * 5);
        max_set = true;
        InvokeRepeating("SpawnTarget", 0, spawn_time);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Esc") && !Paused)
        {
            Paused = true;
            PausedInWaveMenu.SetActive(true);
        }
        if (Paused)
        {
            Time.timeScale = 0;
        }
        if (killed >= max_spawn_num && max_set) { WaveCleared = true; }
    }

    public void SaveCoins()
    {

        saveStuff.money += coins;
        saveStuff.SaveFile();
    }
    public void UnpauseInWave()
    {
        PausedInWaveMenu.SetActive(false);
        Paused = false;
        Time.timeScale = 1;
    }
    public void StopSpawning()
    {
        CancelInvoke("SpawnTarget");
    }
    bool IsCBetweenAB(Vector3 A, Vector3 B, Vector3 C)
    {
        return Vector3.Dot((B - A).normalized, (C - B).normalized) < 0f && Vector3.Dot((A - B).normalized, (C - A).normalized) < 0f;
    }
    private void SpawnTarget()
    {
        if (actNum < max_spawn_num)
        {
            var position1 = pos1.transform.position;
            var position2 = pos2.transform.position;
            var notposition1 = nopos1.transform.position;
            var notposition2 = nopos2.transform.position;
            float randomX = Random.Range(position1.x, position2.x);
            float randomY = Random.Range(position1.y, position2.y);
            bool spawned = false;

            Vector2 position = new Vector3(randomX, randomY);
            do
            {
                if (!IsCBetweenAB(notposition1, notposition2, position))
                {
                    Instantiate(target, position, Quaternion.Euler(new Vector2(0, 0)));
                    actNum++;
                    spawned = true;
                }
                else
                {
                    randomX = Random.Range(position1.x, position2.x);
                    randomY = Random.Range(position1.y, position2.y);
                    position = new Vector3(randomX, randomY);
                };
            } while (spawned == false);
        }
        else if (actNum >= max_spawn_num && WaveCleared)
        {
            Paused = true;
            WaveCleared = false;
            Upgrades();
        }
    }
    public void Upgrades()
    {
        if (!UpgradeScreen.activeInHierarchy)
        {
            UpgradeScreen.SetActive(true);
        }
    }
    public void CloseUpgrades()
    {
        WaveCleared = false;
        UpgradeScreen.SetActive(false);
        WaveCounter++;
        coinsText.text = "Earned " + (Mathf.Floor(coins += WaveCounter + (coins / 20))) + " coins";
        actNum = 0;
        killed = 0;
        max_set = false;
        Paused = false;
        Time.timeScale = 1;
        StartSpawning();
    }
}
