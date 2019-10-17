using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private bool playerNear;
    public float enemySpeed;

    private bool isMoving;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNear == true)
        {

        }
        else
        {

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerController>().detectionNumber += 3;
            GameObject.Find("Player").GetComponent<PlayerController>().SetDetectionText();
            playerNear = true;
            Debug.Log("OH FUCK");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerNear = false;
            Debug.Log("lel sucker");
            GameObject.Find("Player").GetComponent<PlayerController>().detectionNumber -= 1;
            GameObject.Find("Player").GetComponent<PlayerController>().SetDetectionText();

        }
    }
}
