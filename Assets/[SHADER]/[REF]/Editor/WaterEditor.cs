using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using WaterSystem.Data;

namespace WaterSystem {
    [CustomEditor(typeof(Water))]
    public class WaterEditor : Editor {
        public override void OnInspectorGUI() {
            serializedObject.Update();
            Water w = (Water) target;

            var waterSettingsData = serializedObject.FindProperty("settingsData");
            EditorGUILayout.PropertyField(waterSettingsData, true);
            if (waterSettingsData.objectReferenceValue != null) {
                CreateEditor((WaterSettingsData) waterSettingsData.objectReferenceValue).OnInspectorGUI();
            }

            var waterSurfaceData = serializedObject.FindProperty("surfaceData");
            EditorGUILayout.PropertyField(waterSurfaceData, true);
            if (waterSurfaceData.objectReferenceValue != null) {
                CreateEditor((WaterSurfaceData) waterSurfaceData.objectReferenceValue).OnInspectorGUI();
            }

            serializedObject.ApplyModifiedProperties();

            if (GUI.changed) {
                w.Init();
            }
        }

        void OnSceneGUI() {

        }

        void DrawWaveGizmo(Vector3 pos, float angle, float size, float length) {
            Handles.DrawSolidDisc(pos, Vector3.up, length / 2f);
            Handles.ArrowHandleCap(0, pos, Quaternion.AngleAxis(angle, Vector3.up), -length / 1.75f, EventType.Repaint);
        }
    }
}
