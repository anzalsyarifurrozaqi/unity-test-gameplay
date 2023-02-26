using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WaterSystem.Data {
    // <summary>
    // This scriptable object stores teh graphical/rendering settings for water system
    // </summary>
    [System.Serializable][CreateAssetMenu(fileName = "WaterSettignsData", menuName = "WaterSystem/Settings", order =0)]
    public class WaterSettingsData : ScriptableObject {
        // public GeometryType waterGeomType; // The type of geometry, either vertex offset or tesselation        
        public PlanarReflections.PlanarReflectionSettings planarSettings; // Planar reflection settings
    }    

    /// <summary>
    /// The type of geometry, either vertex offset or tessellation
    /// </summary>
    [System.Serializable]
    public enum GeometryType {
        VertexOffset,
        Tesselation
    }
}