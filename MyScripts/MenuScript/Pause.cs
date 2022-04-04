using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static bool pauseMenu;
    public GameObject menu;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = false;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("escape");
            if (pauseMenu)
            {
                
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                menu.SetActive(false);
                Time.timeScale = 1f;
                pauseMenu = false;
            }
            else if (!pauseMenu)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                menu.SetActive(true);
                Time.timeScale = 0f;
                pauseMenu = true;
            }
        }
    }
    public void resumeGame()
    {
        //Debug.Log("hitttt");
        Time.timeScale = 1f;
        menu.SetActive(false);
        pauseMenu = false;
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
