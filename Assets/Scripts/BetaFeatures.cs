using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetaFeatures : MonoBehaviour
{
    public void Lvl10()
    {
        SceneManager.LoadScene("Level10");
    }

    public void menu()
    {
        SceneManager.LoadScene("main menu");
    }

    public void Lvl11()
    {
        SceneManager.LoadScene("Level11");
    }

    public void Lvl12()
    {
        SceneManager.LoadScene("Level12");
    }
}
