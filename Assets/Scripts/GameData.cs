using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class GameData
{
    public float score;
    public string name;
    public float money;
    public float PenLVL;
    public float PenLVLcost;
    public float Multi;
    public float Multicost;
    public float Dmg;
    public float Dmgcost;
    public float BulSp;
    public float BulSpcost;
    public float HP;
    public float HPcost;
    public float HP_REG;
    public float HP_REGcost;

    public GameData(float Hscore, string nick, float coins, float Pen, float Pencost, float Mult, float Multcost, float Damage, float Damagecost, float Speed, float Speedcost, float Health, float Healthcost, float Regen, float Regencost)
    {
        score = Hscore;
        name = nick;
        money = coins;
        PenLVL = Pen;
        PenLVLcost = Pencost;
        Multi = Mult;
        Multicost = Multcost;
        Dmg = Damage;
        Dmgcost = Damagecost;
        BulSp = Speed;
        BulSpcost = Speedcost;
        HP = Health;
        HPcost = Healthcost;
        HP_REG = Regen;
        HP_REGcost = Regencost;
    }
}
