using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 8f; // The speed at which the character moves horizontally
    public float jumpForce = 8f; // The force of the jump
    public float jumpNum = 1f;
    public float speedReset = 0f;

    private Rigidbody2D rb2d; // Reference to the Rigidbody2D component
    private bool isJumping;
    private bool speedBoost;


    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        float moveX = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveX * speed, rb2d.velocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // Add a vertical force to the Rigidbody2D
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            jumpNum = jumpNum + 1f;
        }
        if (jumpNum == 2)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (speedBoost == true)
        {
            speedReset += Time.deltaTime;
        }
        if (speedReset >= 5f)
        {
            speed = 8f;
            speedReset = 0f;
            speedBoost = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpNum = 0f;
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            jumpNum = 0f;
            speedBoost = true;
            isJumping = false;
            speedReset = 0f;

            if (speed <= 15f)
            {
                speed += 1f;
            }
        }
    }
}