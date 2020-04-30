using UnityEngine;

public class EndTrig : MonoBehaviour
{
    public GameManager manager;

    private void OnTriggerEnter(Collider other)
    {
        manager.Complete();
    }
}
