using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyTank : MonoBehaviour
{
    private GameObject Player;
    public GameObject damageTextPrefab;
    public GameObject spawning;
    private GameObject thisObject;
    public SpriteRenderer renderer;
    public AudioSource _audioSource;
    public AudioSource hitsound;
    public Stats stats;

    private float speed = 4f;
    public float flashTime;
    public bool attacking = false;
    private float nextActionTime = 0.0f;
    public float period = 1f;
    public float hp = 30f;
    public float def = 1f;
    public float damage = 5f;
    public string textToDisplay;
    private int WaveCount;

    Color origionalColor;

    void Start()

    {
        Player = GameObject.Find("Player");
        spawning = GameObject.FindGameObjectWithTag("MainBrain");
        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
        _audioSource = GameObject.FindGameObjectWithTag("Stats").GetComponent<AudioSource>();
        WaveCount = GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>().WaveCounter;
        hitsound = GetComponent<AudioSource>();

        origionalColor = renderer.color;

        for (int i = 1; i < WaveCount; i++) hp += Mathf.Floor(hp / 10f);
        hp *= 3f;
        for (int i = 1; i < WaveCount; i++) damage += Mathf.Round(damage / 20f * 1000.0f) / 1000.0f;
        damage *= 0.5f;
        for (int i = 1; i < WaveCount; i++) def += Mathf.Round(def / 20f * 1000.0f) / 1000.0f;
        def *= 1f;
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
            Player.GetComponent<Player>().Damaged(damage);
        }
        if (hp <= 0)
        {
            spawning.GetComponent<spawning>().killed += 1f;
            _audioSource.Play();
            GameObject.Destroy(this.gameObject);
        }
        if (!attacking) transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
    public void Damaged()
    {
        Vector3 spawningpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject DamageText = Instantiate(damageTextPrefab, spawningpos, Quaternion.identity);
        DamageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(textToDisplay);
        hp -= stats.AttackPower - def;
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
