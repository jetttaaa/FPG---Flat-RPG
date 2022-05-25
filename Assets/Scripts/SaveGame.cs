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
    public float PenLVL = 0f;
    public float Multi = 0f;
    public float Dmg = 0f;
    public float BulSp = 0f;
    public float HP = 0f;
    public float HP_REG = 0f;
    public float def = 0f;
    public bool auto = false;

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameData data = new GameData(HighScore, currentName, money, PenLVL, Multi, Dmg, BulSp, HP, HP_REG, def, auto);
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
        Multi = data.Multi;
        Dmg = data.Dmg;
        BulSp = data.BulSp;
        HP = data.HP;
        HP_REG = data.HP_REG;
        def = data.Def;
        auto = data.auto;
    }
}