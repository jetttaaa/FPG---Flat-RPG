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
    public float multi;
    public float def;

    private float elapsed = 0f;
    public bool boughtAuto = false;

    public Rigidbody2D rb;
    public Image healthBarImage;
    public GameObject bullet;
    public Stats Stats;
    public SpriteRenderer renderer;
    private spawning controller;
    private AudioSource _audiosource;

    Color origionalColor;
    private float nextActionTime = 0.0f;
    public float period = 0.01f;
    public int UpgradeNum = 0;

    private Vector3 scale;
    private Vector3 dump;
    private Vector3 scaleLimiter;
    private Vector3 maxHP;
    private void Awake()
    {
        Stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
        controller = GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>();
        _audiosource = GetComponent<AudioSource>();
        bulletSpeed = 1;
        hp = 1;
        damage = 1;
        AttackPower = 1;
        hp_reg = 0.5f;
        max_hp = hp;
        multi = 1;
        def = 0;
        scale = new Vector3(damage, 0f, 0f);
        scaleLimiter = new Vector3(0f, 0f, 0f);
        dump = new Vector3(1f, 1f, 0f);
        origionalColor = renderer.color;

    }
    private void Start()
    {
        hp = Stats.hp;
        if (GameObject.FindGameObjectWithTag("MainBrain").GetComponent<SaveGame>().auto) boughtAuto = true;
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
        max_hp = Stats.max_hp;
        damage = Stats.damage;
        def = Stats.def;
        AttackPower = Stats.AttackPower;
        multi = Mathf.Floor(Stats.multi);
    }
    public void Damaged()
    {
        if (damage < def) hp -= 1;
        else hp -= (damage - def);
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
        if (hp <= 0) { Time.timeScale = 0; controller.GameOver.SetActive(true); }
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            hp_regen();
        }
        if (bulletSpeed > 25) { bulletSpeed = 25; Stats.bulletSpeed = 25; }
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookAt = mouseScreenPosition;
        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        if (!boughtAuto)
        {
            if (Input.GetButtonDown("Fire1") && !GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>().Paused)
            {
                _audiosource.Play();
                FireMultishot(multi);
            }
        }
        else
        {


            if (Input.GetButton("Fire1") && !GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>().Paused)
            {
                if (Time.time > nextActionTime)
                {
                    nextActionTime = Time.time + (period / 10);
                    _audiosource.Play();
                    FireMultishot(multi);
                }
            }

        }

    }
    private void FireMultishot(float multi)
    {
        GameObject Temporary_Bullet_Handler = Instantiate(bullet, transform.position, transform.rotation);
        Temporary_Bullet_Handler.transform.Rotate(Vector3.forward);
        Temporary_Bullet_Handler.GetComponent<Rigidbody2D>().AddForce(Temporary_Bullet_Handler.transform.right * bulletSpeed);
        Destroy(Temporary_Bullet_Handler, 3.0f);
        for (int i = 1; i < multi; i++)
        {
            if (i % 2 == 0)
            {
                Temporary_Bullet_Handler = Instantiate(bullet, transform.position, transform.rotation);
                Temporary_Bullet_Handler.transform.Rotate(Vector3.forward * (i * 2));
                Temporary_Bullet_Handler.GetComponent<Rigidbody2D>().AddForce(Temporary_Bullet_Handler.transform.right * bulletSpeed);
                Destroy(Temporary_Bullet_Handler, 3.0f);
            }
            else
            {
                Temporary_Bullet_Handler = Instantiate(bullet, transform.position, transform.rotation);
                Temporary_Bullet_Handler.transform.Rotate(Vector3.forward * -(i * 2));
                Temporary_Bullet_Handler.GetComponent<Rigidbody2D>().AddForce(Temporary_Bullet_Handler.transform.right * bulletSpeed);
                Destroy(Temporary_Bullet_Handler, 3.0f);
            }
        }
    }
}
