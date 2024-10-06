using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial-new"); // name "eric" whatever level 1 is named
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
