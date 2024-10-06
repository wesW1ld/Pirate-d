using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win1 : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //  menu tutorial 3:38 file<buildsettings add levels to index in order
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
