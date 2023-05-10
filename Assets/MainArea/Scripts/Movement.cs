using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Debug.Log("Has Started");
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updating");
        if (Input.GetKeyDown(KeyCode.D))
            {
            Debug.Log("Attempt to move to the right!");
            }

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        rb2d.MovePosition(transform.position + new Vector3(x, y) * speed * Time.deltaTime);
    }
}