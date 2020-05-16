using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject obstaclePrefab;

    public PlayerAnimController animController;

    public static float timeBeetwenSpawn = 0.5f;

    [SerializeField]
    private bool endless = false;

    [SerializeField]
    private int rows = 3;

    private int i = 0;
    private bool isBusy = false;

    // Update is called once per frame
    void Update()
    {
        if (!isBusy && animController.IsAnimationPlaying("Run"))
        {
            if (!endless)
                StartCoroutine(FixedAmountSpawn());
            else if (endless)
                StartCoroutine(EndlessSpawn());
        }
    }

    IEnumerator FixedAmountSpawn()
    {
        isBusy = true;

        while (i < rows)
        {
            i++;
            yield return StartCoroutine(EndlessSpawn());
        }

        isBusy = false;
    }

    IEnumerator EndlessSpawn()
    {
        isBusy = true;

        int randomIndex = Random.Range(0, spawnPoints.Length);
        int distanceBetween = Random.Range(33, 44);

        for (int j = Random.Range(0, spawnPoints.Length); j < spawnPoints.Length; j++)
        {
            if (randomIndex != j)
            {
                Instantiate(obstaclePrefab, spawnPoints[j].position, Quaternion.identity);
            }

        }

        transform.position = new Vector3(0, 0, transform.position.z + distanceBetween);

        yield return new WaitForSeconds(timeBeetwenSpawn);

        isBusy = false;
    }
}
