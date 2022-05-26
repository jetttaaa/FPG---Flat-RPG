using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timer = 20;
    public float pen;

    private void Start()
    {
        pen = Mathf.Floor(GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>().pen);
    }
    private void Update()
    {
        if (pen < 0) Destroy(gameObject);
        timer -= Time.deltaTime;
        if (timer <= 0) Destroy(gameObject);
    }

}
