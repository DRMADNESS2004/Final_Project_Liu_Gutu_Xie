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
                    trashRb2d.bodyType = RigidbodyType2D.Kinematic;
                    Constants.ISGRABBED = false;
                    Debug.Log(Constants.ISGRABBED);
                }
                else
                {   
                    trashRb2d.bodyType = RigidbodyType2D.Kinematic;
                    Constants.ISGRABBED = true;
                    Debug.Log(Constants.ISGRABBED);
                }
            }
        }
        else
        {
            trashRb2d.bodyType = RigidbodyType2D.Kinematic;
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
