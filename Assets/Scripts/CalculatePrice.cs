using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatePrice : MonoBehaviour
{
    float number;
    float originalnumber;
    float upgradeAmount;
    public bool special;
    public bool pen;
    public bool multi;
    public bool hp;
    public bool hpREG;
    public bool damage;
    public bool speed;
    public bool defence;
    public GlobalUpgrades controller;
    public SaveGame save;
    public BuyUpgradeSound soundPlay;

    public Text upgradeText;
    public Text cost;

    private void Start()
    {
        soundPlay = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BuyUpgradeSound>();
        originalnumber = number;
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalUpgrades>();
        save = GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveGame>();

        Calculate(upgradeText, cost);
    }
    public void Calculate(Text upgradesText, Text targetText)
    {
        controller.UpdateTexts();
        number = float.Parse(targetText.text);
        upgradeAmount = float.Parse(upgradesText.text);
        if (!special)
        {

            number = 10;
            for (int i = 0; i < upgradeAmount; i++)
            {
                number += number / 5;
            }

            number = Mathf.Floor(number);

            targetText.text = number.ToString();
        }
        else
        {

            if (pen) number = 50;
            if (multi) number = 100;
            for (int i = 0; i < upgradeAmount; i++)
            {
                number *= 5;
            }
            number = Mathf.Floor(number);

            targetText.text = number.ToString();

        }
    }
    public void CalculateButton()
    {
        if (save.money >= float.Parse(cost.text) && controller.Money >= float.Parse(cost.text))
        {
            if (pen) { controller.PenLVL++; save.PenLVL++; }
            if (multi) { controller.Multi++; save.Multi++; }
            if (hp) { controller.HP++; save.HP++; }
            if (hpREG) { controller.HP_REG++; save.HP_REG++; }
            if (damage) { controller.Dmg++; save.Dmg++; }
            if (speed) { controller.BulSp++; save.BulSp++; }
            if (defence) { controller.Def++; save.def++; }
            controller.Money -= float.Parse(cost.text);
            save.money -= float.Parse(cost.text);

            Calculate(upgradeText, cost);
            soundPlay.PlaySoundUpgrade();

            controller.UpdateTexts();

        }
        else { soundPlay.PlayError(); }


    }
}
