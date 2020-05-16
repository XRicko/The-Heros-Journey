using UnityEngine;

public class CameraFolowing : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset = new Vector3(0, 2, 5);

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
