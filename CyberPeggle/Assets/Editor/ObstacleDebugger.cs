using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Obstacle), true)]
public class ObstacleDebugger : Editor
{
    public override void OnInspectorGUI()
    {
        Obstacle obstacle = (Obstacle)target;
        base.OnInspectorGUI();
        if(!Application.isPlaying) return;
        if (GUILayout.Button("Hit"))
        {
            obstacle.Hit();
        }
    }
}
