using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private PortalManager portalManager;
    [SerializeField] private Transform outputPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if player
        if(!portalManager.TryWarp(other.gameObject)) return;
        
        other.transform.position = outputPosition.position;
    }
}
