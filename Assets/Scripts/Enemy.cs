using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private GameObject Player;
    private float speed = 4f;
    public float flashTime;
    public bool attacking = false;
    private float nextActionTime = 0.0f;
    public float period = 1f;
    private float hp = 30f;
    private float Hit_for = 0f;
    public GameObject damageTextPrefab;
    public string textToDisplay;
    private GameObject thisObject;

    public GameObject spawning;

    Color origionalColor;
    public SpriteRenderer renderer;
    void Start()
    {
        thisObject = this.gameObject;


        Player = GameObject.Find("Player");
        Hit_for = Player.GetComponent<Player>().AttackPower;
        origionalColor = renderer.color;
        spawning = GameObject.FindGameObjectWithTag("MainBrain");
    }

    void Update()
    {
        Vector3 PlayerPosition = Player.transform.position;

        Vector3 lookAt = PlayerPosition;

        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

        if (Time.time > nextActionTime) { }
        if (attacking == true && (Time.time > nextActionTime))
        {
            nextActionTime = Time.time + period;
            Player.GetComponent<Player>().Damaged();
        };
        if (hp <= 0)
        {
            if (thisObject.name == "Triangle(Clone)") { spawning.GetComponent<spawning>().killed += 1f; } else spawning.GetComponent<spawning>().killed++;


            GameObject.Destroy(this.gameObject);
        }
        if (Vector2.Distance(Player.transform.position, transform.position) > 1.1) transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);


    }
    public void Damaged()
    {
        Vector3 spawningpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject DamageText = Instantiate(damageTextPrefab, spawningpos, Quaternion.identity);
        DamageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(textToDisplay);
        Hit_for = Player.GetComponent<Player>().AttackPower;
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

}
