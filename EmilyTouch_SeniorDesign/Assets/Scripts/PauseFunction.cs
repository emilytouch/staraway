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
        Time.timeScale = 1f;
        Debug.Log("woo");
        lastPressed = 0;
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene(mainMenu);
    }
}