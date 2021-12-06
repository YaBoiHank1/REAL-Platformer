using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlatformerMovementWithFeet : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed = 1.0f;
	public float jumpSpeed = 1.0f;
    public int health = 1;
    public int flesh;
	private bool grounded = false;
    public bool isAlive;
    public Image HealthIcon;
    public Image HealthBar;

    // Cached component references
    private SpriteRenderer myRenderer;
    private Animator myAnimator;
    CapsuleCollider2D body;
    BoxCollider2D feet;

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
        if (health > 0)
        {
            isAlive = true;
        }
        else if (health <= 0)
        {
            isAlive = false;
        }
        if (isAlive == false)
        {
            return;
        }
        else if (isAlive == true)
        {
            Movement();
            Jump();
        }

        if (health > 5)
        {
            health = 5;
        }
        
        if (health == 1)
        {
            HealthIcon.GetComponent<HealthIcon>().SetImageOne();
            HealthBar.fillAmount = 0.219f;
        }
        if (health == 2)
        {
            HealthIcon.GetComponent<HealthIcon>().SetImageTwo();
            HealthBar.fillAmount = 0.472f;
        }
        if (health == 3)
        {
            HealthIcon.GetComponent<HealthIcon>().SetImageThree();
            HealthBar.fillAmount = 0.632f;
        }
        if (health == 4)
        {
            HealthIcon.GetComponent<HealthIcon>().SetImageFour();
            HealthBar.fillAmount = 0.884f;
        }
        if (health == 5)
        {
            HealthIcon.GetComponent<HealthIcon>().SetImageFive();
            HealthBar.fillAmount = 1f;
        }
    }

    

    public void AddToHealth(int CoinValue)
    {
        health += CoinValue;
    }

    

    public void Movement()
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
    }

    public void Jump()
    {
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
		if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
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
        if (collision.gameObject.layer == 10)
        {

        }
        if (collision.gameObject.layer == 9)
        {
            grounded = true;
            health--;
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
