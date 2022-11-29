using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] private float maxDistance = 7f;
    [Range(0f, 1f)] [SerializeField] private float speed = 1f;

    private float xTarget;
    private float elapsedTime = 0f;

    private void Awake()
    {
        xTarget = maxDistance;
    }

    private void Update()
    {
        // Movement
        Vector3 position = transform.position;
        float x = Mathf.Lerp(position.x, xTarget, (Time.time - elapsedTime) * speed * Time.deltaTime);
        position = new Vector3(x, position.y, 0);
        transform.position = position;
        if (Math.Abs(transform.position.x - maxDistance) < 0.1f)
        {
            xTarget = -maxDistance;
            elapsedTime = Time.time;
        }
        else if (Math.Abs(transform.position.x + maxDistance) < 0.1f)
        {
            xTarget = maxDistance;
            elapsedTime = Time.time;
        }
    }
}
