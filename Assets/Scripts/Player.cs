using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bulletSpeed;
    private float hp;
    private float damage;
    public float AttackPower;
    private float flashTime;
    public Rigidbody2D rb;
    public GameObject healthbar;
    public GameObject healthbarHP;
    public GameObject bullet;
    public GameObject Stats;

    Color origionalColor;
    public SpriteRenderer renderer;

    private Vector3 scale;
    private Vector3 dump;
    private Vector3 scaleLimiter;
    private Vector3 maxHP;
    private void Awake()
    {
        Stats = GameObject.FindGameObjectWithTag("Stats");
        bulletSpeed = 1;
        hp = 1;
        damage = 1;
        AttackPower = 1;

        scale = new Vector3(damage, 0f, 0f);
        scaleLimiter = new Vector3(0f, 0f, 0f);
        maxHP = new Vector3(healthbarHP.transform.localScale.x, 200f, 200f);
        dump = new Vector3(1f, 1f, 0f);
        origionalColor = renderer.color;

    }
    private void Start()
    {
        UpdateStats();
    }
    public void UpdateStats()
    {
        bulletSpeed = Stats.GetComponent<Stats>().bulletSpeed;
        hp = Stats.GetComponent<Stats>().hp;
        maxHP = new Vector3(hp, 200f, 200f);
        healthbar.transform.localScale = maxHP;
        damage = Stats.GetComponent<Stats>().damage;
        AttackPower = Stats.GetComponent<Stats>().AttackPower;
    }

    public void Damaged()
    {
        if (healthbarHP.transform.localScale.x > 0f) healthbarHP.transform.localScale -= scale;
        if (healthbarHP.transform.localScale.x < 0f) healthbarHP.transform.localScale = scaleLimiter;
        hp -= damage;
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


    public void Update()
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookAt = mouseScreenPosition;

        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        if (Input.GetButtonDown("Fire1") && !GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>().Paused)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            GameObject projectile = (GameObject)Instantiate(bullet, myPos, rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }

    }
}
