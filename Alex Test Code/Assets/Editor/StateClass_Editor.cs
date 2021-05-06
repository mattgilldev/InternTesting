using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StateClass))]
public class StateClass_Editor : Editor
{
    public override void OnInspectorGUI()
    {

        StateClass stateclass = (StateClass)target;

        base.OnInspectorGUI();

        GUI.backgroundColor = Color.red;
        if (stateclass.endstate == false && GUILayout.Button("EndState", GUILayout.Height(25)))
        {
            if (Application.isPlaying)
            {
                stateclass.EndThisState();
            }
        }

    }
}
