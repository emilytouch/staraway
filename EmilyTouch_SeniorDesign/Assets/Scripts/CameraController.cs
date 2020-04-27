using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool isFollowing;

    public float xOffset;
    public float yOffset;
    private Vector2 position;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;

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
            GameObject.FindGameObjectWithTag("Player");
            transform.position = new Vector3(FindObjectOfType<PlayerController>().transform.position.x + xOffset, FindObjectOfType<PlayerController>().transform.position.y + yOffset, transform.position.z);
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                transform.position.z);
        }
    }

}
