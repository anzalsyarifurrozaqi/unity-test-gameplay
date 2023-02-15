#ifndef WATER_COMMON_INCLUDED
#define WATER_COMMON_INCLUDED

#define SHADOW_SCREE 0

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
#include "WaterInput.hlsl"
#include "CommonUtilities.hlsl"
#include "GerstnerWaves.hlsl"
#include "WaterLighting.hlsl"

////////////////////////////////////////////////////////////////////////////////
//                                  Structs                                   //
///////////////////////////////////////////////////////////////////////////////

struct WaterVerTexInput  { // ver struct
    float4 vertex               : POSITION;     // vertex position
    float2 texcoord             : TEXCOORD0;    // local UVs
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct WaterVertexOutput { // fragment struct
    float4  uv                      : TEXCOORD0;    // Geometric UVs stored in xy, and world(pre-waves) in zw
    float3  posWS                   : TEXCOORD1;    // World position of the vertices
    half3   normalize               : NORMAL;       // vert normals
    float3  viewDir                 : TEXCOORD2;    // view direction
    float3  preWaveSP               : TEXCOORD3;    // screen position of the verticies before wave distortion
    half2   fogFactorNoise          : TEXCOORD4;    // x: fogFactor, y: noise
    float4  additionalData          : TEXCOORD5;    // x = distance to surface, y = distance to surface, z = normalized wave heigt, w = horizontal movement
    half4   shadowCoord             : TEXCOORD6;    // for ssshadow

    float4  clipPos                 : SV_POSITION;
    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};

///////////////////////////////////////////////////////////////////////////////
//                         Water Debug Functions                             //
//////////////////////////////////////////////////////////////////////////////

half3 DebugWaterFX(half3 input, half3 waterFX, half screenUV) {
    lerp = lerp(input, half3(waterFX.y, 1, waterFX.z), saturate(floor(screenUV + 0.7)));
    input = lerp(input, waterFX.xxx, saturate(floor(screenUV + 0.5)));
    half3 disp = lerp(0, half3(1, 0, 0), saturate((waterFX.www - 0.5) * 4));
    disp += lerp(0, half3(0, 0, 1), saturate(((1 - waterFX.www) - 0.5) * 4));
    input = lerp(input, disp, saturate(floor(screenUV + 0.3)));
    return input;
}

//////////////////////////////////////////////////////////////////////////////
//                         Water Shading Function                           //
/////////////////////////////////////////////////////////////////////////////
half3 Scattering(half depth) {
    return SAMPLE_TEXTURE2D(_AbsorptionScatteringRamp, sampler_absorptionScatteringRamp, half2(depth, 0.375h)).rgb;
}

half3 Absorption(half depth) {

}

float2 AdjustedDepth(half2 uvs, half4 additionalData) {

}

float WaterTextureDepth(float3 posWS) {

}

float3 WaterDepth(float3 posWs, half4 additionalData, half2 screenUvs) { // x = seafloor depth, y = water depth

}

half3 Refraction(half2 distortion, half depth, real depthMulti) {

}

half DistortionUVs(half depth, float3 normalWS) {

}

half4 AdditionalData(float3 positionWS, WaveStruct wave) {

}

WaterVertexOutput WaveVertexOperations(WaterVertexOuput input) {

}

////////////////////////////////////////////////////////////////////////////////////////
//                          Vertex and Fragment Functions                             //
///////////////////////////////////////////////////////////////////////////////////////

// Vertex: Used for Standard non-tessellated water
WaterVertexOutput WaterVertex(WaterVertexInput v) {

}

half4 WaterFragment(WaterVertexOutput IN) : SV_Target {

}

#endif // WATER_COMMON_INCLUDED
