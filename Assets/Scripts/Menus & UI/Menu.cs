using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.isSongNeeded = false;
        GameManager.isLoadNeeded = false;
    }

    public void LaunchNormal()
    {
        AudioManager.instance.isSongNeeded = true;
        AudioManager.instance.PlayRandomSong();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LaunchEndless()
    {
        AudioManager.instance.DoOperation(AudioManager.instance.Play, "Theme");
        SceneManager.LoadScene("Endless");
    }

    public void LoadEndless()
    {
        LaunchEndless();
        GameManager.isLoadNeeded = true;
    }
}
