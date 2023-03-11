using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockItem : MonoBehaviour
{
    private Item item;
    void Start()
    {
        item = GetComponent<Item>();
        StartCoroutine(Animate());
    }


    private IEnumerator Animate()
    {
        switch (item.type)
        {
            case Item.Type.Starman:
                AudioManager.instance.PlaySE("vine");
                break;
            case Item.Type.JumpMachine:
                AudioManager.instance.PlaySE("vine");
                break;
            default:
                AudioManager.instance.PlaySE("powerup_appears");
                break;
        }
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();

        if (item.type != Item.Type.JumpMachine)
        {
            rb.isKinematic = true;
        }
        
        spriteRenderer.enabled = false;
        collider.enabled = false;
        circleCollider.enabled = false;

        yield return new WaitForSeconds(0.25f);

        spriteRenderer.enabled = true;

        Vector3 start = transform.localPosition;
        Vector3 end = start + Vector3.up;

        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            transform.localPosition = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = end;

        if (item.type != Item.Type.JumpMachine)
        {
            rb.isKinematic = false;
        }
        collider.enabled = true;
        circleCollider.enabled = true;

    }
}
