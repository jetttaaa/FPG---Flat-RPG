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
    public float Multi;
    public float Dmg;
    public float BulSp;
    public float HP;
    public float HP_REG;
    public float Def;

    public GameData(float Hscore, string nick, float coins, float Pen, float Mult, float Damage, float Speed, float Health, float Regen, float defence)
    {
        score = Hscore;
        name = nick;
        money = coins;
        PenLVL = Pen;
        Multi = Mult;
        Dmg = Damage;
        BulSp = Speed;
        HP = Health;
        HP_REG = Regen;
        Def = defence;
    }
}
