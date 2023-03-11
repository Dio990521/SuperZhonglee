using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioRun : StateMachineBehaviour
{

    private Rigidbody2D rb2d;
    private MarioSkill marioSkill;
    

    public float speed;

    private float offset;
    private float checkPos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2d = animator.GetComponent<Rigidbody2D>();
        marioSkill = animator.GetComponent<MarioSkill>();
        
        offset = Random.Range(-4, 4);
        checkPos = (rb2d.position.x + offset < -110f || rb2d.position.x + offset > -80f) ?
            rb2d.position.x - offset : rb2d.position.x + offset;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        marioSkill.LookAtPlayer();

        Vector2 target = new Vector2(checkPos, rb2d.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb2d.position, target, speed * Time.fixedDeltaTime);
        rb2d.MovePosition(newPos);
        if (Vector2.Distance(rb2d.position, target) <= 0.1f)
        {
            animator.SetBool("isRun", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
