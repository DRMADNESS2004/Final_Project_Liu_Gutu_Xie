using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float downBorder;

    [SerializeField]
    private float leftBorder;

    [SerializeField]
    private float rightBorder;

    [SerializeField]
    private float topBorder;

    Rigidbody2D rb2d;

    [SerializeField]
    private int speed=10;

    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal;
        float vertical;

        if (rb2d.position.x >= leftBorder && rb2d.position.x <= rightBorder)
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        else
        {
            horizontal = 0f;
            rb2d.velocity = new Vector2(horizontal, rb2d.velocity.y);
        }
        if (rb2d.position.y >= downBorder && rb2d.position.y <= topBorder)
        {
            vertical = Input.GetAxis("Vertical");
        }
        else
        {
            vertical = 0f;
            rb2d.velocity = new Vector2(rb2d.velocity.x, vertical);
        }

        Vector2 movement = new Vector2(horizontal, vertical);
        rb2d.velocity = movement * speed * Time.deltaTime;
    }

}
