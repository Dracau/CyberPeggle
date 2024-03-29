using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float timeBeforeDisappearing;
    [SerializeField] private Animator animator = null;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSound;
    
    private bool hitted;
    public virtual void Hit()
    {
        if(hitted) return;
        audioSource.PlayOneShot(hitSound);
        hitted = true;
        animator.SetTrigger("Collision");
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(timeBeforeDisappearing);
        animator.SetTrigger("Disappear");
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
