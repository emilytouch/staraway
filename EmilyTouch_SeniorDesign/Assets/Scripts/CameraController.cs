using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool isFollowing;

    public float xOffset;
    public float yOffset;

    // Use this for initialization
    void Start()
    {
        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            transform.position = new Vector3(FindObjectOfType<PlayerController>().transform.position.x + xOffset, FindObjectOfType<PlayerController>().transform.position.y + yOffset, transform.position.z);
        }
    }
}
