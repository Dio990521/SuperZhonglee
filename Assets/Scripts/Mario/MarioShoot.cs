using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioShoot : MonoBehaviour
{

    public GameObject fireball;
    public float shootSpeed;

    public Transform firePos;

    public int maxFireShoot = 3;
    public int maxExFireShoot = 2;

    public Sprite jumpSprite;
    private Rigidbody2D rb2d;
    public GameObject marioSmall;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(ChooseFire());
    }

    private IEnumerator ChooseFire()
    {
        while (true)
        {
            int num = Random.Range(0, 100);
            if (num < 80)
            {
                FireBall();
            }
            else
            {
                ExFireBall();
            }
            yield return new WaitForSeconds(Random.Range(3f, 5f));
        }
    }
    public void FireBall()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        int times = Random.Range(1, maxFireShoot);
        for (int i = 0; i < times; i++)
        {
            AudioManager.instance.PlayLowSE("fireball", 0.7f);
            GameObject newFireBall = Instantiate(fireball, firePos.position, Quaternion.identity);
            Rigidbody2D rb2d = newFireBall.GetComponent<Rigidbody2D>();
            int dir = Direction();
            rb2d.velocity = new Vector2(shootSpeed * dir, 0f);
            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }

    }

    public void ExFireBall()
    {
        StartCoroutine(ExFire());
    }

    private IEnumerator ExFire()
    {
        int times = Random.Range(1, maxExFireShoot);
        for (int i = 0; i < times; i++)
        {
            AudioManager.instance.PlayLowSE("fireball", 0.5f);
            GameObject newFireBall1 = Instantiate(fireball, firePos.position, Quaternion.identity);
            Rigidbody2D rb2d = newFireBall1.GetComponent<Rigidbody2D>();
            int dir = Direction();
            rb2d.velocity = new Vector2(shootSpeed * 2f * dir - 1f, shootSpeed);


            GameObject newFireBall2 = Instantiate(fireball, firePos.position, Quaternion.identity);
            rb2d = newFireBall2.GetComponent<Rigidbody2D>();
            dir = Direction();
            rb2d.velocity = new Vector2(shootSpeed * 2f * dir + 1f, shootSpeed - 1f);


            GameObject newFireBall3 = Instantiate(fireball, firePos.position, Quaternion.identity);
            rb2d = newFireBall3.GetComponent<Rigidbody2D>();
            dir = Direction();
            rb2d.velocity = new Vector2(shootSpeed * 2f * dir, shootSpeed + 1f);

            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }

    }
    
    private int Direction()
    {
        if (transform.eulerAngles.y == 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public void UltraSkill()
    {

        AudioManager.instance.PlaySE("warning");
        StartCoroutine(UltraSkillFire());
    }

    private IEnumerator UltraSkillFire()
    {

        transform.GetChild(3).gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = jumpSprite;
        GetComponent<MarioShoot>().enabled = false;
        
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        transform.GetChild(3).gameObject.SetActive(false);
        rb2d.MovePosition(new Vector2(-97f, -45f));

        yield return new WaitForSeconds(2f);
        transform.GetChild(3).gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 10; i++)
        {
            AudioManager.instance.PlayLowSE("fireball", 0.5f);
            GameObject newFireBall1 = Instantiate(fireball, firePos.position, Quaternion.identity);
            Rigidbody2D rb2d = newFireBall1.GetComponent<Rigidbody2D>();
            int dir = Direction();
            rb2d.velocity = new Vector2(0f, shootSpeed);

            GameObject newFireBall2 = Instantiate(fireball, firePos.position, Quaternion.identity);
            rb2d = newFireBall2.GetComponent<Rigidbody2D>();
            dir = Direction();
            rb2d.velocity = new Vector2(0f, -shootSpeed);

            GameObject newFireBall3 = Instantiate(fireball, firePos.position, Quaternion.identity);
            rb2d = newFireBall3.GetComponent<Rigidbody2D>();
            dir = Direction();
            rb2d.velocity = new Vector2(-shootSpeed * 2f * dir, 0f);

            GameObject newFireBall4 = Instantiate(fireball, firePos.position, Quaternion.identity);
            rb2d = newFireBall4.GetComponent<Rigidbody2D>();
            dir = Direction();
            rb2d.velocity = new Vector2(shootSpeed * 2f * dir, 0f);

            GameObject newFireBall5 = Instantiate(fireball, firePos.position, Quaternion.identity);
            rb2d = newFireBall5.GetComponent<Rigidbody2D>();
            dir = Direction();
            rb2d.velocity = new Vector2(shootSpeed * 2f * dir, shootSpeed);

            GameObject newFireBall6 = Instantiate(fireball, firePos.position, Quaternion.identity);
            rb2d = newFireBall6.GetComponent<Rigidbody2D>();
            dir = Direction();
            rb2d.velocity = new Vector2(shootSpeed * 2f * dir, -shootSpeed);

            GameObject newFireBall7 = Instantiate(fireball, firePos.position, Quaternion.identity);
            rb2d = newFireBall7.GetComponent<Rigidbody2D>();
            dir = Direction();
            rb2d.velocity = new Vector2(-shootSpeed * 2f * dir, shootSpeed);

            GameObject newFireBall8 = Instantiate(fireball, firePos.position, Quaternion.identity);
            rb2d = newFireBall8.GetComponent<Rigidbody2D>();
            dir = Direction();
            rb2d.velocity = new Vector2(-shootSpeed * 2f * dir, -shootSpeed);

            yield return new WaitForSeconds(0.2f);
        }

        transform.GetChild(3).gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = false;
        
        
        GameObject.FindGameObjectWithTag("BossSpawner").gameObject.GetComponent<EnemySpawner>().enabled = true;
        
        rb2d.MovePosition(new Vector2(-97f, -55f));
        

        transform.GetChild(3).gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        transform.GetChild(3).gameObject.SetActive(false);
        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<Animator>().SetBool("isBattle", true);
        GetComponent<MarioShoot>().enabled = true;
        GetComponent<MarioSkill>().dashDistance = 7f;
        GetComponent<MarioSkill>().dashSpeed = 20f;
        maxFireShoot = 4;
        maxExFireShoot = 3;



    }


}
