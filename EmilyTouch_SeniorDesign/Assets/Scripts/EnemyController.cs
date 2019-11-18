using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private bool playerNear;
    public float enemySpeed;
    Rigidbody2D rb2d;
    private bool isMoving;
    public bool moveRight;
    public bool moveUp;

    public float enemyNumber;
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hitWall;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        if (hitWall)
        {
            if (enemyNumber == 1)
            {
                moveRight = !moveRight;

            }
            if (enemyNumber == 0)
            {
                moveUp = !moveUp;

            }
        }
        
        if (enemyNumber == 1)
        {
            if (moveRight)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                rb2d.velocity = new Vector2(enemySpeed, rb2d.velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                rb2d.velocity = new Vector2(-enemySpeed, rb2d.velocity.y);
            }
        }

        if (enemyNumber == 0)
        {
            if (moveUp)
            {
                transform.localScale = new Vector3(1f, -1f, 1f);
                rb2d.velocity = new Vector2(rb2d.velocity.x, enemySpeed);
            }

            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                rb2d.velocity = new Vector2(rb2d.velocity.x, -enemySpeed);
            }
        }

        if (GameObject.Find("Player").GetComponent<PlayerController>().detectionNumber == 100)
        {
            enemySpeed = 0;
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
