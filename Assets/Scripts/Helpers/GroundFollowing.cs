using UnityEngine;

public class GroundFollowing : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 0, player.transform.position.z + 200);
    }
}
