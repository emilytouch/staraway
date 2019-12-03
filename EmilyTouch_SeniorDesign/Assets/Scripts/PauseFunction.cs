using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseFunction : MonoBehaviour
{
    public string mainMenu;
    public bool isPaused;

    public GameObject pauseCanvas;
    public GameObject partyCanvas;
    public GameObject invCanvas;

    private int lastPressed;
    public Button resumeButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.SetActive(false);
        lastPressed = 0;

        if (isPaused == true)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        partyCanvas.SetActive(false);
        resumeButton.onClick.AddListener(Resume);
        exitButton.onClick.AddListener(QuitLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (lastPressed == 0)
            {
                isPaused = true;
                lastPressed = 1;
                pauseCanvas.SetActive(true);
                Time.timeScale = 0f;
                Debug.Log("Freeze!");
            }
            else
            {
                isPaused = false;
                lastPressed = 0;
                pauseCanvas.SetActive(false);
                Time.timeScale = 1f;
                Debug.Log("everybody clap yo hands");
            }
        }
    }

    public void Resume()
    {
        isPaused = false;
        pauseCanvas.SetActive(false);
        partyCanvas.SetActive(false);
        invCanvas.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("woo");
        lastPressed = 0;
    }

    public void PartyMenu()
    {
        isPaused = true;
        partyCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        Time.timeScale = 0f;
        lastPressed = 1;

    }public void Back()
    {
        isPaused = true;
        pauseCanvas.SetActive(true);
        partyCanvas.SetActive(false);
        invCanvas.SetActive(false);
        Time.timeScale = 0f;
        lastPressed = 1;
    }

    public void Inventory()
    {
        invCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        partyCanvas.SetActive(false);
        Time.timeScale = 0;
        lastPressed = 1;
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("MainMenu");
        invCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        partyCanvas.SetActive(false);
        Time.timeScale = 0;
        lastPressed = 1;
    }
}