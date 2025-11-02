using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UWinScript : MonoBehaviour
{
    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void secret()
    {
        SceneManager.LoadScene("test");
    }
}
