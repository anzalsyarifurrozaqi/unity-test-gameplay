#ifndef WATER_LIGHTING_INCLUDED
#define WATER_LIGHTING_INCLUDED

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

#define SHADOW_ITERATIONS 4

half CalculateFresnelTerm(half3 normalWS, half3 viewDirectionWS) {

}

////////////////////////////////////////////////////////////////////////////////
//                      Lighting Calculations                                 //
///////////////////////////////////////////////////////////////////////////////

// difuse
half4 VertexLightingAndfog(half3 normalWS, half3 posWS, half3 clipPos) {

}

// specular
half3 Highlights(half3 positionWS, half roughness, half3 normalWS, half3 viewDirectionWS) {

}

// Soft Shadows
half SoftShadows(float3 screenUV, float3 positionWS, half3 viewDir, half depth) {

}
//////////////////////////////////////////////////////////////////////////////////
//                          Reflection Modes                                    //
/////////////////////////////////////////////////////////////////////////////////
half3 SampleReflections(half3 normalWS, half3 viewDirectionWS, half2 screeUV, half roughness) {

}

#endif // WATER_LIGHTING_INCLUDED