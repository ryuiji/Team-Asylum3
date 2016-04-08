using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(RoomID))]
public class RoomIDEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RoomID roomID = (RoomID)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Build Room"))
        {
            roomID.BuildRoom();
            NavMeshBuilder.BuildNavMesh();
        }
    }
}
