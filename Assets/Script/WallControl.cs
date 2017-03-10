using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private Rigidbody2D rgbd2d;

    // Use this for initialization
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        rgbd2d.velocity = new Vector2(-moveSpeed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
}
