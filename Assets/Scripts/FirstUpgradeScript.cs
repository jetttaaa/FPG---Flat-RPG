using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstUpgradeScript : MonoBehaviour
{

    private float[] Upgrades = new float[1000];
    public int UpgradeNum = 0;
    public GameObject Stats;
    public Text UpgradeText;
    public GameObject player;
    private GameObject UpgradeScreen;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UpgradeScreen = GameObject.FindGameObjectWithTag("MainBrain").GetComponent<spawning>().UpgradeScreen;
        Random.seed = Random.Range(1, 10000);
        int i = 0;
        while (i < Upgrades.Length)
        {
            Upgrades[i] = Mathf.Round(Random.value * 10);
            Debug.Log(Upgrades[i]);
            i++;
        }
    }

    public void Upgrade()
    {
        switch (Upgrades[UpgradeNum])
        {
            case 0:
                Stats.GetComponent<Stats>().AttackPower++;
                player.GetComponent<Player>().UpdateStats();
                UpgradeNum++;
                break;
            case 1:
                Stats.GetComponent<Stats>().AttackPower += 3;
                player.GetComponent<Player>().UpdateStats();
                UpgradeNum++;
                break;
            case 2:
                Stats.GetComponent<Stats>().AttackPower += 5;
                player.GetComponent<Player>().UpdateStats();
                UpgradeNum++;
                break;
            case 3:
                Stats.GetComponent<Stats>().hp += 5;
                player.GetComponent<Player>().UpdateStats();
                UpgradeNum++;
                break;
            case 4:
                Stats.GetComponent<Stats>().hp += 15;
                player.GetComponent<Player>().UpdateStats();
                UpgradeNum++;
                break;
            case 5:
                Stats.GetComponent<Stats>().hp += 30;
                player.GetComponent<Player>().UpdateStats();
                UpgradeNum++;
                break;
            case 6:
                Stats.GetComponent<Stats>().bulletSpeed += 5;
                player.GetComponent<Player>().UpdateStats();
                UpgradeNum++;
                break;
            case 7:
                Stats.GetComponent<Stats>().bulletSpeed += 10;
                player.GetComponent<Player>().UpdateStats();
                UpgradeNum++;
                break;
            case 8:
                Stats.GetComponent<Stats>().bulletSpeed += 15;
                player.GetComponent<Player>().UpdateStats();
                UpgradeNum++;
                break;
            case 9:
                Stats.GetComponent<Stats>().hp_reg += 0.5f;
                player.GetComponent<Player>().UpdateStats();
                UpgradeNum++;
                break;
            case 10:
                Stats.GetComponent<Stats>().hp_reg += 1f;
                player.GetComponent<Player>().UpdateStats();
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
