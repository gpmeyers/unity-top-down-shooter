using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    // Function is called when play button is pressed to load the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Function is called when the quit button is pressed to quit the application
    public void QuitGame()
    {
        Application.Quit();
    }

}
