using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioJump : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public bool isJump = false;

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GetComponentInParent<MarioSkill>().isDash)
        {
            if (collision.tag == "Bomb" || collision.tag == "Koopa1")
            {
                if (!isJump)
                {
                    GetComponentInParent<Animator>().SetBool("isBattle", false);
                    isJump = true;
                    StartCoroutine(Jump());
                }
                
            }
        }
        
    }

    private IEnumerator Jump()
    {
        rb2d.velocity = new Vector2(0f, 10f);
        yield return new WaitForSeconds(1f);
        rb2d.velocity = new Vector2(0f, -10f);
        yield return new WaitForSeconds(5f);
        isJump = false;
        GetComponentInParent<Animator>().SetBool("isBattle", true);
    }

    private void OnEnable()
    {
        
    }


}
