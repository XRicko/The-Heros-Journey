using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseTrig : MonoBehaviour
{
    public CustomGravity gravity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            gravity.enabled = true;
    }
}
