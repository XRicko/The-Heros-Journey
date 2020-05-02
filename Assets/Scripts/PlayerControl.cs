using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rigidBody;
    AnimationController animationController;

    public float forwardForce = 200f;
    public float sideForce = 500f;
    private float horizontal;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animationController = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (animationController.IsAnimationPlaying("Run"))
        {
            rigidBody.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);
            rigidBody.AddForce((transform.right * horizontal) * sideForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        if (rigidBody.position.y < 0.1f)
        {
            animationController.animator.SetBool("IsFalling", true);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}