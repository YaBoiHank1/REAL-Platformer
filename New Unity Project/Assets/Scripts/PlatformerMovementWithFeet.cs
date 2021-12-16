using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlatformerMovementWithFeet : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed = 1.0f;
    public float climbSpeed = 1.0f;
	public float jumpSpeed = 1.0f;
    public int health = 1;
    public float flashTime;
    public int flesh;
	private bool grounded = false;
    public bool isAlive;
    public bool canClimb;
    bool escPressed;
    public Image HealthIcon;
    public Image HealthBar;
    public Canvas deathCanvas;
    public Canvas pauseCanvas;
    public AudioClip jumpFX;
    public AudioClip hurtFX;
    public AudioClip deathFX;
    public Color damageColor;
    public Color healthUpColor;
    public Color defaultColor;

    // Cached component references
    private SpriteRenderer myRenderer;
    private Animator myAnimator;
    CapsuleCollider2D body;
    BoxCollider2D feet;
    Rigidbody2D myRigidbody;
    float GravityScaleInit;
    

    void Start ()
    {
        
        feet = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        GravityScaleInit = myRigidbody.gravityScale;
        defaultColor = myRenderer.color;
        myAnimator.SetBool("Moving", false);
        isAlive = true;
        escPressed = false;
        deathCanvas.enabled = false;
        pauseCanvas.enabled = false;
        
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
            HealthBar.fillAmount = 0f;
            isAlive = false;
            deathCanvas.enabled = true;
            
        }
        if (isAlive == false)
        {
            return;
        }
        else if (isAlive == true)
        {
            Movement();
            Jump();
            ClimbLadder();
            PauseMenu();
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

    public void PauseMenu()
    {
        if (Input.GetButtonDown("Cancel") && escPressed == false)
        {
            Time.timeScale = 0;
            pauseCanvas.enabled = true;
            escPressed = true;
        }
        else if (Input.GetButtonDown("Cancel") && escPressed == true)
        {
            Time.timeScale = 1;
            pauseCanvas.enabled = false;
            escPressed = false;
        }
    }

    public void AddToHealth(int CoinValue)
    {
        health += CoinValue;
        //healthFlash();
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

    public void ClimbLadder()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ladders")))
        {
            //canClimb = false;
            myAnimator.SetBool("Climbing", false);
            myRigidbody.gravityScale = GravityScaleInit;
            return;
            
        }
        //canClimb = true;
        float controlThrow = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, controlThrow * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;
        bool VertSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing", true);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            
            myAnimator.SetBool("Jumping", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
            AudioSource.PlayClipAtPoint(jumpFX, Camera.main.transform.position);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            grounded = true;
            myAnimator.speed = 1;
            health--;
            damageFlash();
            AudioSource.PlayClipAtPoint(hurtFX, Camera.main.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            grounded = true;
            myAnimator.speed = 1;
            canClimb = true;
        }
        if (collision.gameObject.layer == 11)
        {
            health = 0;
            AudioSource.PlayClipAtPoint(deathFX, Camera.main.transform.position);
        }
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
            myAnimator.speed = 1;
            myAnimator.speed = 1;
            myAnimator.SetBool("Jumping", false);
        }
        if (collision.gameObject.layer == 9)
        {
            grounded = true;
            myAnimator.speed = 1;
            health--;
            AudioSource.PlayClipAtPoint(hurtFX, Camera.main.transform.position);
            damageFlash();
        }
        if (collision.gameObject.layer == 13)
        {
            FindObjectOfType<DialougeTrigger>().TriggerDialouge();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            grounded = true;
            canClimb = true;
            myAnimator.speed = 1;
        }
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
            myAnimator.speed = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            canClimb = false;
        }
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            grounded = false;
        }
    }

    void damageFlash()
    {
        myRenderer.color = damageColor;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        myRenderer.color = defaultColor;
    }
}
