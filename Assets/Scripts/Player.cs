using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float bulletSpeed;
    public float hp;
    public float damage;
    public float AttackPower;
    public float flashTime;
    public float hp_reg;
    public float max_hp;
    float elapsed = 0f;
    public Rigidbody2D rb;
    public Image healthBarImage;
    public GameObject bullet;
    public Stats Stats;

    Color origionalColor;
    public SpriteRenderer renderer;

    private Vector3 scale;
    private Vector3 dump;
    private Vector3 scaleLimiter;
    private Vector3 maxHP;
    private void Awake()
    {
        Stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
        bulletSpeed = 1;
        hp = 1;
        damage = 1;
        AttackPower = 1;
        hp_reg = 0;
        max_hp = hp;

        scale = new Vector3(damage, 0f, 0f);
        scaleLimiter = new Vector3(0f, 0f, 0f);
        dump = new Vector3(1f, 1f, 0f);
        origionalColor = renderer.color;

    }
    private void Start()
    {
        UpdateStats();
    }
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(hp / max_hp, 0, 1f);
    }
    public void hp_regen()
    {
        if (hp < max_hp) hp += hp_reg;
        UpdateHealthBar();
    }
    public void UpdateStats()
    {
        hp_reg = Stats.hp_reg;
        bulletSpeed = Stats.bulletSpeed;
        hp = Stats.hp;
        max_hp = Stats.max_hp;
        damage = Stats.damage;
        AttackPower = Stats.AttackPower;
    }

    public void Damaged()
    {
        hp -= damage;
        UpdateHealthBar();
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
        if (hp <= 0) Time.timeScale = 0;
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            hp_regen();
        }
        if (bulletSpeed > 100) { bulletSpeed = 100; Stats.bulletSpeed = 100; }
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
