using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private bool playerInExit;
    public string levelToLoad;
    public Text levelText;
    public string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        
        playerInExit = false;
        SetLevelText();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInExit)
        {
            PlayerPrefs.SetString(levelToLoad, SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
            SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("oh????");
            playerInExit = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("oh...");
            playerInExit = false;
        }
    }

    public void SetLevelText()
    {
        levelText.text = "Area: " + currentLevel;
    }
}