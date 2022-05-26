using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    public bool Fire = false;
    public bool Metal = false;
    public bool Nature = false;
    private Stats stats;

    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
    }
    public void ChooseFire()
    {
        Fire = true;
        Chosen();
    }
    public void ChooseNature()
    {
        Nature = true;
        Chosen();
    }
    public void ChooseMetal()
    {
        Metal = true;
        Chosen();
    }

    void Chosen()
    {
        stats.Metal = Metal;
        stats.Fire = Fire;
        stats.Nature = Nature;
    }
}
