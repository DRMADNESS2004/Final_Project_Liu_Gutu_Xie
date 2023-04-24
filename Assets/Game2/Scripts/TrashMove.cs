using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float left;
    [SerializeField] 
    private float right;
    [SerializeField] 
    private float top;
    [SerializeField] 
    private float bottom;

    Rigidbody2D playerRb2d;

    Renderer renderer; 
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        renderer= GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = renderer.bounds;
        float width = bounds.size.x;
        float height = bounds.size.y;

        if (Constants.ISGRABBED && Input.GetKey(KeyCode.D))
        {
            rb2d.MovePosition(rb2d.position+new Vector2(playerRb2d.position.x+width, playerRb2d.position.y));
        }
        if (Constants.ISGRABBED && Input.GetKey(KeyCode.A))
        {
            rb2d.MovePosition(rb2d.position + new Vector2(playerRb2d.position.x - width, playerRb2d.position.y));
        }
        if (Constants.ISGRABBED && Input.GetKey(KeyCode.W))
        {
            rb2d.MovePosition(rb2d.position + new Vector2(playerRb2d.position.x, playerRb2d.position.y + height));
        }
        if (Constants.ISGRABBED && Input.GetKey(KeyCode.S))
        {
            rb2d.MovePosition(rb2d.position + new Vector2(playerRb2d.position.x, playerRb2d.position.y - height));
        }

    }
}
