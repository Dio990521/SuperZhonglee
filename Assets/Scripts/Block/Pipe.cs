using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Transform connection;
    public KeyCode enterKeyCode = KeyCode.DownArrow;
    public Vector3 enterDirection = Vector3.down;
    public Vector3 exitDirection = Vector3.zero;

    private void OnEnable()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (connection != null && collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyUp(enterKeyCode))
            {
                AudioManager.instance.PlaySE("pipe");
                StartCoroutine(Enter(collision.transform));
            }
        }
    }

    private IEnumerator Enter(Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        Vector3 enterPosition = player.position + enterDirection;
        Vector3 enterScale = Vector3.one * 0.05f;

        yield return Move(player, enterPosition, enterScale);
        yield return new WaitForSeconds(1f);

        if (exitDirection!= Vector3.zero)
        {
            player.position = connection.position - exitDirection;
            yield return Move(player, connection.position + exitDirection, Vector3.one);
        }
        else
        {
            player.position = connection.position;
            player.localScale = Vector3.one * 0.07f;
        }
        player.GetComponent<PlayerMovement>().enabled = true;
        AudioManager.instance.PlaySE("pipe");
    }

    private IEnumerator Move(Transform player, Vector3 endPosition, Vector3 endScale)
    {
        float elapsed = 0f;
        float duration = 1f;
        while (elapsed < duration)
        {
            player.position = Vector3.Lerp(player.position, endPosition, elapsed / duration);
            player.localScale = Vector3.Lerp(player.localScale, endScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
