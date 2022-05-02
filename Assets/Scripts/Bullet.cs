using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timer = 20;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) Destroy(gameObject);
    }
}
