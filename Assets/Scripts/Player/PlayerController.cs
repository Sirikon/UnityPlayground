﻿using UnityEngine;
using System.Collections;

/// <summary>
/// This class is the main Player Controller
/// </summary>
public class PlayerController : MonoBehaviour {

    [Range(0.0f, 100.0f)]
    public float movementSpeed;
    [Range(0.0f, 100.0f)]
    public float runMultiplier = 1.0f;
    [Range(0.0f, 50.0f)]
    public float jumpForce;

    private Rigidbody2D rigidbody2D;
    private FloorContact floorContact;
    private Animator animator;

    void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        floorContact = transform.FindChild("FloorContact").gameObject.GetComponent<FloorContact>();
        animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        if (CanJump()) {
            Jump();
        }
        CheckFlying();
	}

    void Move() {

        float horizontalAxis = Input.GetAxis("Horizontal");

        transform.Translate((Vector3.right * horizontalAxis * movementSpeed * (Input.GetButton("Run") ? runMultiplier : 1) ) * Time.deltaTime);

        if (horizontalAxis != 0){
            animator.SetBool("Walking", true);

            if (Input.GetButton("Run")) {
                animator.SetBool("Running", true);
            } else {
                animator.SetBool("Running", false);
            }

        } else {
            animator.SetBool("Walking", false);
        }

        if (horizontalAxis < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if(horizontalAxis > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    void Jump() {
        if (Input.GetButtonDown("Jump")) {
            rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void CheckFlying() {
        if (!floorContact.isTouching) {
            animator.SetBool("Flying", true);

            if (rigidbody2D.velocity.y < 0) {
                animator.SetBool("Flying Down", true);
            } else {
                animator.SetBool("Flying Down", false);
            }

        } else {
            animator.SetBool("Flying", false);
            animator.SetBool("Flying Down", false);
        }
    }

    bool CanJump() {
        return floorContact.isTouching;
    }
}
