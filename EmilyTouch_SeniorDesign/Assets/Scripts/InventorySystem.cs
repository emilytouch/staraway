using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public GameObject[] inventory;
    public Button invButton;
    private int lastPressed;
    public GameObject invCanvas;

    private static bool invExists;

    // Start is called before the first frame update
    void Start()
    {
        lastPressed = 0;
        invButton.onClick.AddListener(TaskOnClick);
        if (!invExists)
        {
            invExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (lastPressed == 0)
            {
                invCanvas.SetActive(true);
                Time.timeScale = 0;
                lastPressed = 1;
            }
            else
            {
                invCanvas.SetActive(false);
                Time.timeScale = 1;
                lastPressed = 0;
                GameObject.Find("Player").GetComponent<PauseFunction>().pauseCanvas.SetActive(false);

            }
        }

        if (invCanvas.activeInHierarchy == true)
        {
            Time.timeScale = 0;
            GameObject.Find("Player").GetComponent<PauseFunction>().pauseCanvas.SetActive(false);
            lastPressed = 1;
        }
    }

    void TaskOnClick()
    {
        invCanvas.SetActive(true);
        Time.timeScale = 0;
        lastPressed = 1;
        GameObject.Find("Player").GetComponent<PauseFunction>().pauseCanvas.SetActive(false);
    }
}
