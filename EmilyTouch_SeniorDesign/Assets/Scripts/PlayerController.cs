using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float detectionNumber;
    public float energy;
    public Rigidbody2D rb2d;

    private static bool playerExists;
    public Text detectionText;
    public Text energyText;
    public GameObject gameOverScreen;

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

        detectionNumber = 0;
        SetDetectionText();
        SetEnergyText();
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)))
        {
            speed += 3;
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            speed = 1;
        }

        if (speed >= 3)
        {
            detectionNumber += 1;
            SetDetectionText();
        }
        if (speed == 1)
        {
            detectionNumber -= 1;
            SetDetectionText();

        }

        if (detectionNumber >= 100)
        {
            detectionNumber = 100;
            SetDetectionText();

        }

        if (detectionNumber <= 0)
        {
            detectionNumber = 0;
            SetDetectionText();

        }

        if (detectionNumber == 100)
        {
            rb2d.Sleep();
            gameOverScreen.SetActive(true);
            detectionNumber = 100;
            SetDetectionText();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed;
    }

    public void SetDetectionText()
    {
        detectionText.text = "Detection Rate: " + detectionNumber + "%";
    }

    public void SetEnergyText()
    {
        energyText.text = "Energy: " + energy;
    }
}
