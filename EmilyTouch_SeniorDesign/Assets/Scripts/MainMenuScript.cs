using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string startLevel;
    public string mainMenu;

    public GameObject ngButton;
    public GameObject lgButton;
    public GameObject optionButton;
    public GameObject exitButton;
    public GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    public void Options()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
