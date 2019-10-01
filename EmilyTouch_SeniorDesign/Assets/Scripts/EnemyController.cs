using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Text actionText;
    private bool playerNear;
    private int lastPressed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ouch");
            actionText.text = "Fight";
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
