using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float health;
    public float speed;
    public float detectionNumber;
    public Text healthText;

    private static bool playerExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SetHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            speed += 2;
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            speed = 1;
        }

        if (speed >= 3)
        {
            detectionNumber += 2;
        }
        else
        {
            detectionNumber -= 1;
        }

        if (detectionNumber > 100)
        {
            detectionNumber = 100;
        }

        if (detectionNumber < 0)
        {
            detectionNumber = 0;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed;
    }

    public void SetHealthText()
    {
        healthText.text = "Health: " + health;

    }
}
