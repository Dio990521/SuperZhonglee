using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public Sprite emptyBlock;
    public int maxHits = -1;
    private bool animating;
    public GameObject item;
    public bool isGate = false;

    public bool isPath = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotProductTest(transform, Vector2.up))
            {
                Hit();
            }
        }
    }

    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        maxHits--;
        if (maxHits == 0)
        {
            spriteRenderer.sprite = emptyBlock;
        }
        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);
            if (item.name == "jumpMachine")
            {
                GameManager.instance.isJumpMachine = true;
            }
        }
        StartCoroutine(Animate());
        if (isGate)
        {
            GetComponent<BridgeAnimation>().enabled = true;
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(false);
        } 
        else if (isPath)
        {
            AudioManager.instance.PlaySE("fireworks");
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private IEnumerator Animate()
    {
        AudioManager.instance.PlaySE("bump");
        animating = true;
        Vector3 originPosition = transform.localPosition;
        Vector3 destination = originPosition + Vector3.up * 0.5f;
        yield return Move(originPosition, destination);
        yield return Move(destination, originPosition);
        animating = false;
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;
        while(elapsed < duration)
        {
            transform.localPosition = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = to;
    }
}
