using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace WaterSystem.Data {
    public class WaterSettingsDataEditor : Editor {
        public override void OnInspectorGUI() {
            var geomType = serializedObject.FindProperty("waterGeomType");
            EditorGUILayout.PropertyField(geomType);

            var refType = serializedObject.FindProperty("refType");
            refType.enumValueIndex = GUILayout.Toolbar(refType.enumValueIndex, refType.enumDisplayNames);

            switch (refType.enumValueIndex) {
                case 0: { // Cubemap
                    break;
                }
                case 1: { // probe
                    break;
                }
                case 2: { // Planar
                    var planarSettings = serializedObject.FindProperty("planarSettings");
                    EditorGUILayout.PropertyField(planarSettings, true);
                    break;
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
