using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public Sprite flatSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            if (gameObject.tag != "FireEnemy")
            {
                Hit();
            }
            else
            {
                AudioManager.instance.PlaySE("bowserfire");
            }
            
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.starPower)
            {
                Hit();
            }
            else
            {
                if (collision.transform.DotProductTest(transform, Vector2.down))
                {
                    Flatten();
                }
                else
                {
                    if (player.isShield)
                    {
                        player.isShield = false;
                        Flatten();
                    }
                    else
                    {
                        player.Hit();
                    }
                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shell") || collision.gameObject.tag == "Stab")
        {
            Hit();
        }
    }

    private void Flatten()
    {
        AudioManager.instance.PlaySE("stomp");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        EntityMovement entityMovement = GetComponent<EntityMovement>();
        if (entityMovement != null)
        {
            GetComponent<EntityMovement>().enabled = false;
        }
        
        GetComponent<SpriteRenderer>().sprite = flatSprite;
        Destroy(gameObject, 1f);
    }

    private void Hit()
    {
        AudioManager.instance.PlaySE("kick");
        GetComponent<EnemyDeathAnimation>().enabled = true;
        GetComponent<AnimatedSprite>().enabled = false;
        Destroy(gameObject, 3f);
    }
}
