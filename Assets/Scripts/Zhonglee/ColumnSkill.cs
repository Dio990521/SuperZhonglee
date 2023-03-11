using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColumnSkill : PlayerSkill
{
    private PlayerMovement playerMov;
    public GameObject column;

    public bool isEnhanced = false;
    // Start is called before the first frame update
    private void Awake()
    {
        playerMov = GetComponent<PlayerMovement>();
        if (GameManager.instance.isColumnSkillOn)
        {
            this.enabled = true;
        }
        if (GameManager.instance.columnSkillEnhanced)
        {
            isEnhanced = true;
        }
    }

    private void OnEnable()
    {
        icon.SetActive(true);
    }

    private void Update()
    {
        
        bool isJumping = playerMov.isJumping;
        if (Input.GetButton("Fire2") && !isCD && !isJumping)
        {
            RaycastHit2D hit = Physics2D.Raycast(skillPos.position, Vector2.down, distance, LayerMask.GetMask("Ground"));
            if (hit.collider != null)
            {
                StartCoroutine(CoolDown());
                StartCoroutine(Animate());
                Instantiate(column, hit.point + offset, Quaternion.identity);
                if (isEnhanced)
                {
                    GetComponent<Player>().isShield = true;
                }
                
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(skillPos.position, Vector2.down);
    }

    private IEnumerator Animate()
    {
        isSkill = true;
        playerMov.enabled = false;
        yield return new WaitForSeconds(0.8f);
        playerMov.enabled = true;
        isSkill = false;
    }

}
