using UnityEngine;

public class Folowing : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 2, 5);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
