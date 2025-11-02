using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject otherCanvas;
    public bool betaVer = false;
    public TextMeshProUGUI verNum;
    public string versionString = "v1.2.0";
    public TextMeshProUGUI verExple;
    public string verExpleString = "v<color=red>1<color=white>.<color=green>2<color=white>.<color=yellow>0";
    public GameObject betaFeatures;
    public string betaVerNum = "v1.3.0 Beta";
    public string betaVerExpleString = "v<color=red>1<color=white>.<color=green>3<color=white>.<color=yellow>0";

    void Start()
    {
        if (betaVer)
        {
            verNum.text = betaVerNum;
            verExple.text = betaVerExpleString;
        }
        else
        {
            verNum.text = versionString;
            verExple.text = verExpleString;
            Destroy(betaFeatures);
        }
    }

    public void play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void exit()
    {
        Application.Quit();
    }
    public void how()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void UpdatesMeaning()
    {
        otherCanvas.SetActive(true);
    }

    public void Back()
    {
        otherCanvas.SetActive(false);
    }

    public void credits()
    {
        SceneManager.LoadScene("credits");
    }

    public void beta()
    {
        SceneManager.LoadScene("betaFeatures");
    }

    public void music()
    {
        SceneManager.LoadScene("musicPlayer");
    }
}
