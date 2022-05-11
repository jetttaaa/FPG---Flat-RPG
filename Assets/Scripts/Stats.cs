using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float bulletSpeed;
    public float hp;
    public float max_hp;
    public float hp_reg;
    public float damage;
    public float AttackPower;
    public float pen;
    public float multi;
    public float def;

    public Text stats;
    private void UpdateStats()
    {
        stats.text = "Max HP: " + max_hp + "\nAttack Power: " + AttackPower + "\n Bullet Speed: " + bulletSpeed + "\n HP Regen: " + hp_reg + "\n Penetration: " + pen + "\n Multishot: " + (multi - 1);
    }
    private void Update()
    {
        if (stats.isActiveAndEnabled) UpdateStats();
    }

}
