using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] private float maxDistance = 7f;
    [Range(0f, 1f)] [SerializeField] private float speed = 1f;

    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // Movement
        transform.position = initialPosition + transform.right * Mathf.Sin(Time.time * speed) * maxDistance;
    }
}
