using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Type type;
    public enum Type
    {
        DeadZone,
        Stab,
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (type)
        {
            case Type.DeadZone:
                if (collision.gameObject.tag == "Player")
                {
                    Player player = collision.gameObject.GetComponent<Player>();
                    player.Hit();
                }
                else
                {
                    Destroy(collision.gameObject);
                }
                break;
            case Type.Stab:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (type)
        {
            case Type.DeadZone:
                break;
            case Type.Stab:
                if (collision.gameObject.tag == "Player")
                {
                    Player player = collision.gameObject.GetComponent<Player>();
                    if (!player.starPower)
                    {
                        if (player.isShield)
                        {
                            player.isShield = false;
                            player.GetComponent<PlayerMovement>().Jump(20f);
                        }
                        else
                        {
                            player.Hit();
                        }
                    }
                }
                break;
        }
        
    }
}
