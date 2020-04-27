using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text energyText;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        SetEnergyText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnergyText() => energyText.text = "Energy: " + player.energy;

}
