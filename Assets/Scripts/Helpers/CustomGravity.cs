﻿using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    [SerializeField]
    private float gravityScale = 1.0f;

    public static float globalGravity = -9.81f;

    Rigidbody rb;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}