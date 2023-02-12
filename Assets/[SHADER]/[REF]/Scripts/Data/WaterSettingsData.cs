using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WaterSystem.Data {
    // <summary>
    // This scriptable object stores teh graphical/rendering settings for water system
    // </summary>
    [System.Serializable][CreateAssetMenu(fileName = "WaterSettignsData", menuName = "WaterSystem/Settings", order =0)]
    public class WaterSettingsData : ScriptableObject {
        public GeometryType waterGeomType; // The type of geometry, either vertex offset or tesselation
        public ReflectionType refType = ReflectionType.PlanarReflection; // How teh reflections are generated
        
    }

    /// <summary>
    /// The type of reflection source, custom cubemap, closest reflection probe, planan reflection
    /// </summary>
    [System.Serializable]
    public enum ReflectionType {
        Cubemap,
        ReflectionProbe,
        PlanarReflection
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