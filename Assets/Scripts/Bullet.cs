using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timer = 20;
    public float pen;

    private void Start()
    {
        pen = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>().pen;
    }
    private void Update()
    {
        if (pen < 0) Destroy(gameObject);
        timer -= Time.deltaTime;
        if (timer <= 0) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy_Basic"))
        {
            pen -= 1;
        }
    }
}
