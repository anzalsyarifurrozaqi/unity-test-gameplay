using UnityEngine;
using System.Collections.Generic;
using ProceduralSystem.Leaf.Data;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.Universal;

namespace ProceduralSystem.Leaf {
    [ExecuteAlways]
    public class ProceduralLeaf : MonoBehaviour {
        private List<Vector3> Positions = new List<Vector3>(); // for test only
        public float yIndex = 0.0f;
        [Range(1,5)]
        public int OffsetLeafCount;
        private Vector3 Position;
        public ProceduralLeafResources LeafResources;

        void OnEnable() {
            if (!LeafResources) {
                LeafResources = Resources.Load("ProceduralLeafResources") as ProceduralLeafResources;
            }

            RenderPipelineManager.beginCameraRendering += BeginCameraRendering;
        }

        void OnDisable() {
            Cleanup();
        }

        void Cleanup() {
            RenderPipelineManager.beginCameraRendering -= BeginCameraRendering;
        }

        void BeginCameraRendering(ScriptableRenderContext src, Camera cam) {
            if (cam.cameraType == CameraType.Preview) return;

            var mesh = GetComponent<MeshFilter>().sharedMesh;
            Matrix4x4 localToWorld = transform.localToWorldMatrix;
            for (int i = 0; i < mesh.vertices.Length; ++i) {
                if (mesh.vertices[i].y > yIndex) {
                    var matrix = Matrix4x4.TRS(localToWorld.MultiplyPoint(mesh.vertices[i]), Quaternion.identity, transform.localScale * 0.1f);
                    Graphics.DrawMesh(
                        LeafResources.Mesh,
                        matrix,
                        LeafResources.Material,
                        gameObject.layer,
                        cam,
                        0,
                        null,
                        ShadowCastingMode.Off,
                        true,
                        null,
                        LightProbeUsage.Off,
                        null
                    );
                    
                    for (int j = 0; j < OffsetLeafCount; ++j) {                                              
                        var matrix2 = Matrix4x4.TRS(Position + localToWorld.MultiplyPoint(mesh.vertices[i]), Quaternion.identity, transform.localScale * 0.1f);
                        Graphics.DrawMesh(
                            LeafResources.Mesh,
                            matrix2,
                            LeafResources.Material,
                            gameObject.layer,
                            cam,
                            0,
                            null,
                            ShadowCastingMode.Off,
                            true,
                            null,
                            LightProbeUsage.Off,
                            null
                        );                                             
                    }
                }
            }
        }
        void OnValidate() {          
            var offset = 0.1f;            
            var x = Random.Range(-offset, offset);
            var y = Random.Range(-offset, offset);
            var z = Random.Range(-offset, offset);            
            Position = new Vector3(x, y, z);                       
        }

        void OnDrawGizmosSelected() {        
        }
    }
}
