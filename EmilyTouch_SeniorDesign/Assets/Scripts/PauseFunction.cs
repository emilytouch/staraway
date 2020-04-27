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
    public GameObject optCanvas;
    public GameObject questCanvas;

    private int lastPressed;
    public Button resumeButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.GetComponent<Canvas>().enabled = false;
        invCanvas.GetComponent<Canvas>().enabled = false;
        optCanvas.GetComponent<Canvas>().enabled = false;
        partyCanvas.GetComponent<Canvas>().enabled = false;

        lastPressed = 0;

        if (isPaused == true)
        {
            pauseCanvas.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }
        else
        {
            pauseCanvas.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1f;
        }

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
                pauseCanvas.GetComponent<Canvas>().enabled = true;
                Time.timeScale = 0f;
                Debug.Log("Freeze!");
            }
            else
            {
                isPaused = false;
                lastPressed = 0;
                pauseCanvas.GetComponent<Canvas>().enabled = false;
                Time.timeScale = 1f;
                Debug.Log("everybody clap yo hands");
            }
        }

    }

    public void Resume()
    {
        isPaused = false;

        pauseCanvas.GetComponent<Canvas>().enabled = false;
        invCanvas.GetComponent<Canvas>().enabled = false;
        optCanvas.GetComponent<Canvas>().enabled = false;
        partyCanvas.GetComponent<Canvas>().enabled = false;

        Time.timeScale = 1f;
        Debug.Log("woo");
        lastPressed = 0;
    }

    public void PartyMenu()
    {
        isPaused = true;

        pauseCanvas.GetComponent<Canvas>().enabled = false;
        invCanvas.GetComponent<Canvas>().enabled = false;
        optCanvas.GetComponent<Canvas>().enabled = false;
        partyCanvas.GetComponent<Canvas>().enabled = true;

        Time.timeScale = 0f;
        lastPressed = 1;

    }

    public void QuestMenu()
    {
        isPaused = true;
        pauseCanvas.GetComponent<Canvas>().enabled = false;
        invCanvas.GetComponent<Canvas>().enabled = false;
        optCanvas.GetComponent<Canvas>().enabled = false;
        partyCanvas.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 0f;
        lastPressed = 1;

    }

    public void OptionsMenu()
    {
        isPaused = true;
        pauseCanvas.GetComponent<Canvas>().enabled = false;
        invCanvas.GetComponent<Canvas>().enabled = false;
        optCanvas.GetComponent<Canvas>().enabled = true;
        partyCanvas.GetComponent<Canvas>().enabled = false;
        questCanvas.SetActive(false);
        Time.timeScale = 0f;
        lastPressed = 1;

    }

    public void Back()
    {
        isPaused = true;
        pauseCanvas.GetComponent<Canvas>().enabled = true;
        invCanvas.GetComponent<Canvas>().enabled = false;
        optCanvas.GetComponent<Canvas>().enabled = false;
        partyCanvas.GetComponent<Canvas>().enabled = false;
        questCanvas.SetActive(false);
        Time.timeScale = 0f;
        lastPressed = 1;
    }

    public void Inventory()
    {
        pauseCanvas.GetComponent<Canvas>().enabled = false;
        invCanvas.GetComponent<Canvas>().enabled = true;
        optCanvas.GetComponent<Canvas>().enabled = false;
        partyCanvas.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 0;
        lastPressed = 1;
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("MainMenu");
        invCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        partyCanvas.SetActive(false);
        optCanvas.SetActive(false);
        questCanvas.SetActive(false);
        Time.timeScale = 0;
        lastPressed = 1;
    }
}