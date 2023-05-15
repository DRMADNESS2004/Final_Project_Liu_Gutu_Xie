using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleTrash : MonoBehaviour
{
    [SerializeField]
    private GameObject trash;

    Rigidbody2D trashRb2d;

    private bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        trashRb2d = trash.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Constants.ISGRABBED)
                {
                    if (trashRb2d != null) // Check if the object has been destroyed before using it
                    {
                        trashRb2d.bodyType = RigidbodyType2D.Kinematic;
                    }
                    else
                    {
                        Debug.Log("trashrb2d is null");
                    }
                    Constants.ISGRABBED = false;
                    Debug.Log(Constants.ISGRABBED);
                }
                else
                {
                    if (trashRb2d != null) // Check if the object has been destroyed before using it
                    {
                        trashRb2d.bodyType = RigidbodyType2D.Kinematic;
                    }
                    else
                    {
                        Debug.Log("trashrb2d is null");
                    }
                    Constants.ISGRABBED = true;
                    Debug.Log(Constants.ISGRABBED);
                }
            }
        }
        else
        {
            if (trashRb2d != null) // Check if the object has been destroyed before using it
            {
                trashRb2d.bodyType = RigidbodyType2D.Kinematic;
                trashRb2d.velocity = Vector2.zero;
            }
            Constants.ISGRABBED = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == trash)
        {
            inRange = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == trash)
        {
            inRange= true;
        }
    }
}
