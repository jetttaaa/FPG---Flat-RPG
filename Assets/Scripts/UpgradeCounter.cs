using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCounter : MonoBehaviour
{
    public int upgradeCounter = 0;
    public Text text;
    public FirstUpgradeScript script;
    public int UpgradeNum;

    private void Start()
    {
        script = GetComponentInParent<FirstUpgradeScript>();
    }
    private void Update()
    {
        upgradeCounter = (int)script.UpgradesAmount[script.UpgradeNum];
        if (upgradeCounter != 0) text.text = upgradeCounter.ToString();
        else text.text = "N";

    }

}
