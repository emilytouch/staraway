using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public GameObject[] items;
    public Image[] itemSprites;

    public Button invButton;
    private int lastPressed;
    

    private static bool invExists;

    // Start is called before the first frame update
    void Start()
    {
        lastPressed = 0;
        if (!invExists)
        {
            invExists = true;
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
