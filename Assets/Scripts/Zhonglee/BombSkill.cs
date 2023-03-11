using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : PlayerSkill
{
    public float shootSpeed;
    public GameObject bomb;

    private void Awake()
    {
        if (GameManager.instance.isBombSkillOn)
        {
            this.enabled = true;
        }
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && !isCD)
        {
            StartCoroutine(CoolDown());
            StartCoroutine(Shoot());
        }
    }

    private void OnEnable()
    {
        icon.SetActive(true);
    }

    private IEnumerator Shoot()
    {
        yield return null;
        isSkill = true;
        GameObject newBomb = Instantiate(bomb, skillPos.position, Quaternion.identity);
        Rigidbody2D rb2d = newBomb.GetComponent<Rigidbody2D>();
        int dir = Direction();
        rb2d.velocity = new Vector2(shootSpeed * dir, 0f);
        isSkill = false;
    }

    private int Direction()
    {
        if (transform.localEulerAngles.y > 90f)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}
