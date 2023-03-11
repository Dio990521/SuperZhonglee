using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeathAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite deathSprite;

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Camera.main.GetComponent<CameraController>().cameraOn = false;
        UpdateSprite();
        DisablePhysics();
        StartCoroutine(Animate());
    }

    private void UpdateSprite()
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sortingOrder = 10;
        if (deathSprite != null)
        {
            AudioManager.instance.StopMusic();
            if (Random.Range(0f, 2f) < 1f)
            {
                AudioManager.instance.PlaySE("zhonglee dead");
            }
            else
            {
                AudioManager.instance.PlaySE("zhonglee dead2");
            }
            AudioManager.instance.PlaySE("dead");
            spriteRenderer.sprite = deathSprite;
        }
    }

    private void DisablePhysics()
    {
        Collider2D[] collider2Ds = GetComponents<Collider2D>();
        foreach (Collider2D collider in collider2Ds)
        {
            collider.enabled = false;
        }
        GetComponent<Rigidbody2D>().isKinematic = true;
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        EntityMovement entityMovement = GetComponent<EntityMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
        if (entityMovement != null)
        {
            entityMovement.enabled = false;
        }
    }

    private IEnumerator Animate()
    {
        float elapsed = 0f;
        float duration = 3f;
        float jumpVelocity = 15f;
        float gravity = -36f;

        Vector3 velocity = Vector3.up * jumpVelocity;
        yield return new WaitForSeconds(0.5f);
        while (elapsed < duration)
        {
            transform.position += velocity * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
            elapsed = Time.deltaTime;
            yield return null;
        }
    }
}
