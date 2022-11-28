using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Canon : MonoBehaviour
{
    [Range(0f, 90f)] [SerializeField] private float maxAngle = 90;
    [field : SerializeField] public Transform MarblePosition { get; private set; } = null;
    [SerializeField] private PlayerInput input = null;
    [SerializeField] private PlayerMarble player = null;
    private Vector2 relativePosition;

    private void Awake()
    {
        relativePosition = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void Update()
    {
        Vector2 mouseDirection = GetMouseDirection();
        float angle = -Mathf.Atan2(mouseDirection.x, mouseDirection.y) * Mathf.Rad2Deg;
        angle -= 180;
        //angle = Mathf.Clamp(angle, -maxAngle, maxAngle);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void Propulse(InputAction.CallbackContext context)
    {
        player.Propulse(GetMouseDirection());
    }

    private Vector2 GetMouseDirection()
    {
        Vector2 mousePosition = input.actions["Aim"].ReadValue<Vector2>();
        Vector2 mouseRelativePosition = mousePosition - relativePosition;
        return mouseRelativePosition.normalized;
    }
}
