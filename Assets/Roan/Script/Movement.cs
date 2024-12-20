using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 200f; // The speed at which the character moves horizontally
    public float jumpForce = 200f; // The force of the jump
    public float jumpNum = 1f;

    public float speedReset = 0f;
    private bool speedBoost;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private Rigidbody2D rb2d;
    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movment
        if (Input.GetKey(left))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        // Flips sprite
        if (rb2d.velocity.x < 0f)
        {
            transform.localScale = new Vector3(-177, 177, 322);
        }
        else if (rb2d.velocity.x > 0)
        {
            transform.localScale = new Vector3(177, 177, 322);
        }
        // Jump
        if (Input.GetKeyDown(jump) && !isJumping)
        {
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
            moveSpeed = 200f;
            speedReset = 0f;
            speedBoost = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Touch ground");
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

            if (moveSpeed <= 400f)
            {
                moveSpeed += 10f;
            }
        }
    }
}