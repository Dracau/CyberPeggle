using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveObstacle : Obstacle
{
    [field: SerializeField] private CircleCollider2D explosionTrigger;
    public float explosionForce;
    public override void Hit()
    {
        StartCoroutine(ExplosionCoroutine());
    }

    private List<Obstacle> obstaclesInRange = new List<Obstacle>();
    private IEnumerator ExplosionCoroutine()
    {
        Debug.Log(2);
        explosionTrigger.enabled = true;
        yield return new WaitForSeconds(0.1f);
        foreach (Obstacle obstacle in obstaclesInRange)
        {
            obstacle.Hit();
        }
        obstaclesInRange.Clear();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Obstacle>() != default)
        {
            Debug.Log(0);
            obstaclesInRange.Add(other.GetComponent<Obstacle>());
        }
    }
}
