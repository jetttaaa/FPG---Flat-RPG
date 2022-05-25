using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NicknameScreen : MonoBehaviour
{
    private SaveGame nameLoad;
    public TMP_InputField nameInput;
    void Start()
    {
        nameLoad = GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveGame>();
        nameLoad.LoadFile();
        if (nameLoad.currentName != "") { SceneManager.LoadScene("MainMenu"); }
    }

    public void UpdateName()
    {
        nameLoad.currentName = nameInput.text;
        nameLoad.SaveFile();
        SceneManager.LoadScene("MainMenu");
    }


}
