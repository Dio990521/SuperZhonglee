using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Player player;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        spriteRenderer.enabled = player.isShield ? true : false;
    }
}
