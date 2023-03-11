using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCoin : MonoBehaviour
{

    private void Start()
    {
        AudioManager.instance.PlaySE("coin");
        GameManager.instance.AddCoin();
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        Vector3 originPosition = transform.localPosition;
        Vector3 destination = originPosition + Vector3.up * 2f;
        yield return Move(originPosition, destination);
        yield return Move(destination, originPosition);
        Destroy(gameObject);
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.25f;
        while (elapsed < duration)
        {
            transform.localPosition = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = to;
    }


}
