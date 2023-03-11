using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform bottom;
    public Transform playerBottom;
    public Transform castle;
    public float speed = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.StopMusic();
            AudioManager.instance.PlaySE("flagpole");
            collision.transform.GetChild(0).GetComponent<PlayerSpriteRenderer>().run.enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(MoveTo(flag, bottom.position));
            StartCoroutine(LevelComplete(collision.transform));
        }
    }

    private IEnumerator LevelComplete(Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(1f);
        AudioManager.instance.PlaySE("stage_clear");
        yield return MoveTo(player, bottom.position);
        yield return MoveTo(player, player.position + Vector3.right);
        yield return MoveTo(player, player.position + Vector3.right + Vector3.down);
        yield return MoveTo(player, castle.position);

        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Win");
    }

    private IEnumerator MoveTo(Transform subject, Vector3 destination)
    {
        while (Vector3.Distance(subject.position, destination) > 0.1f)
        {
            subject.position = Vector3.MoveTowards(subject.position, destination, speed * Time.deltaTime);
            yield return null;
        }
        subject.position = destination;
    }
}
