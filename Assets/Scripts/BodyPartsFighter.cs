using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsFighter : MonoBehaviour
{
    private EnemyFighter enemy;
    private void Start() { enemy = GetComponent<EnemyFighter>(); }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            enemy.Damaged();
            other.GetComponent<Bullet>().pen--;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.attacking = true;
        }
    }
}
