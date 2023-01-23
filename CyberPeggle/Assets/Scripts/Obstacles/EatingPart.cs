using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingPart : MonoBehaviour
{
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private Transform lockPoint;
    private GameObject crunchedObject;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<PlayerMarble>() == null) return;
        crunchedObject = col.gameObject;
        col.transform.parent = lockPoint;
        col.transform.localPosition = Vector3.zero;
        col.GetComponent<Rigidbody2D>().simulated = false;
    }

    public void Crunch()
    {
        collider.enabled = true;
    }

    public void UnCrunch()
    {
        collider.enabled = false;
        if(crunchedObject == default) return;
        crunchedObject.GetComponent<PlayerMarble>().Reset();
        crunchedObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        crunchedObject.transform.localScale = Vector3.one * 0.5f;
        crunchedObject = default;
    }
}
