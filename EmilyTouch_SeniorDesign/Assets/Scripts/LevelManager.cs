using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PixelCrushers;

public class LevelManager : MonoBehaviour
{
    private bool playerInExit;
    public string levelToLoad;
    public Text levelText;
    public string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().energy = 5;
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
        if(collision.tag == "Player" && (PixelCrushers.DialogueSystem.QuestLog.IsQuestSuccessful("Under Fire") &&
            PixelCrushers.DialogueSystem.QuestLog.IsQuestSuccessful("Pizza Delivery") &&
            PixelCrushers.DialogueSystem.QuestLog.IsQuestSuccessful("I Need Healing!") &&
            PixelCrushers.DialogueSystem.QuestLog.IsQuestSuccessful("See you, Space Emperor") &&
            PixelCrushers.DialogueSystem.QuestLog.IsQuestSuccessful("Gathering the Magic")))
        {
            Debug.Log("oh????");
            playerInExit = true;
        }
        else
        {
            playerInExit = false;
            PixelCrushers.DialogueSystem.DialogueManager.ShowAlert("You must finish ALL the quests before you can continue!");
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