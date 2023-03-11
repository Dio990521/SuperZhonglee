using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MarioDash : StateMachineBehaviour
{

    public float dashDistance = 5f;
    private float checkPos;
    public float dashSpeed = 5f;

    private Rigidbody2D rb2d;
    private MarioSkill marioSkill;

    private GameObject player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2d = animator.GetComponent<Rigidbody2D>();
        marioSkill = animator.GetComponent<MarioSkill>();
        player = GameObject.FindGameObjectWithTag("Player");
        marioSkill.LookAtPlayer();
        Vector2 direction = rb2d.position - player.GetComponent<Rigidbody2D>().position;
        int dir = direction.x < 0 ? 1 : -1;
        if (rb2d.position.x + dir * dashDistance < -110f || rb2d.position.x + dir * dashDistance > -80f)
        {
            checkPos = rb2d.position.x - dir * dashDistance;
        }
        else
        {
            checkPos = rb2d.position.x + dir * dashDistance;
        }

        if (checkPos < rb2d.position.x && animator.transform.rotation.eulerAngles.y == 0)
        {
            animator.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        } else if(checkPos > rb2d.position.x && animator.transform.rotation.eulerAngles.y == 180)
        {
            animator.transform.eulerAngles = Vector3.zero;
        }
        rb2d.isKinematic = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
