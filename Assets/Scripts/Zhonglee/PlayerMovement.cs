using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private Vector2 velocity;
    private float inputAxis;
    public float moveSpeed = 7f;
    public float moveDelay = 2f;

    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);
    public bool onGround { get; private set; }
    public bool isJumping { get; private set; }
    public bool isSliding => (inputAxis > 0f && velocity.x < 0f) || (inputAxis < 0f && velocity.x > 0f);
    public bool isRunning => Mathf.Abs(inputAxis) > 0.10f || Mathf.Abs(velocity.x) > 0.10f;

    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        HorizontalMovement();
        onGround = rb2d.Raycast(0.2f, 0.7f, Vector2.down, LayerMask.GetMask("Ground"));
        if (onGround)
        {
            GroundMovement();
        }
        ApplyGravity();

    }

    private void OnEnable()
    {
        rb2d.isKinematic = false;
    }

    private void OnDisable()
    {
        rb2d.isKinematic = true;
        velocity = Vector2.zero;
        isJumping = false;
    }

    private void FixedUpdate()
    {
        Vector2 position = rb2d.position;
        position += velocity * Time.fixedDeltaTime;
        rb2d.MovePosition(position);
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        if (inputAxis != 0)
        {
            int index = Random.Range(0, 5000);
            if (index == 1)
            {
                AudioManager.instance.PlaySE("dadada");
            }
            else if (index == 2)
            {
                AudioManager.instance.PlaySE("lalala");
            }
        }
        if (inputAxis > 0f) { transform.eulerAngles = Vector3.zero; }
        else if (inputAxis < 0f) { transform.eulerAngles = new Vector3(0f, 180f, 0f); }
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime * moveDelay);
        if (rb2d.Raycast(0.2f, 0.25f, Vector2.right * velocity.x, LayerMask.GetMask("Ground"), LayerMask.GetMask("Wall"))){
            velocity.x = 0;
        }
    }

    private void GroundMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        isJumping = velocity.y > 0f;
        if (Input.GetButtonDown("Jump"))
        {
            Jump(jumpForce);
        }
    }

    public void Jump(float jumpForce)
    {
        AudioManager.instance.PlaySE("jump-small");
        velocity.y = jumpForce;
        isJumping = true;
    }

    private void ApplyGravity()
    {
        bool falling = !Input.GetButton("Jump") || velocity.y < 0f;
        float multiplier = falling ? 2f : 1f;

        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("PowerUp"))
        {
            if (transform.DotProductTest(collision.transform, Vector2.up))
            {
                velocity.y = 0f;
            }
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") || collision.gameObject.layer == LayerMask.NameToLayer("Goomba"))
        {
            if (transform.DotProductTest(collision.transform, Vector2.down))
            {
                velocity.y = jumpForce / 1.5f;
                isJumping = true;
            }
        }
        if (collision.gameObject.tag == "JumpMachine")
        {
            Jump(47f);
        } 
        else if (collision.gameObject.tag == "JumpMachine2")
        {
            Jump(55f);
        }
    }

}
