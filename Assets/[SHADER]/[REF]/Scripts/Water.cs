using System;
using UnityEngine;
using UnityEngine.Rendering;
using Object = UnityEngine.Object;

namespace WaterSystem {
    [ExecuteAlways]
    public class Water : MonoBehaviour {
        // Singleton
        private static Water _instance;
        public static Water Instance {
            get {
                if (_instance == null) {
                    _instance = (Water) FindObjectOfType(typeof(Water));                    
                }
                return _instance;
            }
        }

        // Script Reference

        private bool _useComputeBuffer;
        private bool computeOverride;

        [SerializeField] RenderTexture _depthTex;
        public Texture bakedDepthTex;
        private Camera _dephtCam;
        private Texture2D _rampTexture;
        [SerializeField]
        private ComputeBuffer waveBuffer;
        private float _maxWaveHeight;
        private float _waveHeight;

        [SerializeField]
        public WaterSettingsData settingsData;
        [SerializeField]
        public WaterSurfaceData surfaceData;
        [SerializeField]
        public WaterResources resources;

        private static readonly int CameraRoll = Shader.PropertyToID("_CameraRoll");
        private static readonly int InvViewProjection = Shader.PropertyToID("_invViewProjection");
        private static readonly int WaterDepthMap = Shader.PropertyToID("_WaterDepthMap");
        private static readonly int FoamMap = Shader.PropertyToID("_FoamMap");
        private static readonly int SurfaceMap = Shader.PropertyToID("_SurfaceMap");
        private static readonly int WaveHeight = Shader.PropertyToID("_WaveHeight");
        private static readonly int MaxWaveHeight = Shader.PropertyToID("_MaxWaveHeight");
        private static readonly int MaxDepth = Shader.PropertyToID("_MaxDepth");
        private static readonly int WaveCount = Shader.PropertyToID("_WaveCount");
        private static readonly int CubemapTexture = Shader.PropertyToID("_CubemapTexture");
        private static readonly int WaveDataBuffer = Shader.PropertyToID("_WaveDataBuffer");
        private static readonly int WaveData = Shader.PropertyToID("_WaveData");
        private static readonly int AbsorptionScatteringRamp = Shader.PropertyToID("_AbsorptionScatteringRamp");
        private static readonly int DepthCamZParamps = Shader.PropertyToID("_VeraslWater_DepthCamParams");

        void OnEnable() {
            if (!computeOverride) {
                _useComputeBuffer = SystemInfo.supportsComputeShaders &&
                                    Application.platform != RuntimePlatform.WebGLPlayer &&
                                    Application.platform != RuntimePlatform.Android;
            }
            else {
                _useComputeBuffer = false;
            }

            Init();
            RenderPipelineManager.beginCameraRendering += BeginCameraRendering;

            if (resources == null) {                
                resources = Resources.Load("WaterResources") as WaterResources;
            }
        }

        void OnDisable() {
            Cleanup();
        }

        void OnApplicationQuit() {
            //GerstnerWavesJobs cleaneup
        }

        void Cleanup() {
            RenderPipelineManager.beginCameraRendering -= BeginCameraRendering;
            if (_dephtCam) {
                _dephtCam.targetTexture = null;
                SafeDestroy(_dephtCam.gameObject);
            }

            if (_depthTex) {
                SafeDestroy(_depthTex);
            }

            waveBuffer?.Dispose();
        }

        private void BeginCameraRendering(ScriptableRenderContext src, Camera cam) {
            if (cam.cameraType == CameraType.Preview) return;

            var roll = cam.transform.localEulerAngles.z;
            Shader.SetGlobalFloat(CameraRoll, roll);
            Shader.SetGlobalMatrix(InvViewProjection, (GL.GetGPUProjectionMatrix(cam.projectionMatrix, false) * cam.worldToCameraMatrix).inverse);

            // Water matrix
            const float quantizeValue = 6.25f;
            const float forwards = 10f;
            const float yOffset = -0.25f;

            var newPos = cam.transform.TransformPoint(Vector3.forward * forwards);
            newPos.y = yOffset;
            newPos.x = quantizeValue * (int) (newPos.x / quantizeValue);
            newPos.z = quantizeValue * (int) (newPos.z / quantizeValue);

            var matrix = Matrix4x4.TRS(newPos + transform.position, Quaternion.identity, transform.localScale);

            foreach (var mesh in resources.defaultWaterMeshes) {
                Graphics.DrawMesh(
                  mesh,
                  matrix,
                  resources.defaultSeaMaterial,
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

        private static void SafeDestroy(Object o) {
            if (Application.isPlaying) {
                Destroy(o);
            }
            else {
                DestroyImmediate(o);
            }
        }

        public void Init() {
            SetWaves();
            GenerateColorRamp();

            if (bakedDepthTex) {
                Shader.SetGlobalTexture(WaterDepthMap, bakedDepthTex);
            }

            // plannar reflection

            if (resources = null) {
                resources = Resources.Load("WaterResources") as WaterResources;
                Debug.Log(resources);
            }

            if (Application.platform != RuntimePlatform.WebGLPlayer) {
                CaptureDepthMap();
            }
        }

        void LateUpdate() {

        }

        public void FragWaveNormals(bool toggle) {

        }
         
         private void SetWaves() {

         }

         private Vector4[] GetWaveData() {
            var waveData = new Vector4[20];
            return waveData;
         }

         private void SetupWaves (bool custom) {

         }

         private void GenerateColorRamp() {

         }

         //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
         //////////////////////////////////////Shoreline Depth Texture/////////////////////////////////////////////////////////
         //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

         [ContextMenu("Capture Depth")]
         public void CaptureDepthMap() {

         }

         [Serializable] 
         public enum DebugMode {none, stationary, screen};
    }

}