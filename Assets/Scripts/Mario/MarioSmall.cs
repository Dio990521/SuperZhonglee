using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioSmall : MonoBehaviour
{
    public int hp = 25;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(StopAnimation());
        GetComponent<MarioShoot>().enabled = true;
        GetComponent<MarioSkill>().dashDistance = 7f;
        GetComponent<MarioSkill>().dashSpeed = 20f;
        GetComponent<MarioShoot>().maxFireShoot = 5;
        GetComponent<MarioShoot>().maxExFireShoot = 3;
    }

    private IEnumerator StopAnimation()
    {
        transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        transform.GetChild(3).gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bomb")
        {
            hp--;
            if (hp == 0)
            {
                StartCoroutine(DeathAnimation());
            }
        }

        if (collision.gameObject.tag == "Player" && collision.transform.DotProductTest(transform, Vector2.down))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            hp--;
            AudioManager.instance.PlaySE("stomp");
            if (hp == 0)
            {
                StartCoroutine(DeathAnimation());
            }
        }
    }

    private IEnumerator DeathAnimation()
    {
        animator.SetTrigger("isDead");
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlaySE("bowserfalls");

        yield return new WaitForSeconds(2f);
        AudioManager.instance.PlaySE("world_clear");
        Destroy(gameObject);
    }
}
