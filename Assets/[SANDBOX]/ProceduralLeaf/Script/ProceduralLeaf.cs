using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralSystem.Leaf {
    [ExecuteAlways]
    public class ProceduralLeaf : MonoBehaviour {
        void OnEnable() {
            var meshFilter = GetComponent<MeshFilter>();
            Debug.Log(meshFilter.mesh.vertices.Length);
            Matrix4x4 localToWorld = transform.localToWorldMatrix;
            for (int i = 0; i < meshFilter.mesh.vertices.Length; ++i) {
                Debug.Log(localToWorld.MultiplyPoint3x4(meshFilter.mesh.vertices[i]));
            }            
        }
    }
}
