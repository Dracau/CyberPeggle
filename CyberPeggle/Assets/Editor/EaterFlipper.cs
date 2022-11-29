using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Eater))]
public class EaterFlipper : Editor
{
    public override void OnInspectorGUI()
    {
        Eater eater = (Eater)target;
        base.OnInspectorGUI();
        if(GUILayout.Button("Flip")) eater.transform.localScale = new Vector3(-eater.transform.localScale.x, eater.transform.localScale.y, eater.transform.localScale.z);
    }
}
