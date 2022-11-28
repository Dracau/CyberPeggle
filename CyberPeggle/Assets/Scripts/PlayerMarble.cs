using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarble : MonoBehaviour
{
    [SerializeField] private float propulsionStrength = 1;
    [SerializeField] private Rigidbody2D rb = null;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        transform.SetParent(GameManager.Instance.Canon.MarblePosition);
        transform.localPosition = Vector2.zero;
    }
    
    public void Launch(Vector2 direction)
    {
        transform.parent = null;
        rb.simulated = true;
        Vector2 force = direction * propulsionStrength;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            Initialize();
        }
    }
}
