using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk, run, attack, interact
}

public class playerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D RigidBody;
    private Vector3 change;
    private Animator animator;

	// Use this for initialization
	void Start()
    {
        animator = GetComponent<Animator>();
        RigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }

        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            speed = 16;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            speed = 8;
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.1f); // Allow animation cancel
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
            animator.SetBool("moving", false);
    }

    void MoveCharacter()
    {
        RigidBody.MovePosition(transform.position + (change.normalized * speed * Time.deltaTime));
    }
}
