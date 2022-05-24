using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusicFromMenu : MonoBehaviour
{

    public void STOPMUSIC()
    {
        GameObject.FindGameObjectWithTag("music").GetComponent<Music>().Stop();
    }
    public void PLAYMUSIC()
    {
        GameObject.FindGameObjectWithTag("music").GetComponent<Music>().Play();
    }


}
