using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool isWalking;

    private Rigidbody2D rb2d;
    private Animator anim;

    private Vector3 tilePosition;
    private Vector3 moveToPosition;

    public Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Get the center position of the starting tile
        tilePosition = tilemap.GetCellCenterWorld(tilemap.WorldToCell(transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWalking)
        {
            // Get the tile movement direction
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 tileDirection = new Vector2(horizontal, vertical);

            // Make character move in one direction at a time only (no diagonals)
            if (tileDirection.x != 0)
            {
                tileDirection.y = 0;
            }
            else if (tileDirection.y != 0)
            {
                tileDirection.x = 0;
            }

            if (tileDirection != Vector2.zero)
            {
                // Calculate the center position of the next tile
                Vector3 nextTile = tilePosition + new Vector3(tileDirection.x, tileDirection.y, 0);
                nextTile = tilemap.GetCellCenterWorld(tilemap.WorldToCell(nextTile));

                // Set the animation parameters
                anim.SetFloat("input_x", tileDirection.x);
                anim.SetFloat("input_y", tileDirection.y);

                // Start the movement coroutine
                StartCoroutine(Move(nextTile));
            }

            anim.SetBool("isWalking", isWalking);
        }
    }

    IEnumerator Move(Vector3 newPos)
    {
        isWalking = true;

        // Get the position of the center of the next tile
        Vector3Int nextCell = tilemap.WorldToCell(newPos);
        Vector3 nextTilePos = tilemap.GetCellCenterWorld(nextCell);

        // Adjust the position of the character to align with the center of the tile
        Vector3 characterPos = nextTilePos;
        characterPos.y += 0.5f; // Assumes that the character is 1 unit tall

        while (Vector3.Distance(transform.position, characterPos) > 0.01f)
        {
            // Move towards the center of the next tile
            transform.position = Vector3.MoveTowards(transform.position, characterPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Update the tile position and set isWalking to false
        tilePosition = nextTilePos;
        isWalking = false;
    }

}
