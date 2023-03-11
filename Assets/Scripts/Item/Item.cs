using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroomColumn,
        MagicMushroomBomb,
        Starman,
        JumpMachine,
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type != Type.JumpMachine)
        {
            if (collision.CompareTag("Player"))
            {
                Collect(collision.gameObject);
            }
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.MagicMushroomColumn:
                if (!GameManager.instance.isColumnSkillOn)
                {
                    AudioManager.instance.PlaySE("powerup");
                    GameObject.Find("Zhonglee").GetComponent<ColumnSkill>().enabled = true;
                    GameManager.instance.isColumnSkillOn = true;
                }
                break;
            case Type.MagicMushroomBomb:
                if (!GameManager.instance.isBombSkillOn)
                {
                    AudioManager.instance.PlaySE("powerup");
                    GameObject.Find("Zhonglee").GetComponent<BombSkill>().enabled = true;
                    GameManager.instance.isBombSkillOn = true;
                }
                break;
            case Type.Starman:
                player.GetComponent<Player>().StarPower();
                break;
            case Type.Coin:
                AudioManager.instance.PlaySE("coin");
                GameManager.instance.AddCoin();
                break;
            case Type.ExtraLife:
                AudioManager.instance.PlaySE("1-up");
                GameManager.instance.AddLife();
                break;
        }
        Destroy(gameObject);
    }

}
