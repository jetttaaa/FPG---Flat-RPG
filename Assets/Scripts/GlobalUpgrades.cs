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
        PenLVLcost = upgradeLoad.PenLVLcost;
        Multi = upgradeLoad.Multi;
        Multicost = upgradeLoad.Multicost;
        Dmg = upgradeLoad.Dmg;
        Dmgcost = upgradeLoad.Dmgcost;
        BulSp = upgradeLoad.BulSp;
        BulSpcost = upgradeLoad.BulSpcost;
        HP = upgradeLoad.HP;
        HPcost = upgradeLoad.HPcost;
        HP_REG = upgradeLoad.HP_REG;
        HP_REGcost = upgradeLoad.HP_REGcost;
    }
    public void UpdateTexts()
    {
        moneys.text = Money.ToString() + "c";
        PenLVLText.text = PenLVL.ToString();
        PenLVLTextcost.text = PenLVLcost.ToString();
        MultiText.text = Multi.ToString();
        MultiTextcost.text = Multicost.ToString();
        DmgText.text = Dmg.ToString();
        DmgTextcost.text = Dmgcost.ToString();
        BulSpText.text = BulSp.ToString();
        BulSpTextcost.text = BulSpcost.ToString();
        HPText.text = HP.ToString();
        HPTextcost.text = HPcost.ToString();
        HP_REGText.text = HP_REG.ToString();
        HP_REGTextcost.text = HP_REGcost.ToString();
    }



}
