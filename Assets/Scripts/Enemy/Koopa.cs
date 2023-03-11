using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    public Sprite shellSprite;
    public float shellSpeed = 10f;

    private bool shelled;
    private bool pushed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!shelled && collision.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            Hit();
        }

        if (!shelled && collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.starPower)
            {
                Hit();
            }
            else if (collision.transform.DotProductTest(transform, Vector2.down))
            {
                EnterShell();
            }
            else
            {
                if (player.isShield)
                {
                    player.isShield = false;
                    EnterShell();
                }
                else
                {
                    player.Hit();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bomb")
        {
            Hit();
        }

        if (shelled && pushed && collision.gameObject.layer == LayerMask.NameToLayer("Fireball")){
            Destroy(collision.gameObject);
        }

        if (shelled && collision.gameObject.CompareTag("Player")){
            if (!pushed)
            {
                Vector2 direction = new Vector2(transform.position.x - collision.gameObject.transform.position.x, 0f);
                PushShell(direction);
            }
            else
            {
                
                Player player = collision.gameObject.GetComponent<Player>();
                if (player.starPower)
                {
                    Hit();
                }
                else
                {
                    if (player.isShield)
                    {
                        player.isShield = false;
                        Hit();
                    }
                    else
                    {
                        player.Hit();
                    }
                }
                
            }
        }
        else if (!shelled && collision.gameObject.layer == LayerMask.NameToLayer("Shell") || collision.gameObject.tag == "Stab")
        {
            Hit();
        }
    }

    private void EnterShell()
    {
        AudioManager.instance.PlaySE("stomp");
        shelled = true;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = shellSprite;
    }

    private void PushShell(Vector2 direction)
    {
        AudioManager.instance.PlaySE("kick");
        pushed = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
        EntityMovement entityMovement = GetComponent<EntityMovement>();
        entityMovement.direction = direction.normalized;
        entityMovement.speed = shellSpeed;
        entityMovement.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Shell");
    }

    private void Hit()
    {
        AudioManager.instance.PlaySE("kick");
        GetComponent<EnemyDeathAnimation>().enabled = true;
        GetComponent<AnimatedSprite>().enabled = false;
        Destroy(gameObject, 3f);
    }
}
