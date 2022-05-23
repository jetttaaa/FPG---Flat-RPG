using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToUpgradesButton : MonoBehaviour
{
    public void UpgradeGO()
    {
        SceneManager.LoadScene("GlobalUpgrg");
    }
}
