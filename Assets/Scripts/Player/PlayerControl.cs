using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Player player;
    private PlayerAnimController animController;

    private void Start()
    {
        player = GetComponent<Player>();
        animController = GetComponent<PlayerAnimController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.horizontal = Input.GetAxis("Horizontal");

        if (animController.IsAnimationPlaying("Run"))
        {
            AudioManager.instance.DoOperation(AudioManager.instance.Play, "Run");
            player.rigidBody.AddForce(0, 0, Player.forwardForce * Time.fixedDeltaTime);
            player.rigidBody.AddForce((transform.right * player.horizontal) * Player.sideForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        if (!animController.IsAnimationPlaying("Run"))
            AudioManager.instance.DoOperation(AudioManager.instance.Stop, "Run");

        if (player.rigidBody.position.y < 0.1f)
        {
            AudioManager.instance.DoOperation(AudioManager.instance.Stop, "Run");
            animController.animator.SetBool("IsFalling", true);
            GameManager.instance.GameOver();
        }
    }
}