using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMarble : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private TrailRenderer trail = null;
    
    [HideInInspector] public bool IsInsideCanon = false;
    private int currentLife;
    
    public void Initialize()
    {
        currentLife = GameManager.Instance.LevelManager.LevelData.MaxLife;
        MenuManager.instance.hud.UpdatePlayerLives(currentLife);
        Reset();
    }

    public void Reset()
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        transform.SetParent(GameManager.Instance.LevelManager.Canon.MarblePosition);
        transform.localScale = Vector3.one;

        transform.localPosition = Vector2.zero;
        IsInsideCanon = true;
        ClearTrail();
    }

    public void ClearTrail()
    {
        trail.Clear();
    }
    
    public void Launch(Vector2 force)
    {
        transform.parent = null;
        rb.simulated = true;
        IsInsideCanon = false;
        rb.AddForce(force, ForceMode2D.Impulse);
        AddLife(-1);
    }

    private void AddLife(int addedLife)
    {
        currentLife += addedLife;
        MenuManager.instance.hud.UpdatePlayerLives(currentLife);
    }

    private void HitGround()
    {
        if (currentLife == 0)
        {
            GameManager.Instance.Defeat();
        }
        Reset();
    }

    private void EnterBucket()
    {
        AddLife(1);
        HitGround();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            HitGround();
        }
        else if (col.gameObject.CompareTag("Bucket"))
        {
            EnterBucket();
            col.transform.parent.parent.GetComponent<Bucket>().TriggerAnim();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Obstacle>()?.Hit();
    }
}
