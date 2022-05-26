using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumberCalc : MonoBehaviour
{
    public TextMeshPro num;
    private bool Fire;
    void Start()
    {
        Fire = GameObject.FindGameObjectWithTag("Elements").GetComponent<Elements>().Fire;
        if (Fire == true) num.text = (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().AttackPower * 1.5f).ToString(); else num.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().AttackPower.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
