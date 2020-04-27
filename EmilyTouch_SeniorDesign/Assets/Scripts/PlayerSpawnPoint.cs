using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private PlayerController player;
    public GameObject playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        player.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
