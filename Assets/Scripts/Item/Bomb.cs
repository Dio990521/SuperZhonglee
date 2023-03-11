using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bombEffect;
    public float bombTime;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(rb2d.velocity.x, rb2d.velocity.y, 0f) * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        if (bombEffect != null)
        {
            Instantiate(bombEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(bombTime);
        Explode();
    }
}
