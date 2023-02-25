#ifndef WATER_INPUT_INCLUDED
#define WATER_INPUT_INCLUDED

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

CBUFFER_START(UnityPerMaterial)
half _BumpScale;
half4 _DitherPattern_TexelSize;
CBUFFER_END
half _MaxDepth;
half _MaxWaveHeight;
int _DebugPass;
half4 _VeraslWater_DepthCamParams;
float4x4 _InvViewProjection;

// Screen Effects Textures
SAMPLER(sampler_ScreenTextures_linear_clamp);
#if defined(_REFLECTION_PLANERREFLECTION)
TEXTURE2D(_PlanarReflectionTexture);
#elif defined(_RELFECTION_CUBEMAP)
TEXTURECUBE(_CubemapTexture);
SAMPLER(sampler_CubemapTexture);
#endif
TEXTURE2D(_WaterFXMap);
TEXTURE2D(_CameraDepthTexture);
TEXTURE2D(_CameraOpaqueTexture); SAMPLER(sampler_cameraOpaqueTexture_linear_clamp);
TEXTURE2D(_WaterDepthMap); SAMPLER(sampler_WaterDepthMap_linear_clamp);

// Surface Textures
TEXTURE2D(_AbsorptionScatteringRamp); SAMPLER(sampler_AbsorptionScatteringRamp);
TEXTURE2D(_SurfaceMap); SAMPLER(sampler_SurfaceMap);
TEXTURE2D(_FoamMap); SAMPLER(sampler_FoamMap);
TEXTURE2D(_DitherPattern); SAMPLER(sampler_ditherPattern);

struct WaterSurfaceData {

};

#endif // WATER_INPUT_INCLUDED