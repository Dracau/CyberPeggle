using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
{
    [SerializeField] private Animation anim;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<PlayerMarble>() == default) return;
        anim.Play();
    }
}
