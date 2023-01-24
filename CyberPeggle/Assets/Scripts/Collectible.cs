using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D collider;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerMarble>() == default) return;
        audioSource.PlayOneShot(collectSound);
        StartCoroutine(DisableCoroutine());
    }

    IEnumerator DisableCoroutine()
    {
        spriteRenderer.enabled = false;
        collider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}