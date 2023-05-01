using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIN : MonoBehaviour
{// pauseMenu är gjord av Mickael

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    public Transform target;

    private CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
            
        

    } // den här koden är functioner som kollar vad som händer om spelet är pausat eller inte.
    private void OnTriggerEnter(Collider other)
    {
       // if //(OnTriggerEnter(Collider other))
       // {
            if (GameIsPaused)
            {

                Pause();
            }
            else
            {
                Resume();
            }
      //  }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = (false);
    }// den här koden startar tiden om man klickar resume

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = (true);
    }// Den här koden Frysser tiden och pausar spelet

    public void LoadMenu()
    {
        Debug.Log("LoadingMenu...");
        SceneManager.LoadScene("Start Menu");
        Time.timeScale = 1f;
    }// den här koden startar tiden och öppnar startmenu scenen

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();// den här koden stänger av spelet
    }


}
