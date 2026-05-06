using System;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public float speedForce = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private Animator anim;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        // anim = GetComponentInChildren<Animator>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f; // giữ player dính đất

        PlayerMove();
        PlayerJump();
    }

    private void PlayerJump()
    {
        // ===== JUMP =====
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // ===== GRAVITY =====
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void PlayerMove()
    {
        // ===== MOVE =====
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * speedForce * Time.deltaTime);
        }
        else
        {
            controller.Move(move * 6 * Time.deltaTime);
        }

        // ===== ANIMATION =====
        if (move == Vector3.zero)
        {
            anim.SetFloat("Speed", 0);
        }
        // Walk
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", speedForce);
        }
        // Run
        else
        {
            anim.SetFloat("Speed", 6f);
        }
    }


}
