using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUps : MonoBehaviour
{
    public Text actionText;
    public Text pickUpText;
    private bool playerNear;

    public Sprite itemSprite;

    // Start is called before the first frame update
    void Start()
    {
        actionText.text = "";
        pickUpText.text = "";
        GetComponent<SpriteRenderer>().sprite = itemSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerNear)
        {
            pickUpText.text = $"{name} collected!";
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerNear == false)
        {
            pickUpText.text = "";
            gameObject.SetActive(false);
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
