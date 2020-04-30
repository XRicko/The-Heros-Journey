using UnityEngine;

public class PlayerColison : MonoBehaviour
{
    public PlayerControl control;

   void OnCollisionEnter(Collision info)
    {
        if (info.collider.tag == "Obstacle")
        {
            control.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
