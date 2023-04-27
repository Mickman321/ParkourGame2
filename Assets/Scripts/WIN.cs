using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIN : MonoBehaviour
{// pauseMenu �r gjord av Mickael

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
       /* if (OnTriggerEnter(Collider other))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }*/

    } // den h�r koden �r functioner som kollar vad som h�nder om spelet �r pausat eller inte.
    private void OnTriggerEnter(Collider other)
    {
        controller = other.gameObject.GetComponent<CharacterController>();
        controller.enabled = false;
        other.gameObject.transform.position = target.position;
        controller.enabled = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = (true);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = (false);
    }// den h�r koden startar tiden om man klickar resume

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = (true);
    }// Den h�r koden Frysser tiden och pausar spelet

    public void LoadMenu()
    {
        Debug.Log("LoadingMenu...");
        SceneManager.LoadScene("Start Menu");
        Time.timeScale = 1f;
    }// den h�r koden startar tiden och �ppnar startmenu scenen

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();// den h�r koden st�nger av spelet
    }


}
