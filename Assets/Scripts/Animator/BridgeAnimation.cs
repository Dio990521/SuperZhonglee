using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeAnimation : MonoBehaviour
{

    public GameObject bridge1;
    public GameObject bridge2;

    private float aniTime = 5f;

    private void OnEnable()
    {
        StartCoroutine(Animate(bridge1));
        StartCoroutine(Animate(bridge2));
    }

    private IEnumerator Animate(GameObject bridge)
    {
        SpriteRenderer spriteRenderer = bridge.GetComponent<SpriteRenderer>();
        BoxCollider2D boxCollider2D = bridge.GetComponent<BoxCollider2D>();
        float elapsed = 0f;
        float updateRate = 1 / aniTime * 15f * Time.deltaTime;
        while (elapsed < aniTime && spriteRenderer.size.y > 1)
        {
            spriteRenderer.size = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y - updateRate);
            boxCollider2D.size = new Vector2(boxCollider2D.size.x, boxCollider2D.size.y - updateRate);
            elapsed = Time.deltaTime;
            yield return null;
        }
        spriteRenderer.size = new Vector2(spriteRenderer.size.y, 1);
    }
}
