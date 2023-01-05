using UnityEngine;

[ExecuteInEditMode]
public class CameraProcessor : MonoBehaviour
{    
    void Start()
    {
        // DepthTextureMode.Depth を指定
        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
    }    
}
