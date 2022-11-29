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
    // Placeholder
    [SerializeField] private TMP_Text lifeText = null;
    
    [HideInInspector] public bool IsInsideCanon = false;
    private int currentLife;
    
    public void Initialize()
    {
        currentLife = GameManager.Instance.LevelManager.LevelData.MaxLife;
        lifeText.text = currentLife.ToString();
        Reset();
    }

    public void Reset()
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        transform.SetParent(GameManager.Instance.LevelManager.Canon.MarblePosition);
        transform.localPosition = Vector2.zero;
        IsInsideCanon = true;
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
        // Placeholder
        lifeText.text = currentLife.ToString();
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
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Obstacle>()?.Hit();
    }
}
