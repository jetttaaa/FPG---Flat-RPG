using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private GameObject Player;
    private float speed = 2f;
    public float flashTime;
    private bool attacking = false;
    private float nextActionTime = 0.0f;
    public float period = 1f;
    private float hp = 30f;
    private float Hit_for = 0f;
    public GameObject damageTextPrefab;
    public string textToDisplay;

    Color origionalColor;
    public SpriteRenderer renderer;
    void Start()
    {
        
        Player = GameObject.Find("Player");
        Hit_for = Player.GetComponent<Player>().AttackPower;
        origionalColor = renderer.color;
    }

    void Update()
    {

        
        if (Time.time > nextActionTime) {   }
        if (attacking == true && (Time.time > nextActionTime)) {
            nextActionTime = Time.time + period;
            Player.GetComponent<Player>().Damaged();
            Debug.Log("Attacked");
        };
        if (hp <= 0) GameObject.Destroy(this.gameObject);
        if (Vector2.Distance(Player.transform.position, transform.position) > 1.1) transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            
        
    }
    public void Damaged()
    {
        GameObject DamageText = Instantiate(damageTextPrefab, this.transform);
        DamageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(textToDisplay);
        hp -= Hit_for;
        
    }
    void FlashRed()
    {
        renderer.color = Color.red;
        Invoke("ResetColor", flashTime);
    }
    void ResetColor()
    {
        renderer.color = origionalColor;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            FlashRed();
            Damaged();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attacking = true;
        }
    }
}
