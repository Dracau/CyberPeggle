using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class Canon : MonoBehaviour
{
    [SerializeField] private CanonData_SO canonData = null;
    [field : SerializeField] public Transform MarblePosition { get; private set; } = null;
    [SerializeField] private PlayerInput input = null;
    private Vector2 relativePosition;

    private void Update()
    {
        Aim();
        relativePosition = Camera.main!.WorldToScreenPoint(transform.position);
    }

    private void Aim()
    {
        // Canon aims at mouse position
        if(MenuManager.instance.paused) return;
        Vector2 directionToLookAt = -GetMouseDirection();
        float angle = -Mathf.Atan2(directionToLookAt.x, directionToLookAt.y) * Mathf.Rad2Deg;
        float maxAngle = canonData.MaxAngle;
        angle = Mathf.Clamp(angle, -maxAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private Vector2 GetMouseDirection()
    {
        // Return the current direction of the mouse, relative to the canon
        Vector2 mousePosition = input.actions["Aim"].ReadValue<Vector2>();
        Vector2 mouseRelativePosition = mousePosition - relativePosition;
        return mouseRelativePosition.normalized;
    }
    
    public void LaunchMarble(InputAction.CallbackContext context)
    {
        // Launch player marble when left mouse button is pressed
        if(MenuManager.instance.paused) return;
        if (!context.started) return;
        PlayerMarble player = GameManager.Instance.LevelManager.Player;
        if (player.IsInsideCanon == true)
        {
            Vector2 direction = MarblePosition.transform.position - transform.position;
            Vector2 force = direction.normalized * canonData.PropulsionStrength;
            player.Launch(force);
        }
    }
}
