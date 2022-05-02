using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 100;
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;
    public GameObject healthbar;
    public GameObject healthbarHP;
    private float hp = 200f;
    private float damage = 20f;
    public float AttackPower = 10f;
    private SpriteRenderer color;
    public GameObject bullet;
    public float flashTime;

    Color origionalColor;
    public SpriteRenderer renderer;

    private Vector3 scale;
    private Vector3 dump;
    private Vector3 scaleLimiter;
    private Vector3 maxHP;
    private void Awake()
    {
        scale = new Vector3(damage, 0f, 0f);
        scaleLimiter = new Vector3(0f, 0f, 0f);
        maxHP = new Vector3(hp, 200f, 200f);
        dump = new Vector3(1f, 1f, 0f);
        healthbar.transform.localScale = maxHP;
        origionalColor = renderer.color;

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

        float AngleDeg = (180 / Mathf.PI) *AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        if (Input.GetButtonDown("Fire1"))
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy_Basic")) {
            
        }
    }
}
