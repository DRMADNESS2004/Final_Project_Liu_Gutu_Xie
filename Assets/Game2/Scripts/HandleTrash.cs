using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleTrash : MonoBehaviour
{
    [SerializeField]
    private GameObject trash;

    Rigidbody2D trashRb2d;

    //Rigidbody2D playerRb2d;

    [SerializeField]
    private GameObject option1;

    [SerializeField]
    private GameObject option2;

    [SerializeField]
    private GameObject option3;

    // Start is called before the first frame update
    void Start()
    {
        trashRb2d = trash.GetComponent<Rigidbody2D>();
        //playerRb2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == trash)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Constants.ISGRABBED)
                {
                    trashRb2d.bodyType = RigidbodyType2D.Static;
                    Constants.ISGRABBED = false;
                }
                else
                {
                    trashRb2d.bodyType = RigidbodyType2D.Kinematic;
                    Constants.ISGRABBED = true;
                }
            }
        }

        if(collision.gameObject == Input.GetKeyDown(KeyCode.Space))
        {
            if (Constants.ISGRABBED)
            {
                trashRb2d.bodyType = RigidbodyType2D.Static;
                Constants.ISGRABBED = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
