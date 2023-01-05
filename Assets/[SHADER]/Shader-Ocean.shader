Shader "Unlit/Shader-Ocean" {
    // The properties block of the Unity shader. In this example this block is empty
    // because the output color is predefined in the fragment shader code.
    Properties
    { 
        _MainTex ("Texture", 2D) = "white" {}
        _ColorA ("Color A", Color) = (1,1,1,1)
        _ColorB ("Color B", Color) = (1,1,1,1)
    }

    // The SubShader block containing the Shader code. 
    SubShader
    {
        // SubShader Tags define when and under which conditions a SubShader block or
        // a pass is executed.
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline" "Queue" = "Transparent" }

        ZWrite Off

        Pass
        {
            // The HLSL code block. Unity SRP uses the HLSL language.
            HLSLPROGRAM
            // This line defines the name of the vertex shader. 
            #pragma vertex vert
            // This line defines the name of the fragment shader. 
            #pragma fragment frag

            // The Core.hlsl file contains definitions of frequently used HLSL
            // macros and functions, and also contains #include references to other
            // HLSL files (for example, Common.hlsl, SpaceTransforms.hlsl, etc.).
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            // #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/API/OpenGL.hlsl"         
            
            // The structure definition defines which variables it contains.
            // This example uses the MeshData structure as an input structure in
            // the vertex shader.
            struct MeshData
            {
                // The positionOS variable contains the vertex positions in object
                // space.
                float4 positionOS   : POSITION;
                float2 uv0          : TEXCOORD0;
            };

            struct Interpolators
            {
                // The positions in this struct must have the SV_POSITION semantic.
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
                float4 screenSpace  : TEXCOORD1;
            };            

            sampler2D _MainTex;
            TEXTURE2D_X (_CameraDepthTexture);
            float4 _MainTex_ST;
            float4 _ColorA;
            float4 _ColorB;            

            // The vertex shader definition with properties defined in the Interpolators 
            // structure. The type of the vert function must match the type (struct)
            // that it returns.
            Interpolators vert(MeshData IN)
            {
                // Declaring the output object (OUT) with the Interpolators struct.
                Interpolators OUT;
                // The TransformObjectToHClip function transforms vertex positions
                // from object space to homogenous space
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv0, _MainTex);                
                OUT.screenSpace = ComputeScreenPos(OUT.positionHCS);
                return OUT;
            }            
                        
            float LoadCameraDepth(uint2 pixelCoords)
            {
                return LOAD_TEXTURE2D_X_LOD(_CameraDepthTexture, pixelCoords, 0).r;
            }

            float SampleCameraDepth(float2 uv)
            {
                return LoadCameraDepth(uint2(uv * _ScreenSize.xy));
            }
 

            // The fragment shader definition.            
            float4 frag(Interpolators i) : SV_Target
            {                
                float4 col = tex2D(_MainTex, i.uv);
                float2 screenSpaceUV = i.screenSpace.xy / i.screenSpace.w;

                float depth = Linear01Depth(SampleCameraDepth(screenSpaceUV), _ZBufferParams);
                float3 color = lerp(_ColorA, _ColorB, depth);
                return float4(color,1);
            }
            ENDHLSL
        }
    }
}
