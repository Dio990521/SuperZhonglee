using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction = Vector2.left;

    private Rigidbody2D rb2d;
    private Vector2 velocity;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
        if (gameObject.tag == "Koopa1")
        {
            Destroy(gameObject);
        }
        
    }

    private void OnEnable()
    {
        rb2d.WakeUp();
    }

    private void OnDisable()
    {
        velocity = Vector2.zero;
        rb2d.Sleep();
    }

    private void FixedUpdate()
    {
        velocity.x = direction.x * speed;
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;
        rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);

        if (rb2d.Raycast(0.2f, 0.37f, direction, LayerMask.GetMask("Ground"), LayerMask.GetMask("Wall")))
        {
            direction = -direction;
            GetComponent<SpriteRenderer>().flipX = direction.x > 0 ? true : false;
            
        }
        if (rb2d.Raycast(0.2f, 0.6f, Vector2.down, LayerMask.GetMask("Ground"), LayerMask.GetMask("Wall")))
        {
            velocity.y = Mathf.Max(velocity.y, 0f);
        }
    }
}
