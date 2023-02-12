using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Serialization;
using Unity.Mathematics;

namespace UnityEngine.Rendering.Universal {
    [ExecuteAlways]
    public class PlanarReflections : MonoBehaviour {
        [Serializable]
        public enum ResolutionMulltiplier {
            Full,
            Half,
            Third,
            Quarter
        }

        [Serializable]
        public class PlanarReflectionSettings {
            public ResolutionMulltiplier m_ResolutionMultiplier = ResolutionMulltiplier.Third;
            public float m_ClipPlaneOffset = 0.07f;
            public LayerMask m_ReflectLayers = -1;
            public bool m_Shadows;
        }

        [SerializeField]
        public PlanarReflectionSettings m_Settings = new PlanarReflectionSettings();

        public GameObject targe;
        [FormerlySerializedAs("camOffset")] public float m_planeOffset;

        private static Camera _reflectionCamera;
        private RenderTexture _reflectionTexture;
        private readonly int _planarReflectionTexture = Shader.PropertyToID("_PlanarRefelctionTexture");

        private int2 _oldReflectionTextureSize;

        public static event Action<ScriptableRenderContext, Camera> BeginPlanarReflection;

        void OnEnable() {
            
        }

        void OnDisable() {

        }

        void OnDestroy() {

        }

        void Cleanup() {

        }

        private static void SafeDestroy(Object obj) {

        }

        private void UpdateCamera(Camera src, Camera dest) {

        }

        private void UpdateReflectionCamera(Camera realCamera) {

        }

        private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane) {

        }

        private static Vector3 ReflectionPosition(Vector3 pos) {
            return Vector3.zero;
        }

        private float GetScaleValue() {
            return 0f;
        }

        // Compare two int2
        private static bool Int2Compare(int2 a, int2 b) {
            return false;
        }

        private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign) {
            return Vector4.zero;
        }

        private Camera CreateMirrorObjects() {
            return null;
        }

        private void PlanarReflectionTexture(Camera cam) {

        }

        private int2 ReflectionResolution(Camera cam, float scale) {
            return int2.zero;
        }

        private void ExecutePlanarReflections(ScriptableRenderContext context, Camera cam) {

        }

        class PlanarReflectionSettingData {
            private readonly bool _fog;
            private readonly int _maxLod;
            private readonly float _lodBias;

            public PlanarReflectionSettingData() {

            }

            public void Set() {

            }

            public void Restore() {
                
            }
        }
    }
}