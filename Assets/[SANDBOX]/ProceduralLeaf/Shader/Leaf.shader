Shader "Custom/Leaf" {
    Properties {
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline"}
        
        pass {
            Name "LeafShading"
            Tags {"LighMode"="UniversalForward"}

            HLSLPROGRAM
            #pragma prefer_hlslcc gles
            


            // -------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing
            #pragma multi_compile_fog

            ///////////////////////INCLUDES//////////////////////
            #include "/LeafCommon.hlsl"

            // not-tess
            #pragma vertex LeafVertex
            #pragma fragment LeafFragment

            ENDHLSL
        }
    }
    FallBack "Hidden/InternalErrorShader"
}
