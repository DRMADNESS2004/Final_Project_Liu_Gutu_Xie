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

    [SerializeField]
    private GameObject objTrigger;

    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        objTrigger.GetComponent<Rigidbody2D>().position=rb2d.position;

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
            rb2d.position = new Vector2(Mathf.Clamp(rb2d.position.x, leftBorder, rightBorder), rb2d.position.y);
        }
        if (rb2d.position.y >= downBorder && rb2d.position.y <= topBorder)
        {
            vertical = Input.GetAxis("Vertical");
        }
        else
        {

            vertical = 0f;
            rb2d.velocity = new Vector2(rb2d.velocity.x, vertical);
            rb2d.position = new Vector2(rb2d.position.x, Mathf.Clamp(rb2d.position.y, downBorder, topBorder));
        }

        Vector2 movement = new Vector2(horizontal, vertical);
        rb2d.velocity = movement * speed * Time.deltaTime;
    }

}
