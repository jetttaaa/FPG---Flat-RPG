using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUpgrades : MonoBehaviour
{
    private SaveGame upgradeLoad;
    public float Money = 0;
    public float PenLVLcost = 50f;
    public float PenLVL = 0f;
    public float Multicost = 100f;
    public float Multi = 0f;
    public float Dmgcost = 10f;
    public float Dmg = 0f;
    public float BulSpcost = 10f;
    public float BulSp = 0f;
    public float HPcost = 10f;
    public float HP = 0f;
    public float HP_REGcost = 10f;
    public float HP_REG = 0f;

    public Text moneys;
    public Text PenLVLText;
    public Text PenLVLTextcost;
    public Text MultiText;
    public Text MultiTextcost;
    public Text DmgText;
    public Text DmgTextcost;
    public Text BulSpText;
    public Text BulSpTextcost;
    public Text HPText;
    public Text HPTextcost;
    public Text HP_REGText;
    public Text HP_REGTextcost;

    private void Start()
    {
        upgradeLoad = GetComponent<SaveGame>();
        upgradeLoad.LoadFile();
        updateUpgrades();
        UpdateTexts();
    }
    public void updateUpgrades()
    {
        Money = upgradeLoad.money;
        PenLVL = upgradeLoad.PenLVL;

        Multi = upgradeLoad.Multi;

        Dmg = upgradeLoad.Dmg;

        BulSp = upgradeLoad.BulSp;

        HP = upgradeLoad.HP;

        HP_REG = upgradeLoad.HP_REG;

    }
    public void UpdateTexts()
    {
        moneys.text = Money.ToString() + "c";
        PenLVLText.text = PenLVL.ToString();

        MultiText.text = Multi.ToString();

        DmgText.text = Dmg.ToString();

        BulSpText.text = BulSp.ToString();

        HPText.text = HP.ToString();

        HP_REGText.text = HP_REG.ToString();

    }



}
