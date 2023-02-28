#ifndef LEAF_COMMON_INCLUDED
#define LEAF_COMMON_INCLUDED

#define SHADOW_SCREE 0

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
#include "LeafInput.hlsl"


struct LeafVertexInput { // vert struc
    float4 vertex                   : POSITION;     // vertex position
    float2 texcoord                 : TEXCOORD0;    // local UVs
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct LeafVertexOutput { // fragment struct
    float4  uv                      : TEXCOORD0;        // Geometric UVs stored in xy, and world in zw
    float3  posWS                   : TEXCOORD1;        // World position of the vertices
    half3   normal                  : NORMAL;           // vert normals
    half2   fogFactorNoise          : TEXCOORD2;        // noise


    float4  clipPos                 : SV_POSITION;
    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};

LeafVertexOutput LeafVertex (LeafVertexInput v) {
    LeafVertexOutput o;
    UNITY_SETUP_INSTANCE_ID(v);
    UNITY_TRANSFER_INSTANCE_ID(v, o);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

    o.uv.xy = v.texcoord;
    o.posWS = TransformObjectToWorld(v.vertex.xyz);

    o.normal = float3(0, 1, 0);    
    // o.fogFactorNoise.y = ((noise((o.posWS.xz * 0.5) + _Time.y) + noise((o.posWS.xz * 1) + _Time.y)) * 0.25 - 0.5) + 1;

    // Detail UVs
    
    half4 screenUV = ComputeScreenPos(TransformWorldToHClip(o.posWS));
    screenUV.xyz /= screenUV.w;
    
    // o.uv.zw = o.posWS.xz * 0.1h * _Time.y + dis;
    
    o.clipPos = TransformWorldToHClip(o.posWS);

    return o;
}

half4 LeafFragment(LeafVertexOutput IN) : SV_TARGET {
    UNITY_SETUP_INSTANCE_ID(IN);

    return half4(0.2f, 1, 0, 1);
}

#endif