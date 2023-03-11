using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MarioSkill : MonoBehaviour
{
    
    private GameObject player;
    private Rigidbody2D rb2d;

    public bool isDash;
    public float dashDistance = 5f;
    public float dashSpeed = 15f;

    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void LookAtPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = transform.position - player.transform.position;
        transform.eulerAngles = direction.x > 0 ? new Vector3(0f, 180f, 0f) : Vector3.zero;
    }

    public void Dash()
    {
        
        LookAtPlayer();
        Vector2 direction = rb2d.position - player.GetComponent<Rigidbody2D>().position;
        int dir = direction.x < 0 ? 1 : -1;
        float checkPos;
        if (rb2d.position.x + dir * dashDistance < -110f || rb2d.position.x + dir * dashDistance > -80f)
        {
            checkPos = rb2d.position.x - dir * dashDistance;
        }
        else
        {
            checkPos = rb2d.position.x + dir * dashDistance;
        }
        if (checkPos < rb2d.position.x && transform.rotation.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (checkPos > rb2d.position.x && transform.rotation.eulerAngles.y == 180)
        {
            transform.eulerAngles = Vector3.zero;
        }
        Vector2 target = new Vector2(checkPos, rb2d.position.y);
        StartCoroutine(DashToPos(target, dashSpeed));
    }

    private IEnumerator DashToPos(Vector2 target, float dashSpeed)
    {
        while (Vector2.Distance(rb2d.position, target) > 0.1f)
        {
            Vector2 newPos = Vector2.MoveTowards(rb2d.position, target, dashSpeed * Time.fixedDeltaTime);
            GameObject column = GameObject.FindGameObjectWithTag("Column");
            if (column != null)
            {
                
                float distance = Mathf.Abs(newPos.x - column.transform.position.x);
                if (distance < 1f)
                {
                    break;
                }
            }
            rb2d.MovePosition(newPos);
            yield return null;
        }
        rb2d.isKinematic = false;
    }

    public void Flash()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("isBattle", false);
        StartCoroutine(FlashAni());
    }

    private IEnumerator FlashAni()
    {
        transform.GetChild(3).gameObject.SetActive(true);
        GetComponent<MarioShoot>().enabled = false;

        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        transform.GetChild(3).gameObject.SetActive(false);
        rb2d.MovePosition(new Vector2(-97f, -55f));

        yield return new WaitForSeconds(1f);
        transform.GetChild(3).gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);

        transform.GetChild(3).gameObject.SetActive(false);
        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<MarioShoot>().enabled = true;
        GetComponent<Animator>().SetBool("isBattle", true);
    }



}
