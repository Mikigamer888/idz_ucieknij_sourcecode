using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public AudioSource music;
    public GameObject winScreen;

    void Start()
    {
        music.Stop();
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        music.Play();
        winScreen.SetActive(false);
    }
}
