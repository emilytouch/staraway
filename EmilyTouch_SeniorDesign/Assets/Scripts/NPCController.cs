﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public Text actionText;
    private bool playerNear;
    private int lastPressed;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && playerNear)
        {
            if (lastPressed == 0)
            {
                dialogueBox.SetActive(true);
                Time.timeScale = 0f;
                actionText.text = "";
                lastPressed = 1;
                Debug.Log("talking");
            }
            else
            {
                dialogueBox.SetActive(false);
                Time.timeScale = 1f;
                dialogueText.text = "";
                lastPressed = 0;
                Debug.Log("Shut up");
            }

            if (gameObject.name == "NPC0")
            {
                dialogueText.text = "This is where I would speak.";
            }

           

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ouch");
            actionText.text = "Talk";
        }

        if (other.gameObject.CompareTag("Player"))
        {
            playerNear = true;
        }
    }
     void OnTriggerExit2D(Collider2D other)
    {
        actionText.text = "";
        if (other.gameObject.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
}
