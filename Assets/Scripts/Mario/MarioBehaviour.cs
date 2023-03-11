using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class MarioBehaviour : StateMachineBehaviour
{
    private MarioBig marioBig;
    private bool isUltraSkill = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        marioBig = animator.GetComponent<MarioBig>();
        if (animator.GetComponent<Transform>().position.y > -54f)
        {
            animator.GetComponent<MarioSkill>().Flash();
        }
        else
        {
            if (marioBig.hp > 25)
            {
                ChooseBehaviour(animator);
            }
            else
            {
                if (!isUltraSkill)
                {
                    isUltraSkill = true;
                    UltraSkill(animator);
                }
                else
                {
                    ChooseBehaviour(animator);
                }

            }
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

    private void UltraSkill(Animator animator)
    {
        animator.GetComponent<CapsuleCollider2D>().enabled = false;
        animator.SetBool("isBattle", false);
        animator.ResetTrigger("isDash");
        animator.GetComponent<MarioShoot>().UltraSkill();
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("isDash");
    }

}
