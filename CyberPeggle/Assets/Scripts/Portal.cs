using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private PortalManager portalManager;
    [SerializeField] private Transform outputPosition;

    private void OnTriggerEnter(Collider other)
    {
        //if player
        if(!portalManager.TryWarp(other.gameObject)) return;
        
        other.transform.position = outputPosition.position;
    }
}
