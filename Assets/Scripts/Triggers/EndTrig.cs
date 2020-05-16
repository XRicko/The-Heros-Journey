using UnityEngine;

public class EndTrig : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.instance.Complete();

    }
}
