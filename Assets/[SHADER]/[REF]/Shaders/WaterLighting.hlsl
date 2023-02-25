#ifndef WATER_LIGHTING_INCLUDED
#define WATER_LIGHTING_INCLUDED

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

#define SHADOW_ITERATIONS 4

half CalculateFresnelTerm(half3 normalWS, half3 viewDirectionWS) {
    return saturate(pow(1.0 - dot(normalWS, viewDirectionWS), 5)); // Fresnel TODO - find a better place
}

////////////////////////////////////////////////////////////////////////////////
//                      Lighting Calculations                                 //
///////////////////////////////////////////////////////////////////////////////

// difuse
half4 VertexLightingAndfog(half3 normalWS, half3 posWS, half3 clipPos) {
    half3 vertexLight = VertexLighting(posWS, normalWS);
    half fogFactor = ComputeFogFactor(clipPos.z);
    return half4(fogFactor, vertexLight);
}

// specular
half3 Highlights(half3 positionWS, half roughness, half3 normalWS, half3 viewDirectionWS) {
    Light mainLight = GetMainLight();

    half roughness2 = roughness * roughness;
    half3 halfDir = SafeNormalize(mainLight.direction + viewDirectionWS);
    half NoH = saturate(dot(normalize(normalWS), halfDir));
    half LoH = saturate(dot(mainLight.direction, halfDir));
    // GGX Distribution multiplied by combined approximation of Visibility and Fresnel
    // See "Optimizing PBR for Mobile" from Siggraph 2015 moving mobile graphics course
    // https://community.arm.com/events/1155
    half d = NoH * NoH * (roughness2 - 1.h) + 1.0001h;
    half LoH2 = LoH * LoH;
    half specularTerm = roughness2 / ((d * d) * max(0.1h, LoH2) * (roughness + 0.5h) * 4);
    // on mobiles (where half actually means something) denominator have risk of overflow
    // clamp below was added specifically to "fix" that, but dx compiler (we convert bytecode to metal/gles)
    // sees that specularTerm have only non-negative terms, so it skips max(0,..) in clamp (leaving only min(100,...))
    #if defined(SHADER_API_MOBILE)
        specularTerm = specularTerm - HALF_MIN;
        specularTerm = clamp(specularTerm, 0.0, 5.0); // Prevent FP16 overflow on mobiles
    #endif

    return specularTerm * mainLight.color * mainLight.distanceAttenuation;
}

// Soft Shadows
half SoftShadows(float3 screenUV, float3 positionWS, half3 viewDir, half depth) {
    #if _MAIN_LIGHT_SHADOWSS
        half2 jitterUV = screenUV.xy * _screenUV.xy * _DitherPattern_TexelSize.xy;
        half shadowAttenuation = 0;

        float loopDiv = 1.0 / SHADOW_ITERATIONS;
        half depthFrac = depth * loopDiv;
        half3 lightOffset = -viewDir *depthFrac;
        for (uint i = 0u; i < SHADOW_ITERATIONS; ++i) {
            #ifndef _STATIC_SHADER
                jitterUV += frac(half2(_Time.x, -_Time.z));
            #endif
                float3 jitterTexture = SAMPLE_TEXTURE2D(_DitherPattern, sampler_ditherPattern, jitterUV + i * _ScreenParams.xy).xyz * 2 -1;
                half3 j = jitterTexture.xzy * depthFrac * i * 0.1;
                float3 lightJutter = (positionWS + j) + (lightOffset * (i + jutterTexture.y));
                shadowAtternuation += SAMPLE_TEXTURE2D_SHADOW(_mainLightShadowMapTexture, sampler_mainLightShadowmapTexture, TransformWorldToshadowCoord(lightJitter));                
        }
        return BEYOOND_SHADOW_FAR(TransformWorldToShadowCoord(positionWS * 1.1)) ? 1.0 : shadowAtternuation * loopDiv;
    #else
    return 1;
    #endif

}
//////////////////////////////////////////////////////////////////////////////////
//                          Reflection Modes                                    //
/////////////////////////////////////////////////////////////////////////////////
half3 SampleReflections(half3 normalWS, half3 viewDirectionWS, half2 screenUV, half roughness) {
    
}

#endif // WATER_LIGHTING_INCLUDED