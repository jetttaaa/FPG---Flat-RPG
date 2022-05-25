using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumberCalc : MonoBehaviour
{
    public TextMeshPro num;
    void Start()
    {
        num.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().AttackPower.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
