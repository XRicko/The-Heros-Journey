using UnityEngine;

public class PlayerColison : MonoBehaviour
{
    public PlayerControl control;
    public Animator animator;

   void OnCollisionEnter(Collision info)
    {
        if (info.collider.CompareTag("Obstacle"))
        {
            animator.SetBool("IsDead", true);
            control.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
