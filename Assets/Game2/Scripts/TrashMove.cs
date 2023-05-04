using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    private GameObject player;

    //rotation
    //private Vector2 rotationPoint;

    [SerializeField]
    private float rotationAngle=10f;

    [SerializeField]
    private float moveForce=100f;

    [SerializeField]
    private float speed;

    public float rotationDistance = 1f;

    public bool grabbedOnce=true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Constants.ISGRABBED)
        {
            //rotation
            //rotationPoint = player.GetComponent<Rigidbody2D>().position;

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

            //rotation of garbage
            /*if (Input.GetKey(KeyCode.D))
            {
                Debug.Log(1);
                Vector2 offset = rb2d.worldCenterOfMass - rotationPoint;
                Quaternion rotation = Quaternion.Euler(0, 0, rotationAngle);
                Vector2 rotatedOffset = rotation * offset;
                Vector2 targetPosition = rotationPoint + rotatedOffset;
                rb2d.MovePosition(targetPosition);
                rb2d.MoveRotation(rb2d.rotation + rotationAngle);

                rotationPoint = player.GetComponent<Rigidbody2D>().position;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log(2);
                Vector2 offset = rb2d.worldCenterOfMass - rotationPoint;
                Quaternion rotation = Quaternion.Euler(0, 0, -rotationAngle);
                Vector2 rotatedOffset = rotation * offset;
                Vector2 targetPosition = rotationPoint + rotatedOffset;
                rb2d.MovePosition(targetPosition);
                rb2d.MoveRotation(rb2d.rotation - rotationAngle);

                rotationPoint = player.GetComponent<Rigidbody2D>().position;
            }*/
        }
    }
}
