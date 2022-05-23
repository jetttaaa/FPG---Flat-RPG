using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame : MonoBehaviour
{

    public float HighScore = 0f;
    public string currentName = "";
    public float money = 0f;
    public float PenLVLcost = 50f;
    public float PenLVL = 0f;
    public float Multicost = 100f;
    public float Multi = 0f;
    public float Dmgcost = 10f;
    public float Dmg = 0f;
    public float BulSpcost = 10f;
    public float BulSp = 0f;
    public float HPcost = 10f;
    public float HP = 0f;
    public float HP_REGcost = 10f;
    public float HP_REG = 0f;



    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameData data = new GameData(HighScore, currentName, money, PenLVL, PenLVLcost, Multi, Multicost, Dmg, Dmgcost, BulSp, BulSpcost, HP, HPcost, HP_REG, HP_REGcost);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();

        HighScore = data.score;
        currentName = data.name;
        money = data.money;
        PenLVL = data.PenLVL;
        PenLVLcost = data.PenLVLcost;
        Multi = data.Multi;
        Multicost = data.Multicost;
        Dmg = data.Dmg;
        Dmgcost = data.Dmgcost;
        BulSp = data.BulSp;
        BulSpcost = data.BulSpcost;
        HP = data.HP;
        HPcost = data.HPcost;
        HP_REG = data.HP_REG;
        HP_REGcost = data.HP_REGcost;


    }

}