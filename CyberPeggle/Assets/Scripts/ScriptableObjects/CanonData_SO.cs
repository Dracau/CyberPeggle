using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CanonData", menuName = "Scriptable Objects/Canon Data")]
public class CanonData_SO : ScriptableObject
{
    public float PropulsionStrength = 5;
    [Range(10f, 90f)] public float MaxAngle = 85;
}
