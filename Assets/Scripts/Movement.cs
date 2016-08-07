using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private Animator animator;

    public float speed;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector3(horizontal, vertical) * speed;

        if (horizontal > 0)
        {
            animator.SetInteger("Direction", 3);
        }
        else if (horizontal < 0)
        {
            animator.SetInteger("Direction", 1);
        }

        if (vertical > 0 && Mathf.Abs(vertical) > Mathf.Abs(horizontal))
        {
            animator.SetInteger("Direction", 2);
        }
        else if (vertical < 0 && Mathf.Abs(vertical) > Mathf.Abs(horizontal))
        {
            animator.SetInteger("Direction", 0);
        } 

        animator.SetBool("Walking", vertical != 0 || horizontal != 0);
    }

}
