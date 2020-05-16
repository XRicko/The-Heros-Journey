using Serialization;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool gameEnded = false;
    public static bool isLoadNeeded = false;

    [SerializeField]
    private float restartDelay = 1.5f;

    public GameObject completUI;
    public PlayerControl control;

    private Player player;
    private ObstacleSpawner spawner;

    private string path;

    private void Awake()
    {
        instance = this;
        path = Path.Combine(Application.persistentDataPath, "save.con");
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<ObstacleSpawner>();

        if (isLoadNeeded)
            LoadGame();
    }

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
        Player.forwardForce = 0;
        AudioManager.instance.DoOperation(AudioManager.instance.Stop, "Run");
    }

    public void SaveGame()
    {
        var data = new SaveData(player, spawner);
        BinarySerializer.Serialization(data, path);
    }

    public void LoadGame()
    {
        var data = BinarySerializer.Deserialization<SaveData>(path);
        Player.forwardForce = data.forwardForce;
        Player.sideForce = data.sideForce;

        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];

        player.transform.position = position;

        if (data.playerPosition[1] >= 0)
        {
            while (Math.Round(data.spawnerZPosition) > Math.Round(player.transform.position.z + 25))
                data.spawnerZPosition--;
        }

        spawner.transform.position = new Vector3(0, 0, data.spawnerZPosition);

        isLoadNeeded = false;
    }
}
