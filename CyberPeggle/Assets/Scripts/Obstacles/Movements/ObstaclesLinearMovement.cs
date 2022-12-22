using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesLinearMovement : MonoBehaviour
{
    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector2 direction = Vector2.right;

    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // Movement
        transform.position = initialPosition + (Vector3)direction.normalized * Mathf.Sin(Time.time * speed) * maxDistance;
    }
}
