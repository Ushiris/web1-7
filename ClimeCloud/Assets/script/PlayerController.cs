using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D 
        rigid2D;
    Animator
        animator;
    float
        jumpForce = 300.0f,
        walkForce = 30.0f,
        maxWalkSpeed = 2.0f;

	// Use this for initialization
	void Start ()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space)&& Mathf.Abs(rigid2D.velocity.y)<=0.1)
        {
            rigid2D.AddForce(transform.up * jumpForce);
        }

        int key = 0;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        float speedx = Mathf.Abs(rigid2D.velocity.x);

        if(speedx<maxWalkSpeed)
        {
            rigid2D.AddForce(transform.right * key * walkForce);
        }
        
        animator.speed = speedx / 2.0f;
	}
}
