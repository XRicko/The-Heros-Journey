using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Slider[] slider;
    public static bool isPaused = false;

    private void Start()
    {
        slider[0].value = Player.forwardForce;
        slider[1].value = Player.sideForce;
        slider[2].value = ObstacleSpawner.timeBeetwenSpawn;

        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        AudioManager.instance.PauseAll();
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        AudioManager.instance.UnPauseAll();
        Time.timeScale = 1f;

        isPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        AudioManager.instance.StopAll();
        AudioManager.instance.isSongNeeded = false;
        GameManager.instance.SaveGame();

        isPaused = false;
    }

    public void Exit()
    {
        GameManager.instance.SaveGame();
        Application.Quit();
    }

    public void ForwardForceChange(float value)
    {
        Player.forwardForce = value;
    }

    public void SideForceChange(float value)
    {
        Player.sideForce = value;
    }

    public void SpawnTimeChange(float value)
    {
        ObstacleSpawner.timeBeetwenSpawn = value;
    }
}
