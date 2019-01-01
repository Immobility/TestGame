using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Log : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public Transform homePosition;
    public float chaseRadius;
    public float attackRadius;
    public float wakeRadius;

    // Use this for initialization
    void Start()
    {
        currentState = EnemyState.idle;
        change = Vector3.zero;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();

    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius && currentState == EnemyState.idle2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            animator.SetBool("walkToPlayer", true);
            currentState = EnemyState.attack; // Also sets Attack bool to true
        }

        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            currentState = EnemyState.idle2;
            animator.SetBool("walkToPlayer", false);
        }

        if (Vector3.Distance(target.position, transform.position) <= wakeRadius)
        {
            animator.SetBool("isWake", true);
            currentState = EnemyState.idle2;
        }

        else
        {
            currentState = EnemyState.idle;
            animator.SetBool("isWake", false);
        }
    }


}
