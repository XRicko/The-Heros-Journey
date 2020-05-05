using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject obstaclePrefab;
    public PlayerAnimController animController;

    [SerializeField]
    private float timeBeetwenSpawns = 1f;
    
    [SerializeField]
    private int spawnAmount = 3;

    int i = 0;
    bool isBusy = false;

    // Update is called once per frame
    void Update()
    {
        if (!isBusy && animController.IsAnimationPlaying("Run"))
            StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        isBusy = true;

        while (i < spawnAmount)
        {
            i++;

            int randomIndex = Random.Range(0, spawnPoints.Length);
            int distanceBetween = Random.Range(24, 40);

            for (int j = Random.Range(0, spawnPoints.Length); j < spawnPoints.Length; j++)
            {
                if (randomIndex != j)
                {
                    Instantiate(obstaclePrefab, spawnPoints[j].position, Quaternion.identity);
                }

            }

            transform.position = new Vector3(0, 0, transform.position.z + distanceBetween);

            yield return new WaitForSeconds(timeBeetwenSpawns);
        }
        isBusy = false;
    }
}
