using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticUpgrade : MonoBehaviour
{

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalUpgrades>().auto) this.gameObject.SetActive(false);
    }
    public void Pressed()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalUpgrades>().auto = true;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveGame>().auto = true;
    }
}
