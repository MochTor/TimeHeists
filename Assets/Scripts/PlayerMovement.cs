using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    public Camera mainCamera;
    public float rotationSensibility = 100;
    public float moveSpeed = 10;
    public float jumpForce = 10;
    private Rigidbody rigidBody;
    private CapsuleCollider capsuleCollider;
    private Animator animator;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private bool isJumping;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        float x = CrossPlatformInputManager.GetAxis("Mouse Y"); //Rotazione attorno ad asse x della camera
        float y = CrossPlatformInputManager.GetAxis("Mouse X"); //Rotazione attorno ad asse y dells camera
        isJumping = CrossPlatformInputManager.GetButton("Jump");


        x *= -Time.deltaTime * rotationSensibility;
        y *= Time.deltaTime * rotationSensibility;

        print(mainCamera.transform.rotation.eulerAngles.x);

        if (mainCamera.transform.rotation.x < 90 && mainCamera.transform.rotation.x > -90) {
            mainCamera.transform.Rotate(x, 0, 0);
        } else {
            mainCamera.transform.Rotate(0, 0, 0);
        }

        transform.Rotate(0, y, 0);

        moveInput = new Vector3(h, 0f, v);
        moveVelocity = transform.forward * moveSpeed * moveInput.sqrMagnitude;

        if (isJumping) {
            rigidBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        if (v != 0)
        {
            animator.SetBool("isWalking", true);
            if (v > 0)
            {
                animator.SetFloat("walkingDirection", 1.0f);
            }
            else if (v < 0)
            {
                animator.SetFloat("walkingDirection", -1.0f);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
		
	}

	void FixedUpdate() {
        rigidBody.velocity = moveVelocity;
	}
}