using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float bulletSpeed;
    public float hp;
    public float max_hp;
    public float max_hp_text;
    public float hp_reg;
    public float hp_reg_text;
    public float damage;
    public float AttackPower;
    public float AttackPower_text;
    public float pen;
    public float multi;
    public float def;
    public float def_text;
    public bool Metal = false;
    public bool Nature = false;
    public bool Fire = false;
    public Text stats;

    private SaveGame save;


    private void Start()
    {
        save = GameObject.FindGameObjectWithTag("MainBrain").GetComponent<SaveGame>();
        save.LoadFile();
        max_hp += save.HP * 10;
        hp += save.HP * 10;
        hp_reg += save.HP_REG / 4;
        pen += save.PenLVL;
        multi += save.Multi;
        AttackPower += save.Dmg;
        bulletSpeed += save.BulSp;
        def += save.def;
        UpdateStats();
    }

    private void UpdateStats()
    {
        if (Nature) hp_reg_text = (hp_reg * 1.5f); else hp_reg_text = hp_reg;
        if (Nature) max_hp_text = (max_hp * 1.5f); else max_hp_text = max_hp;
        if (Metal) def_text = (def * 2f); else def_text = def;
        if (Fire) AttackPower_text = (AttackPower * 1.5f); else AttackPower_text = AttackPower;
        stats.text = "Max HP: " + max_hp_text + "\nAttack Power: " + AttackPower_text + "\n Bullet Speed: " + bulletSpeed + "\nDefence: " + def_text + "\nHP Regen: " + hp_reg_text + "\n Penetration: " + pen + "\n Multishot: " + (multi - 1);
    }
    private void Update()
    {
        if (stats.isActiveAndEnabled) UpdateStats();
    }

}
