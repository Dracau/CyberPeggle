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
        explosionTrigger.enabled = true;
        GameManager.Instance.LevelManager.CameraShake.ScreenShake();
        yield return new WaitForSeconds(0.1f);
        foreach (Obstacle obstacle in obstaclesInRange)
        {
            if (obstacle == null) continue;
            obstacle.Hit();
        }
        obstaclesInRange.Clear();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Obstacle>() != default)
        {
            obstaclesInRange.Add(other.GetComponent<Obstacle>());
            return;
        }
        if(other.GetComponent<PlayerMarble>() != default) other.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position).normalized * explosionForce, ForceMode2D.Impulse);
    }
}
