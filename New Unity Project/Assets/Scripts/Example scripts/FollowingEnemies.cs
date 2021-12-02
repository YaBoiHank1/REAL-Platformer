using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemies : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float followingRange = 10f;
    [SerializeField] Transform target;
    [SerializeField] Animator enemyAnimator;

 
    private Rigidbody2D myRigidbody;
    Animator myAnimator;
    BoxCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            return;
        }
        
        if (Vector3.Distance(transform.position, target.position) <= followingRange)
        {
            MoveTowardsTarget();
            
            enemyAnimator.SetBool("isMoving", true);
        }

        if (Vector3.Distance(transform.position, target.position) > followingRange)
        {
            enemyAnimator.SetBool("isMoving", false);
        }
    }

    

    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    void Die()
    {
        Destroy(gameObject);
    }


}
