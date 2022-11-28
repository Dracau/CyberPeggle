using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float timeBeforeDisappearing;
    private bool hitted;
    public virtual void Hit()
    {
        if(hitted) return;
        hitted = true;
        Debug.Log(gameObject.name + " was hit");
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(timeBeforeDisappearing);
        Destroy(gameObject);
    }
}
