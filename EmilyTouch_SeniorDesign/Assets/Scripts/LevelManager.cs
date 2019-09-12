using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Text actionText;
    private bool playerInExit;
    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
        playerInExit = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInExit)
        {
            PlayerPrefs.SetString(levelToLoad, SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
            SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
            actionText.text = "";
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("oh????");
            actionText.text = "Leave";
            playerInExit = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("oh...");
            actionText.text = "";
            playerInExit = false;
        }
    }
}