Shader "Unlit/water"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ColorA ("Color A", Color) = ( 1, 1, 1, 1 )
        _ColorB ("Color B", Color) = ( 1, 1, 1, 1 )
    }
    SubShader
    {
        Tags {"RenderPipeline" = "UniversalPipeline" "RenderType" = "Transparent" "Queue" = "Transparent"}

        Name "Water"
        Tags { "LightMode" = "UniversalForward" }

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        // Cull front
        
        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"      

        #define TAU 6.283185307179586             

        // CBUFFER_START(UnityPerMaterial)
        //     float4 _BaseColor;
        // CBUFFER_END

        TEXTURE2D( _MainTex );
        TEXTURE2D_X (_CameraDepthTexture);
        float4 _ColorA;
        float4 _ColorB;
        SAMPLER ( sampler_MainTex );
        float4 _MainTex_ST;

        struct MeshData
        {
            float4 vertex   : POSITION;
            float2 uv       : TEXCOORD0;
        };

        struct Interpolators
        {
            float4 vertex           : SV_POSITION;
            float2 uv               : TEXCOORD0;                
            float4 screenSpace      : TEXCOORD1;
            float3 worldPosition    : TEXCOORD2;
        };            
        
        ENDHLSL

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag 

            float2 unity_gradientNoise_dir(float2 p)
            {
                p = p % 289;
                float x = (34 * p.x + 1) * p.x % 289 + p.y;
                x = (34 * x + 1) * x % 289;
                x = frac(x / 41) * 2 - 1;
                return normalize(float2(x - floor(x + 0.5), abs(x) - 0.5));
            }

            float unity_gradientNoise(float2 p)
            {
                float2 ip = floor(p);
                float2 fp = frac(p);
                float d00 = dot(unity_gradientNoise_dir(ip), fp);
                float d01 = dot(unity_gradientNoise_dir(ip + float2(0, 1)), fp - float2(0, 1));
                float d10 = dot(unity_gradientNoise_dir(ip + float2(1, 0)), fp - float2(1, 0));
                float d11 = dot(unity_gradientNoise_dir(ip + float2(1, 1)), fp - float2(1, 1));
                fp = fp * fp * fp * (fp * (fp * 6 - 15) + 10);
                return lerp(lerp(d00, d01, fp.y), lerp(d10, d11, fp.y), fp.x);
            }

            void Unity_GradientNoise_float(float2 UV, float Scale, out float Out)
            {
                Out = unity_gradientNoise(UV * Scale) + 0.5;
            }

            void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
            {
                Out = UV * Tiling + Offset;
            }

            float LoadCameraDepth(uint2 pixelCoords)
            {
                return LOAD_TEXTURE2D_X_LOD(_CameraDepthTexture, pixelCoords, 0).r;
            }

            void SampleCameraDepth(float2 uv, out float Out)
            {
                Out = LoadCameraDepth(uint2(uv * _ScreenSize.xy));
            }

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = TransformObjectToHClip(v.vertex.xyz);
                o.uv.x = 1 - o.uv.x;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);         
                o.screenSpace = ComputeScreenPos(v.vertex);      
                o.worldPosition = TransformWorldToObject(o.vertex);
                return o;
            }

            float4 frag (Interpolators i) : SV_Target
            {                         
                // Foam
                float2 worldPositionSplit = i.worldPosition.xz;
                float2 time = _Time.y * 0.1;
                float2 tilingAndOffset;
                float gradientNoise;
                Unity_TilingAndOffset_float(worldPositionSplit, float2(1,1), time, tilingAndOffset);
                Unity_GradientNoise_float(tilingAndOffset, 5, gradientNoise);

                float sceneDepth;
                float2 screenSpaceUV = i.screenSpace.xy / i.screenSpace.w;
                SampleCameraDepth(screenSpaceUV, sceneDepth);
                float screenSub = sceneDepth - i.screenSpace.w;

                return (gradientNoise + screenSub) / 2;

                // float4 outColor = float4(tilingAndOffsite, 0, 1);
                // return outColor;

            }

            ENDHLSL
        }
    }
}
