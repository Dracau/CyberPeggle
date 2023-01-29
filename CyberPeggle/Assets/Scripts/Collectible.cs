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
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (GameManager.Instance.Collectibles[GameManager.Instance.LevelIndex - 1] == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerMarble>() == default) return;
        audioSource.PlayOneShot(collectSound);
        GameManager.Instance.Collectibles[GameManager.Instance.LevelIndex - 1] = true;
        int collectibles = 0;
        foreach(bool collectible in GameManager.Instance.Collectibles)
        {
            if (collectible == true)
            {
                collectibles++;
            }
        }
        MenuManager.instance.hud.UpdateCollectibles(collectibles);
        StartCoroutine(DisableCoroutine());
    }

    IEnumerator DisableCoroutine()
    {
        animator.SetTrigger("Trigger");
        collider.enabled = false;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}