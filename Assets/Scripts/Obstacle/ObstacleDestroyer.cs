using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    private GameObject destructionPoint;

    // Start is called before the first frame update
    void Start()
    {
        destructionPoint = GameObject.Find("DestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < destructionPoint.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
