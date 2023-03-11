using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarioBig : MonoBehaviour
{

    public int hp = 50;
    private GameObject hpBar;

    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        if (GameManager.instance.isBossDown)
        {
            Destroy(gameObject);
        }
        hpBar = GameObject.FindGameObjectWithTag("Hp").gameObject;
        hpBar.SetActive(false);
        animator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (collision.gameObject.tag == "Bomb")
        {
            if (!animator.GetBool("isBattle"))
            {
                SetBattle();
            }
            hp--;
            hpBar.GetComponent<Slider>().value = hp;
            if (hp == 0)
            {
                StartCoroutine(DeathAnimation());
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.DotProductTest(transform, Vector2.down))
            {
                if (!animator.GetBool("isBattle"))
                {
                    SetBattle();
                }
                hp--;
                hpBar.GetComponent<Slider>().value = hp;
                AudioManager.instance.PlaySE("stomp");
                if (hp == 0)
                {
                    StartCoroutine(DeathAnimation());
                }
            }
            else
            {
                Player player = collision.gameObject.GetComponent<Player>();
                if (player.isShield)
                {
                    player.isShield = false;
                }
                else
                {
                    player.Hit();
                }
            }
            
        }
    }

    private void SetBattle()
    {
        GameObject.FindGameObjectWithTag("BossPipe").GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(2).GetComponent<BossDialogue>().Dialogue22();
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlayMusic("boss");
        hpBar.SetActive(true);
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Animator>().SetBool("isBattle", true);
        GetComponent<MarioShoot>().enabled = true;
    }

    private IEnumerator DeathAnimation()
    {
        GameObject.FindGameObjectWithTag("BossPipe").GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<MarioShoot>().enabled = false;
        GameManager.instance.isBossDown = true;
        transform.GetChild(2).GetComponent<BossDialogue>().Dialogue33();
        animator.SetTrigger("isDead");
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlaySE("bowserfalls");
        
        StartCoroutine(Rotate());
        yield return new WaitForSeconds(2f);
        AudioManager.instance.PlaySE("world_clear");
        hpBar.SetActive(false);
        GameManager.instance.AddCoins(10000);
        GameObject.FindGameObjectWithTag("BossSpawner").gameObject.GetComponent<EnemySpawner>().enabled = false;
        Destroy(gameObject,3f);
        yield return new WaitForSeconds(8f);
        AudioManager.instance.PlayMusic("world bgm");
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
