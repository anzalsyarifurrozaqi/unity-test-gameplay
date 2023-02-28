using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralSystem.Leaf.Data {
    [System.Serializable]
    [CreateAssetMenu(fileName = "ProceduralLeafResources", menuName = "ProceduralSystem/Resources/Leaf", order = 0)]
    public class ProceduralLeafResources : ScriptableObject {
        public Mesh Mesh;
        public Material Material;        
    }
}
