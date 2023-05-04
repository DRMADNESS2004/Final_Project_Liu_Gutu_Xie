using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D playerRb2d;

    [SerializeField]
    private int speed=10;

    [SerializeField]
    private GameObject objTrigger;

    [SerializeField]
    private float rotationAngle=10f;

    void Start()
    {
        playerRb2d= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        objTrigger.GetComponent<Rigidbody2D>().position= playerRb2d.position;

        float horizontal= Input.GetAxis("Horizontal");
        float vertical= Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(horizontal, vertical);
        playerRb2d.velocity = movement * speed;

        if (playerRb2d.position.x <= Constants.LBORDER)
        {
            playerRb2d.position = new Vector2(Constants.LBORDER, playerRb2d.position.y);
        }
        else if(playerRb2d.position.x >= Constants.RBORDER)
        {
            playerRb2d.position = new Vector2(Constants.RBORDER, playerRb2d.position.y);
        }
        
        if (playerRb2d.position.y <= Constants.BBORDER)
        {
            playerRb2d.position = new Vector2(playerRb2d.position.x, Constants.BBORDER);
        }
        else if(playerRb2d.position.y >= Constants.TBORDER)
        {
            playerRb2d.position = new Vector2(playerRb2d.position.x, Constants.TBORDER);
        }
       
    }

}
