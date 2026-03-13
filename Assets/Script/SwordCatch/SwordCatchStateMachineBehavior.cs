using UnityEngine;

public class SwordCatchBehavior_Player : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsTryCatch", false);
    }
}
