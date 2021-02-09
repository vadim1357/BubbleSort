using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GameManager))]

public class BubbleSortEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("BubbleSort"))
        {
            var x = target as GameManager;
            x.Clear();
            x.RunBubbleSort();
        }
    }
}
