﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("breakable"))
        {
            other.GetComponent<pot>().Smash();
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                if (other.gameObject.CompareTag("enemy"))
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime);
                }

                if (other.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<playerMovement>().currentState = PlayerState.stagger;
                    other.GetComponent<playerMovement>().Knock(knockTime);
                }

                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
            }
        }
    }
}
