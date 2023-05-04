using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private bool isWalking;

    private Rigidbody2D rb2d;
    private Animator anim;

    private Vector2 movement;
    private Vector3 moveToPosition;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isWalking)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            //Make character move in one direction at a time only (no diagonals)
            if (movement.x != 0)
            {
                movement.y = 0;
            }

            if (movement.y != 0)
            {
                movement.x = 0;
            }

            //
            if (movement != Vector2.zero)
            {
                moveToPosition = transform.position + new Vector3(movement.x, movement.y, 0); // +-1
                anim.SetFloat("input_x", movement.x);
                anim.SetFloat("input_y", movement.y);

                StartCoroutine(Move(moveToPosition));
            }

            anim.SetBool("isWalking", isWalking);
        }
    }

    IEnumerator Move(Vector3 newPos)
    {
        isWalking = true;

        while ((newPos - transform.position).sqrMagnitude > Mathf.Epsilon) // Comparing to smallest float > 0
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.fixedDeltaTime);
            yield return null;
        }

        transform.position = newPos;
        isWalking = false;

        transform.Translate(movement.x * moveSpeed * Time.fixedDeltaTime, movement.y * moveSpeed * Time.fixedDeltaTime, 0);
    }
}
