using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUps : MonoBehaviour
{
    public Text actionText;
    public GameObject dialogueBox;
    public Text dialogueText;
    private bool playerNear;
    public GameObject itemDisplay;
    private int lastPressed;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        actionText.text = "";
        dialogueText.text = "";
        itemDisplay.SetActive(false);
        lastPressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerNear)
        {
            if (lastPressed == 0)
            {
                dialogueBox.SetActive(true);
                dialogueText.text = "This is an item! Pick up more to help your party on your journey.";
                itemDisplay.SetActive(true);
                Time.timeScale = 0f;
                lastPressed = 1;
            }
            else
            {
                dialogueBox.SetActive(false);
                dialogueText.text = "";
                itemDisplay.SetActive(false);
                Time.timeScale = 1f;
                lastPressed = 0;
                Destroy(gameObject);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("oooooh");
            actionText.text = "Pick Up";
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("meh");
            actionText.text = "";
            playerNear = false;
        }
    }
}
