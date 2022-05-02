using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawning : MonoBehaviour
{

    public GameObject pos1;
    public GameObject pos2;
    public GameObject nopos1;
    public GameObject nopos2;
    public GameObject target;

    public int max_spawn_num = 1;
    public float spawn_time = 1f;

    public static int points = 0;
    public static int shoots = 0;

    public static int actNum = 0;

    private void Start()
    {
        pos1.SetActive(false);
        pos2.SetActive(false);
        StartSpawning();
    }

    public async void StartSpawning()
    {
        InvokeRepeating("SpawnTarget", 0, spawn_time);
        
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
                if (!IsCBetweenAB(notposition1, notposition2, position)) { 
                    Instantiate(target, position, Quaternion.Euler(new Vector2(0, 0))); 
                    actNum++; 
                    spawned = true; 
                } 
                else { 
                    randomX = Random.Range(position1.x, position2.x);
                    randomY = Random.Range(position1.y, position2.y);
                    position = new Vector3(randomX, randomY);
                };
            } while (spawned == false);
               

        }
    }
}
