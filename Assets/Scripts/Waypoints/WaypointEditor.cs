using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    Waypoint waypointTarget => target as Waypoint;

    private void OnSceneGUI()
    {
        if (waypointTarget.Points.Length <= 0)
            return;

        Handles.color = Color.red;
        for(int i = 0; i < waypointTarget.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            Vector3 currentPoint = waypointTarget.EntityPosition + waypointTarget.Points[i];
            Vector3 newPosition = Handles.FreeMoveHandle(currentPoint, 0.5f, Vector3.one * .5f, Handles.SphereHandleCap);

            GUIStyle text = new GUIStyle();
            text.fontSize = 16;
            text.normal.textColor = Color.black;
            Vector3 textPos = new Vector3(0.2f, -0.2f);

            if(EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move");
                waypointTarget.Points[i] = newPosition - waypointTarget.EntityPosition;
            }
        }
    }
}
