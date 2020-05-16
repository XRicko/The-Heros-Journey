[System.Serializable]
public class SaveData
{
    #region Player
    public float forwardForce;
    public float sideForce;
    public float[] playerPosition;
    #endregion

    #region Spawner
    public float spawnerZPosition;
    #endregion

    public SaveData(Player player, ObstacleSpawner spawner)
    {
        forwardForce = Player.forwardForce;
        sideForce = Player.sideForce;

        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;

        spawnerZPosition = spawner.transform.position.z;
    }
}
