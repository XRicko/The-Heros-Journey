using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsAnimationPlaying(string animationName)
    {
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }
}