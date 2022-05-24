using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private GameObject Player;
    public GameObject damageTextPrefab;
    public GameObject spawning;
    private GameObject thisObject;
    public SpriteRenderer renderer;
    public AudioSource _audioSource;
    public AudioSource hitsound;

    private float speed = 4f;
    public float flashTime;
    public bool attacking = false;
    private float nextActionTime = 0.0f;
    public float period = 1f;
    public float hp = 30f;
    private float Hit_for = 0f;
    public string textToDisplay;
    private int WaveCount;

    Color origionalColor;

    void Start()
    {
        hitsound = GetComponent<AudioSource>();
        _audioSource = GameObject.FindGameObjectWithTag("Stats").GetComponent<AudioSource>();
        WaveCount = GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>().WaveCounter;
        for (int i = 1; i < WaveCount; i++) hp += Mathf.Floor(hp / 5);
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

        if (attacking == true && (Time.time > nextActionTime))
        {
            nextActionTime = Time.time + period;
            hitsound.Play();
            Player.GetComponent<Player>().Damaged();
        }
        if (hp <= 0)
        {
            if (thisObject.name == "Triangle(Clone)") { spawning.GetComponent<spawning>().killed += 1f; } else spawning.GetComponent<spawning>().killed++;
            _audioSource.Play();
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
