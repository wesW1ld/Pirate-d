using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retryscript : MonoBehaviour
{

    public void RetryGame()
    {
        SceneManager.LoadScene("Tutorial"); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
