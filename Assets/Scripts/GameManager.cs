using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 1.5f;
    public GameObject completUI;
    public PlayerControl control;

    public void GameOver()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Invoke("Restart", restartDelay);
        }
    }    

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Complete()
    {
        completUI.SetActive(true);
        control.enabled = false;
        control.forwardForce = 0;
    }
}
