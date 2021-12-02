using UnityEngine;
using System.Collections;

public class PlatformerMovementWithFeet : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed = 1.0f;
	public float jumpSpeed = 1.0f;
	private bool grounded = false;
    private Animator myAnimator;
    private SpriteRenderer myRenderer;
    public bool isAlive;

	void Start ()
    {
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator.SetBool("Moving", false);
        isAlive = true;
	}

	// Update is called once per frame
	void Update ()
    {
        if (isAlive == false)
        {
            return;
        }
        else if (isAlive == true)
        {
            var moveX = Input.GetAxis("Horizontal");
            var velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            velocity.x = moveX * moveSpeed;
            gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
            if (velocity.x > 0 || velocity.x < 0)
            {
                myAnimator.SetBool("Moving", true);
            }
            else if (velocity.x == 0)
            {
                myAnimator.SetBool("Moving", false);
            }
            if (Input.GetButtonDown("Jump") && grounded)
            {
                myAnimator.SetBool("Jumping", true);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                myRenderer.flipX = false;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                myRenderer.flipX = true;
            }
        }
		
    }

	public void Grounded()
    {
		grounded = true;
	}

	public void NotGrounded()
    {
		grounded = false;
	}

    public void StopAnimations()
    {
        myAnimator.speed = 0;
    }

	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.layer == 8) {
			grounded = false;
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
            myAnimator.speed = 1;
            myAnimator.SetBool("Jumping", false);
        }
        if (collision.gameObject.layer == 9)
        {
            isAlive = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
        }
    }
}
