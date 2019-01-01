using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle, idle2, attack, stagger, dead
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    
    public Vector3 change;
    public Animator animator;

	// Use this for initialization
	void Start()
    {

	}
	
	// Update is called once per frame
	void Update()
    {
		
	}
}
