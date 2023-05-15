using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator anim;

    //sprint/run mode *OPTIONAL*
    [SerializeField]
    private float RunSpeed = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //arrow keys
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        //if player touches a direction, it will increase one of the inputs therefor making isWalking > 0.
        bool isWalking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;

        //make the Transition bool true to make animation start.
        anim.SetBool("is_walking", isWalking);

        if (isWalking) //don't need to put == true since its == true by default
        {
            anim.SetFloat("position_x", input_x); //arrow key value (0 or 1)
            anim.SetFloat("position_y", input_y); // ^^^^^

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime * RunSpeed; //Normalized makes it 1 or 0, the time.deltaTime makes it work the frames, and RunSpeed to make your character sprint.
            }
            else
            {
                transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime;
            }
        }
    }
}
