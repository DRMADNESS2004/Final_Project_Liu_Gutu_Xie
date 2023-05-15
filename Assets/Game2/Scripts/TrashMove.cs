using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Constants.ISGRABBED)
        {

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontal, vertical);
            rb2d.velocity = movement * speed;

            if (rb2d.position.x <= Constants.LBORDER)
            {
                rb2d.position = new Vector2(Constants.LBORDER, rb2d.position.y);
            }
            else if(rb2d.position.x >= Constants.RBORDER)
            {
                rb2d.position = new Vector2(Constants.RBORDER, rb2d.position.y);
            }
        
            if (rb2d.position.y <= Constants.BBORDER)
            {
                rb2d.position = new Vector2(rb2d.position.x, Constants.BBORDER);
            }
            else if(rb2d.position.y >= Constants.TBORDER)
            {
                rb2d.position = new Vector2(rb2d.position.x, Constants.TBORDER);
            }
        }
    }
}
