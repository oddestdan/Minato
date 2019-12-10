using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float gravity = -35f;
    public float groundDst = 0.4f;
    public float jumpHeight = 2f;

    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    float speed = 6f;
    bool isRunning = false;

    // Update is called once per frame
    void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDst, groundMask);

        if (isGrounded && velocity.y < 0f) {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        // Check for running
        if (Input.GetButtonDown("Shift")) {
            SetWalkRunSpeed();
        }

        // Transforms for local system instead of global 
        Vector3 moveDst = transform.right * x + transform.forward * z;
        controller.Move(moveDst * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Sets inversed speed to current speed
    void SetWalkRunSpeed() {
        if (isRunning) {
            speed = walkSpeed;
            isRunning = false;
        } else {
            speed = runSpeed;
            isRunning = true;
        }
    }
}
