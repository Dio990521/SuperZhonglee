using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    private PlayerMovement playerMovement;
    private ColumnSkill columnSkill;

    public Sprite idle;
    public Sprite jump;
    public Sprite slide;
    public AnimatedSprite run;
    public AnimatedSprite skill;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        columnSkill = GetComponentInParent<ColumnSkill>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
        run.enabled = false;
        if (skill != null)
        {
            skill.enabled = false;
        }
        
    }

    private void LateUpdate()
    {
        if (columnSkill != null && columnSkill.isSkill)
        {
            run.enabled = false;
            skill.enabled = true;
        }
        else
        {
            if (skill != null)
            {
                skill.enabled = false;
            }
                
            run.enabled = playerMovement.isRunning;

            if (playerMovement.isJumping)
            {
                spriteRenderer.sprite = jump;
            }
            else if (playerMovement.isSliding)
            {
                spriteRenderer.sprite = slide;
            }
            else if (!playerMovement.isRunning)
            {
                spriteRenderer.sprite = idle;
            }
        }
    }
}
