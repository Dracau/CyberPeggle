using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarble : MonoBehaviour
{
    [SerializeField] private float propulsionStrength = 1;
    [SerializeField] private Rigidbody2D rb = null;

    public void Initialize()
    {
        rb.simulated = false;
    }
    
    public void Propulse(Vector2 direction)
    {
        rb.simulated = true;
        Vector2 force = direction.normalized * propulsionStrength;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
