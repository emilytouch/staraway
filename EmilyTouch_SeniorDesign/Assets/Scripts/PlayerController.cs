using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]

/*public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}*/

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int detectionNumber;
    public int energy;
    public Rigidbody2D rb2d;

    private static bool playerExists;
    public Text detectionText;


    //public Boundary boundaryy;

    private Animator playerAnim;
    private bool playerMoving;
    private Vector2 lastMoved;

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
        rb2d = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        detectionNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (Input.GetKeyDown(KeyCode.RightShift) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)))
        {
            speed += 3;
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            speed = 1;
        }

         if(Input.GetAxisRaw("Horizontal")>0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMoved = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMoved = new Vector2(0f, Input.GetAxisRaw("Vertical"));

        }

        if (detectionNumber >= 100)
         {
             detectionNumber = 100;

         }

         if (detectionNumber <= 0)
         {
             detectionNumber = 0;


         }

         if (detectionNumber == 100)
         {
             rb2d.Sleep();
             //gameOverScreen.SetActive(true);
             detectionNumber = 100;

         }

        playerAnim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        playerAnim.SetFloat("MoveY", Input.GetAxis("Vertical"));
        playerAnim.SetBool("PlayerMoving", playerMoving);
        playerAnim.SetFloat("LastMoveX", lastMoved.x);
        playerAnim.SetFloat("LastMoveY", lastMoved.y);
     }
        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.velocity = movement * speed;
        }
    void OnComplete()
    {
        energy -= 1;
    }
}

