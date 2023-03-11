using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rb2d;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 movDir = (target.transform.position - transform.position).normalized * speed;
        rb2d.velocity = new Vector2(movDir.x, movDir.y);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (!player.starPower)
            {
                if (player.isShield)
                {
                    player.isShield = false;
                    Destroy(gameObject);
                }
                else
                {
                    player.Hit();
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall" || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }

}
