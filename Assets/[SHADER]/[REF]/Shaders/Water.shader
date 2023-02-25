Shader "Custom/Water" {
    Properties {
        _BumpScale("Detail Wave Amount", Range(0, 2)) = 0.2 // Fine detail multiplier
        _DitherPattern("Dithering Pattern", 2D) = "bump" {}
        [Toggle(_STATIC_SHADER)] _Static ("Static", Float) = 0
        [KeywordEnum(off, SSS, Refraction, Reflection, Normal, Fresnel, WaterEffects, Foam, WateDepth)] _Debug ("Degub mode", Float) = 0
    }
    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Transparent-100" "RenderPipeline"="UniversalPipeline"}
        Zwrite On

        Pass {
            Name "WaterShading"
            Tags {"LightMode"="UniversalForward"}

            HLSLPROGRAM
            #pragma prefer_hlslcc gles
            ///////////////////////SHADER FEATURES/////////////////////
            #pragma shader_feature _REFLECTION_PLANARREFLECTION
            #pragma multi_compile _ USE_STRUCTURED_BUFFER
            #pragma multi_compile _ _STATIC_SHADER
            #pragma shader_feature _DEBUG_OFF _DEBUG_SSS _DEBUG_REFRACTION _DEBUG_REFLECTION _DEBUG_NORMAL _DEBUG_FRESNEL _DEBUG_WATEREFFECTS _DEBUG_FOAM _DEBUG_WATERDEPTH

            // ---------------------------------
            // Lighweight Pipeline Keyword
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOES_CASCADE
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile _ _SHADOW_SOFT

            // ---------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing
            #pragma multi_compile_fog

            //////////////////////////INCLUDES/////////////////////////
            #include "/WaterCommon.hlsl"

            // non-tess
            #pragma vertex WaterVertex
            #pragma fragment WaterFragment

            ENDHLSL
        }
    }
    FallBack "Hidden/InternalErrorShader"
}
