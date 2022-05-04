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
    public Player player;
    public spawning MainBrain;
    private GameObject UpgradeScreen;


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
            Upgrades[i] = Mathf.Round(Random.value * 10);
            i++;
        }
    }

    public void Upgrade()
    {
        switch (Upgrades[UpgradeNum])
        {
            case 0:
                Stats.AttackPower++;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;
            case 1:
                Stats.AttackPower += 3;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;
            case 2:
                Stats.AttackPower += 5;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;
            case 3:
                Stats.max_hp += 5;
                player.UpdateStats();
                player.hp = player.max_hp;
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;
            case 4:
                Stats.max_hp += 15;
                player.UpdateStats();
                player.hp = player.max_hp;
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;
            case 5:
                Stats.max_hp += 30;
                player.UpdateStats();
                player.hp = player.max_hp;
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;
            case 6:
                Stats.bulletSpeed += 5;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;
            case 7:
                Stats.bulletSpeed += 10;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;
            case 8:
                Stats.bulletSpeed += 15;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;
            case 9:
                Stats.hp_reg += 0.5f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;
            case 10:
                Stats.hp_reg += 1f;
                player.UpdateStats();
                MainBrain.CloseUpgrades();
                UpgradeNum++;
                break;

        }
    }

    void Update()
    {

        if (UpgradeScreen.activeInHierarchy)
        {

            if (Upgrades[UpgradeNum] == 0) UpgradeText.text = "AttackPower\n+1";
            if (Upgrades[UpgradeNum] == 1) UpgradeText.text = "AttackPower\n+3";
            if (Upgrades[UpgradeNum] == 2) UpgradeText.text = "AttackPower\n+5";
            if (Upgrades[UpgradeNum] == 3) UpgradeText.text = "HP\n+5";
            if (Upgrades[UpgradeNum] == 4) UpgradeText.text = "HP\n+15";
            if (Upgrades[UpgradeNum] == 5) UpgradeText.text = "HP\n+30";
            if (Upgrades[UpgradeNum] == 6) UpgradeText.text = "Bullet Speed\n+5";
            if (Upgrades[UpgradeNum] == 7) UpgradeText.text = "Bullet Speed\n+10";
            if (Upgrades[UpgradeNum] == 8) UpgradeText.text = "Bullet Speed\n+15";
            if (Upgrades[UpgradeNum] == 9) UpgradeText.text = "HP Regen\n+0.5f";
            if (Upgrades[UpgradeNum] == 10) UpgradeText.text = "HP Regen\n+1f";
        }

    }
}
