using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUpgrades : MonoBehaviour
{
    private SaveGame upgradeLoad;
    public float Money = 0;
    public float PenLVL = 0f;
    public float Multi = 0f;
    public float Dmg = 0f;
    public float BulSp = 0f;
    public float HP = 0f;
    public float HP_REG = 0f;
    public float Def = 0f;

    public Text moneys;
    public Text PenLVLText;
    public Text MultiText;
    public Text DmgText;
    public Text BulSpText;
    public Text HPText;
    public Text HP_REGText;
    public Text DefText;


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
        Def = upgradeLoad.def;
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
        DefText.text = Def.ToString();
    }

}
