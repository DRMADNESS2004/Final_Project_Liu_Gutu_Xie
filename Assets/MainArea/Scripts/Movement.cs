using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb2d;

    private Vector3 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);

        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);

        //}

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);

        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);

        //}

    }

    private void FixedUpdate()
    {
        rb2d.velocity = movementDirection * speed * Time.deltaTime;
    }
}
