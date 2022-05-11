using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstUpgradeScript : MonoBehaviour
{

    private float[] Upgrades = new float[1000];
    public int UpgradeNum = 0;
    public Stats Stats;
    public Text UpgradeText;
    bool reset;
    public Player player;
    public spawning MainBrain;
    private GameObject UpgradeScreen;
    public GameObject[] UpgradeIcons = new GameObject[14];


    private void Start()
    {
        Stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        MainBrain = GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>();
        UpgradeScreen = GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>().UpgradeScreen;

        Random.seed = Random.Range(1, 10000);
        int i = 0;
        while (i < Upgrades.Length)
        {
            Upgrades[i] = Random.Range(0, 16);
            i++;
        }
    }

    public void Upgrade()
    {
        switch (Upgrades[UpgradeNum])
        {
            case 0:
                UpgradeIcons[0].SetActive(false);
                Stats.AttackPower++;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 1:
                UpgradeIcons[1].SetActive(false);
                Stats.AttackPower += 3;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 2:
                UpgradeIcons[2].SetActive(false);
                Stats.AttackPower += 5;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 3:
                UpgradeIcons[3].SetActive(false);
                Stats.max_hp += 5;
                player.UpdateStats();
                player.hp = player.max_hp;
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 4:
                UpgradeIcons[4].SetActive(false);
                Stats.max_hp += 15;
                player.UpdateStats();
                player.hp = player.max_hp;
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 5:
                UpgradeIcons[5].SetActive(false);
                Stats.max_hp += 30;
                player.UpdateStats();
                player.hp = player.max_hp;
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 6:
                UpgradeIcons[6].SetActive(false);
                Stats.bulletSpeed += 0.1f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 7:
                UpgradeIcons[7].SetActive(false);
                Stats.bulletSpeed += 0.3f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 8:
                UpgradeIcons[8].SetActive(false);
                Stats.bulletSpeed += 0.5f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 9:
                UpgradeIcons[9].SetActive(false);
                Stats.hp_reg += 0.5f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 10:
                UpgradeIcons[10].SetActive(false);
                Stats.hp_reg += 1f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 11:
                UpgradeIcons[11].SetActive(false);
                Stats.pen += 0.25f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 12:
                UpgradeIcons[12].SetActive(false);
                Stats.multi += 0.25f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 13:
                UpgradeIcons[13].SetActive(false);
                Stats.def += 1f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 14:
                UpgradeIcons[14].SetActive(false);
                Stats.def += 2f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
            case 15:
                UpgradeIcons[15].SetActive(false);
                Stats.def += 3f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                reset = true;
                UpgradeNum++;
                break;
        }
    }

    int i = 0;

    void Update()
    {
        while (i < UpgradeIcons.Length && reset == true)
        {
            UpgradeIcons[i].SetActive(false);
            i++;
        }
        if (UpgradeScreen.activeInHierarchy)
        {
            i = 0;

            if (Upgrades[UpgradeNum] == 0) { UpgradeText.text = "AttackPower\n+1"; UpgradeIcons[0].SetActive(true); }
            if (Upgrades[UpgradeNum] == 1) { UpgradeText.text = "AttackPower\n+3"; UpgradeIcons[1].SetActive(true); }
            if (Upgrades[UpgradeNum] == 2) { UpgradeText.text = "AttackPower\n+5"; UpgradeIcons[2].SetActive(true); }
            if (Upgrades[UpgradeNum] == 3) { UpgradeText.text = "HP\n+5"; UpgradeIcons[6].SetActive(true); }
            if (Upgrades[UpgradeNum] == 4) { UpgradeText.text = "HP\n+15"; UpgradeIcons[7].SetActive(true); }
            if (Upgrades[UpgradeNum] == 5) { UpgradeText.text = "HP\n+30"; UpgradeIcons[8].SetActive(true); }
            if (Upgrades[UpgradeNum] == 6) { UpgradeText.text = "Bullet Speed\n+0.1"; UpgradeIcons[3].SetActive(true); }
            if (Upgrades[UpgradeNum] == 7) { UpgradeText.text = "Bullet Speed\n+0.3"; UpgradeIcons[4].SetActive(true); }
            if (Upgrades[UpgradeNum] == 8) { UpgradeText.text = "Bullet Speed\n+0.5"; UpgradeIcons[5].SetActive(true); }
            if (Upgrades[UpgradeNum] == 9) { UpgradeText.text = "HP Regen\n+0.5f"; UpgradeIcons[9].SetActive(true); }
            if (Upgrades[UpgradeNum] == 10) { UpgradeText.text = "HP Regen\n+1f"; UpgradeIcons[10].SetActive(true); }
            if (Upgrades[UpgradeNum] == 11) { UpgradeText.text = "Penetration\n+1/4"; UpgradeIcons[11].SetActive(true); }
            if (Upgrades[UpgradeNum] == 12) { UpgradeText.text = "Multishot\n+1/4"; UpgradeIcons[12].SetActive(true); }
            if (Upgrades[UpgradeNum] == 13) { UpgradeText.text = "Defence\n+1"; UpgradeIcons[13].SetActive(true); }
            if (Upgrades[UpgradeNum] == 14) { UpgradeText.text = "Defence\n+2"; UpgradeIcons[14].SetActive(true); }
            if (Upgrades[UpgradeNum] == 15) { UpgradeText.text = "Defence\n+2"; UpgradeIcons[15].SetActive(true); }
            reset = true;
        }
    }
}
