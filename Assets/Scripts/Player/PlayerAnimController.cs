using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [HideInInspector]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
    }

    public bool IsAnimationPlaying(string animationName)
    {
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }
}