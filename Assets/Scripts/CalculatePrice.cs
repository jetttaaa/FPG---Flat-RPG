using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatePrice : MonoBehaviour
{
    float number;
    float upgradeAmount;
    public bool special;
    public bool pen;
    public bool multi;
    public bool hp;
    public bool hpREG;
    public bool damage;
    public bool speed;
    public GlobalUpgrades controller;
    public SaveGame save;

    public Text upgradeText;
    public Text cost;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalUpgrades>();
        save = GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveGame>();

        Calculate(upgradeText, cost);
    }
    public void Calculate(Text upgradesText, Text targetText)
    {
        number = float.Parse(targetText.text);
        upgradeAmount = float.Parse(upgradesText.text);
        if (!special)
        {
            if (upgradeAmount <= 0)
            {

            }
            else
            {

                number += number / 5;
                number = Mathf.Floor(number);
            }
            targetText.text = number.ToString();
        }
        else
        {
            if (upgradeAmount <= 0)
            {

            }
            else
            {
                number *= 5;
                number = Mathf.Floor(number);
            }
            targetText.text = number.ToString();

        }
    }
    public void CalculateButton()
    {
        if (pen) { controller.PenLVL++; save.PenLVL++; }
        if (multi) { controller.Multi++; save.Multi++; }
        if (hp) { controller.HP++; save.HP++; }
        if (hpREG) { controller.HP_REG++; save.HP_REG++; }
        if (damage) { controller.Dmg++; save.Dmg++; }
        if (speed) { controller.BulSp++; save.BulSp++; }
        controller.Money -= float.Parse(cost.text);
        save.money -= float.Parse(cost.text);

        Calculate(upgradeText, cost);
        controller.UpdateTexts();
    }
}
