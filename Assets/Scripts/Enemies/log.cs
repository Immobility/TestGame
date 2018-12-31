using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Log : Enemy
{
    public Transform target;
    public Transform homePosition;
    public float chaseRadius;
    public float attackRadius;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update()
    {
        isAwake();
        CheckDistance();
        
	}

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            animator.SetBool("seePlayer", true);
            currentState = EnemyState.attack; // Also sets Attack bool to true
        }
        else
        {
            currentState = EnemyState.idle2;
            animator.SetBool("seePlayer", false);
        }
    }

    void isAwake()
    {
        if (Vector3.Distance(target.position, transform.position) <= 6 )
        {
            animator.SetBool("isWake", true);
            currentState = EnemyState.idle2;
        }
    }


}
