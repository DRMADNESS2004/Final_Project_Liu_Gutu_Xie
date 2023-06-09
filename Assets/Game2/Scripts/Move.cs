using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update

    Animator ani;
    Rigidbody2D rb2d;

    [SerializeField]
    private int speed = 10;

    [SerializeField]
    private GameObject objTrigger;

    void Start()
    {
        ani = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ani.speed = 1;
        float val_x = Input.GetAxis("Horizontal");
        float val_y = Input.GetAxis("Vertical");

        objTrigger.GetComponent<Rigidbody2D>().position = rb2d.position;

        if (val_x < 0)
        {
            ani.SetInteger("direction", (int)MoveDirection.LEFT);
        }
        else if (val_x > 0)
        {
            ani.SetInteger("direction", (int)MoveDirection.RIGHT);
        }
        else if (val_y < 0)
        {
            ani.SetInteger("direction", (int)MoveDirection.DOWN);
        }
        else if (val_y > 0)
        {
            ani.SetInteger("direction", (int)MoveDirection.UP);
        }
        else
        {
            ani.speed = 0;
        }

        Vector2 move = new Vector2(val_x, val_y);
        rb2d.velocity = move * speed;
        //rb2d.MovePosition(rb2d.position + (move * 10 * Time.deltaTime));


        if (rb2d.position.x <= Constants.LBORDER)
        {
            rb2d.position = new Vector2(Constants.LBORDER, rb2d.position.y);
        }
        else if (rb2d.position.x >= Constants.RBORDER)
        {
            rb2d.position = new Vector2(Constants.RBORDER, rb2d.position.y);
        }

        if (rb2d.position.y <= Constants.BBORDER)
        {
            rb2d.position = new Vector2(rb2d.position.x, Constants.BBORDER);
        }
        else if (rb2d.position.y >= Constants.TBORDER)
        {
            rb2d.position = new Vector2(rb2d.position.x, Constants.TBORDER);
        }
    }
}

public enum MoveDirection
{
    NONE = 0,
    UP = 1,
    DOWN = 2,
    LEFT = 3,
    RIGHT = 4,
}