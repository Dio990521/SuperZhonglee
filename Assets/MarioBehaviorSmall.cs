using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioBehaviorSmall : StateMachineBehaviour
{
    private MarioSmall marioSmall;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        marioSmall = animator.GetComponent<MarioSmall>();
        if (marioSmall.hp > 0)
        {
            ChooseBehaviour(animator);
        }

    }

    private void ChooseBehaviour(Animator animator)
    {
        int num = Random.Range(0, 10);
        if (num < 7)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetTrigger("isDash");
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("isDash");
    }
}
