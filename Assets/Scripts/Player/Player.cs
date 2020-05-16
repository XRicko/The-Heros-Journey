using UnityEngine;

public class Player : MonoBehaviour
{
    public static float forwardForce = 8000f;
    public static float sideForce = 200f;

    [HideInInspector]
    public float horizontal;

    [HideInInspector]
    public Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
}
