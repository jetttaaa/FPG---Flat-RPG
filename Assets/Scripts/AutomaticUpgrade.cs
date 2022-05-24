using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticUpgrade : MonoBehaviour
{
    private GlobalUpgrades upgrades;
    private void Start()
    {
        upgrades = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalUpgrades>();
        if (upgrades.auto) this.gameObject.SetActive(false);
    }
    public void Pressed()
    {
        if (upgrades.Money >= 1000)
        {
            upgrades.auto = true;
            upgrades.Money -= 1000;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveGame>().auto = true;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveGame>().money -= 1000;
            this.gameObject.SetActive(false);
            upgrades.UpdateTexts();
            upgrades.updateUpgrades();
        }

    }
}
