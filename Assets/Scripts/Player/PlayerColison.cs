using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColison : MonoBehaviour
{
    private PlayerControl control;
    private PlayerAnimController animController;

    private void Start()
    {
        control = GetComponent<PlayerControl>();
        animController = GetComponent<PlayerAnimController>();
    }

    void OnCollisionEnter(Collision info)
    {
        if (info.collider.CompareTag("Obstacle") || info.collider.CompareTag("Surprise"))
        {
            AudioManager.instance.DoOperation(AudioManager.instance.Play, "PlayerHit");
            AudioManager.instance.DoOperation(AudioManager.instance.Stop, "Run");

            animController.animator.SetBool("IsDead", true);
            control.enabled = false;

            if (info.collider.CompareTag("Obstacle"))
                GameManager.instance.GameOver();
            else
            {
                StartCoroutine(LoadScene());

                AudioManager.instance.DoOperation(AudioManager.instance.Stop, AudioManager.instance.currentSongName);
                AudioManager.instance.isSongNeeded = false;
                AudioManager.instance.DoOperation(AudioManager.instance.Play, "The End");
            }
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
