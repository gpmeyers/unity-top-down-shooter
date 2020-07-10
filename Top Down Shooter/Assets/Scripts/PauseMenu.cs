using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Field that holds the current status of the game (paused or not paused)
    public static bool GameIsPaused = false;

    // Reference to the UI for the pause menu
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Function to Resume the Game after a Pause
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Function to Pause the game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /*
     *TODO: Need to change these depending on how I implement the store
     * 
     * If I implement the store from the Pause Menu, change the Menu button to pull up the store, and the quit button to exit to main menu
     */

    // Function to Load the Menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    // Function to Quit to the Main Menu
    public void QuitGame()
    {
        Application.Quit();
    }
}
