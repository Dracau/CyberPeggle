using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCircularMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool reverseDirection = false;

    private void FixedUpdate()
    {
        // Movement
        Vector3 rotationOffset;
        if (reverseDirection == false)
		{
             rotationOffset = new Vector3(0, 0, speed);
        }
		else
		{
            rotationOffset = new Vector3(0, 0, -speed);
        }
        transform.Rotate(rotationOffset);
    }
}
