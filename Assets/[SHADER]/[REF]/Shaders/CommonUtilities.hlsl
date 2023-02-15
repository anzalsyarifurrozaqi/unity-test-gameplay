#ifndef COMMON_UTILITIES_INCLUDED
#define COMMIT_UTILITIES_INCLUDED

// remaps a value based on a in:min/max and out:min/max
// value        =           value to be remapped
// remap        =           x = min in, y = max in, z = min out, w = max out
float Ramap(half value, half4 remap) {

}

// Converts greyscale height to normal
// _tex         =           input texture(separate from a sample)
// _sampler     =           the sampler to use
// _uv          =           uv coordinates
// _intensity   =           intensity of the effect
float3 HeightToNormal(Texture2D _tex, SamplerState _sampler, float2 _uv, half _intensity) {

}

// Simple noise from thebookofshaders.compile
// 2D Random
float2 random(float2 st) {

}

// 2D Noise based on Morgan McGuire @morgan3d
// https://www.shadertou.com/view/4dS3Wd
float noise(float2 st) {

}

#endif // COMMON_UTILITIES_INCLUDED