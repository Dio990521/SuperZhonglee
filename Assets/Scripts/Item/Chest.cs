using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int cost;
    public Sprite openSprite;
    public bool isOpen = false;

    private bool isNear = false;
    private GameObject player;

    public enum Type
    {
        Life,
        Coin,
        Shield,
        Skill,
        Boss,
        Coin2,
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isOpen)
        {
            isNear = true;
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isOpen)
        {
            isNear = false;
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Life:
                AudioManager.instance.PlaySE("1-up");
                GameManager.instance.AddLife();
                break;
            case Type.Coin:
                AudioManager.instance.PlaySE("chest_coin");
                GameManager.instance.AddCoins(999);
                break;
            case Type.Shield:
                AudioManager.instance.PlaySE("powerup");
                player.GetComponent<Player>().isShield = true;
                break;
            case Type.Skill:
                AudioManager.instance.PlaySE("open_chest");
                GameManager.instance.columnSkillEnhanced = true;
                player.GetComponent<ColumnSkill>().isEnhanced = true;
                break;
            case Type.Boss:
                AudioManager.instance.PlaySE("open_chest");
                break;
            case Type.Coin2:
                AudioManager.instance.PlaySE("chest_coin");
                GameManager.instance.AddCoins(20);
                break;


        }
        GetComponent<SpriteRenderer>().sprite = openSprite;
    }

    private void Update()
    {
        if (isNear && !isOpen)
        {
            if (Input.GetButtonDown("check"))
            {
                if (GameManager.instance.coins >= cost)
                {
                    isOpen = true;
                    GameManager.instance.AddCoins(-cost);
                    Collect(player);
                    GetComponentInChildren<Dialogue>().Sucess();
                }
                else
                {
                    GetComponentInChildren<Dialogue>().Fail();
                }
            }
        }
    }



}

