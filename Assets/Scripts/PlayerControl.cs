using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidBody;

    PlayerAnimController animController;
    public float forwardForce = 200f;

    [SerializeField]
    private float sideForce = 500f;

    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animController = GetComponent<PlayerAnimController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (animController.IsAnimationPlaying("Run"))
        {
            rigidBody.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);
            rigidBody.AddForce((transform.right * horizontal) * sideForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }

        if (rigidBody.position.y < 0.1f)
        {
            animController.animator.SetBool("IsFalling", true);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}