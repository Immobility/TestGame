﻿using System.Collections;
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
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;

	// Use this for initialization
	void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", 0);
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
        myRigidBody.MovePosition(transform.position + (change.normalized * speed * Time.deltaTime));
    }
}
