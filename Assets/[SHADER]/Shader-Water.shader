Shader "Universal Render Pipeline/water"
{
    Properties
    {
        [HideInInspector] _BaseMap("Albedo", 2D) = "white" {}
        _Depth("Depth", Float) = 9
        [HDR]_ShallowColor("Shallow Color", Color) = (0.27, 0.58, 0.76, 0.57)
        [HDR]_DeepColor("Deep Color", Color) = (0, 0.04, 0.17, 0.92)
        [HDR]_FoamColor("Foam Color", Color) = (1, 1, 1, 1)
        _Foam("Foam: Amount(x) Scale(y) Cutoff(z) Speed(w)", Vector) = (1, 120, 5, 1)
        _Refraction("Refraction: Strength(x) Scale(y) Speed(z)", Vector) = (0.002, 40, 1)
        _Wave("Wave: Velocity(x, y) Intensity(z)", Vector) = (1, 1, 0.2)
        _SpecularExponent("Specular Exponent", float) = 1
    }
    SubShader
    {
        Tags {"RenderPipeline" = "UniversalPipeline" "IgnoreProjector" = "True" "RenderType" = "Transparent" "Queue" = "Transparent"}

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

        TEXTURE2D(_BaseMap); SAMPLER(sampler_BaseMap); float4 _BaseMap_ST;
        TEXTURE2D_X(_CameraOpaqueTexture); SAMPLER(sampler_CameraOpaqueTexture); float4 _CameraOpaqueTexture_TexelSize;
        TEXTURE2D_X(_CameraDepthTexture); SAMPLER(sampler_CameraDepthTexture); 

        float _Depth;
        half4 _DepthColor;
        half4 _ShallowColor;
        half4 _DeepColor;
        half4 _FoamColor;
        float4 _Foam;
        float3 _Refraction;
        float3 _Wave;
        float _SpecularExponent;

        struct MeshData
        {
            float4 positionOS           : POSITION; // position object space
            float3 normal               : NORMAL;
            float2 uv                   : TEXCOORD0;
            UNITY_VERTEX_INPUT_INSTANCE_ID
        };

        struct Interpolators
        {
            float4 positionCS           : SV_POSITION; // position clip space
            float3 normal               : TEXCOORD0;
            float2 uv                   : TEXCOORD1;                
            float4 screenPos            : TEXCOORD2;
            float3 positionWS           : TEXCOORD3;
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

            void Unity_Combine_float(float R, float G, float B, float A, out float4 RGBA, out float3 RGB, out float2 RG)
            {
                RGBA = float4(R, G, B, A);
                RGB = float3(R, G, B);
                RG = float2(R, G);
            }

            // void Unity_SceneColor_float(float4 UV, out float3 Out)
            // {
            //     Out = SHADERGRAPH_SAMPLE_SCENE_COLOR(UV);
            // }            


            float LoadCameraDepth(uint2 pixelCoords)
            {
                return LOAD_TEXTURE2D_X_LOD(_CameraDepthTexture, pixelCoords, 0).r;
            }

            void SampleCameraDepth(float2 uv, out float Out)
            {
                Out = LoadCameraDepth(uint2(uv * _ScreenSize.xy));
            }

            float SampleSceneDepth(float2 UV) {
                return SAMPLE_TEXTURE2D_X(_CameraDepthTexture, sampler_CameraDepthTexture, UnityStereoTransformScreenSpaceTex(UV)).r;
            }

            float WaterDepthFade(float Depth, float4 ScreenPosition, float Distance) {
                return saturate((Depth - ScreenPosition.w) / Distance);
            }

            float2 WaterRefractedUV(float2 UV, float Strength, float Scale, float Speed, float2 ScreenUV) {
                float2 tiledAndOffsettedUV = UV * Scale + (_Time.y * Speed);
                float tileAndOffsetedUVNoise;
                Unity_GradientNoise_float(tiledAndOffsettedUV, 1, tileAndOffsetedUVNoise);
                float gNoiseRemapped = tileAndOffsetedUVNoise * 2 * Strength;
                return ScreenUV + gNoiseRemapped;
            }

            float3 SampleSceneColor(float2 UV) {
                return SAMPLE_TEXTURE2D_X(_CameraOpaqueTexture, sampler_CameraOpaqueTexture, UnityStereoTransformScreenSpaceTex(UV)).rgb;
            }


            Interpolators vert (MeshData v)
            {
                UNITY_SETUP_INSTANCE_ID(v);
                Interpolators o;                
                o.uv = TRANSFORM_TEX(v.uv, _BaseMap);
                o.normal = v.normal;
                o.positionWS = TransformObjectToWorld(v.positionOS.xyz); // vertex position in world space
                float positionWSNoise;
                Unity_GradientNoise_float(o.positionWS.xz + _Time.y * _Wave.xy, 1, positionWSNoise);
                float3 displacement = float3(0, positionWSNoise * _Wave.z, 0);
                o.positionWS += displacement;
                o.positionCS = mul(UNITY_MATRIX_VP, float4(o.positionWS, 1));
                o.screenPos = ComputeScreenPos(o.positionCS);                      

                return o;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                // Lighting
                float3 N = normalize (i.normal);
                float3 L = _MainLightPosition.xyz;

                // Difuse lighting
                float3 difuseLighting = saturate (dot (N,L)) * _MainLightColor.xyz;
                // return float4(difuseLighting, 1);?

                // Specular lighting
                float3 V = normalize (GetCameraPositionWS() - i.positionWS);
                float3 R = reflect (-L, N); // Reflect Vector
                float3 specularLighting = saturate (dot (R, V));
                specularLighting = pow (specularLighting, _SpecularExponent);
                // return float4(specularLighting.xxx, 1);
                // Screen Depth
                float2 screenUV = i.screenPos.xy / i.screenPos.w;
                float zEye = LinearEyeDepth (SampleSceneDepth(screenUV), _ZBufferParams);

                float4 depthColor = lerp(_ShallowColor, _DeepColor, WaterDepthFade(zEye, i.screenPos, _Depth));

                // Foam
                float foam = WaterDepthFade(zEye, i.screenPos, _Foam.x) * _Foam.z;
                float2 foamUV = i.uv * _Foam.y + (_Foam.w * _Time.y);
                float foamUVNoise;
                Unity_GradientNoise_float(foamUV, 1, foamUVNoise);
                float gNoise = foamUVNoise + 0.5;
                float4 foamValue = step(foam, gNoise) * _FoamColor.a;

                float4 waterColor = lerp(depthColor, _FoamColor, foamValue);

                // Refract
                float2 refractedUV = WaterRefractedUV(i.uv, _Refraction.x, _Refraction.y, _Refraction.z, screenUV);
                float4 refractedSceneColor = float4(SampleSceneColor(refractedUV), 1);

                // return lerp(refractedSceneColor, waterColor, waterColor.a);
                float4 outColor = lerp(refractedSceneColor, waterColor, waterColor.a);
                float3 outColor1 = outColor.xyz + specularLighting;
                return float4 (outColor1,1);



                // Foam;                                   
                // float depth;
                // float2 screenSpaceUV = i.screenSpace.xy / i.screenSpace.w;                
                // float _Camera_FarPlane = _ProjectionParams.z;                
                // SampleCameraDepth(screenSpaceUV, depth);
                // float linierDepth = Linear01Depth (depth, _ZBufferParams);
                // float linierDepth_CameraFarPlane = linierDepth * _Camera_FarPlane;

                // float screenSpaceDepth = i.screenSpace.w + _Depth;

                // float outColor = (linierDepth_CameraFarPlane - screenSpaceDepth) * _Strength;
                // outColor = clamp (outColor, 0, 1);
                // outColor = lerp (_ColorA, _ColorB, outColor);                
                // return outColor;

                // float2 worldPositionSplit = i.worldPosition.xz;
                // float2 time = _Time.y * 0.1;
                // float2 tilingAndOffset;
                // float gradientNoise;
                // Unity_TilingAndOffset_float(worldPositionSplit, float2(1,1), time, tilingAndOffset);
                // Unity_GradientNoise_float(tilingAndOffset, 2, gradientNoise);

                // float screenSub = linierDepth - i.screenSpace.w;                
                // return (gradientNoise - screenSub) / 2;
                





                // // Foam
                // float2 worldPositionSplit = i.worldPosition.xz;
                // float2 time = _Time.y * 0.1;
                // float2 tilingAndOffset;
                // float gradientNoise;
                // Unity_TilingAndOffset_float(worldPositionSplit, float2(1,1), time, tilingAndOffset);
                

                // float sceneDepth;
                // float2 screenSpaceUV = i.screenSpace.xy / i.screenSpace.w;
                // SampleCameraDepth(screenSpaceUV, sceneDepth);
                // float screenSub = sceneDepth - i.screenSpace.w;

                // return (gradientNoise + screenSub) / 2;

                // float4 outColor = float4(tilingAndOffsite, 0, 1);
                // return outColor;

            }

            ENDHLSL
        }
    }
}
