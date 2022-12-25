Shader "Unlit/Shader-1" {
    Properties {
        _ColorA ("Color A", Color) = (1,1,1,1)
        _ColorB ("Color B", Color) = (1,1,1,1)
        _ColorStart ("Color Start", Range(0,1)) = 0
        _ColorEnd ("Color End", Range(0,1)) = 1
    }
    SubShader {
        Tags { "RenderType"="Opaque" }     

        Pass {
            CGPROGRAM
            // function name to vertex shader
            #pragma vertex vert 
            // function name to fragment shader
            #pragma fragment frag 

            // add another file from unity
            #include "UnityCG.cginc" 

            #define TAU 6.283185307179586

            struct MeshData { // per-vertex mesh data
                // : semantic
                float4 vertex : POSITION; // vertex position
                float3 normals : NORMAL;
                // float4 tangent : TANGENT; // 3 value in tangent direction 4 sine information
                // float4 color : COLOR; // RGBA
                float2 uv0 : TEXCOORD0; // uv coordianate    
                // float2 uv1 : TEXCOORD1; // uv coordianate    
            };

            struct Interpolators { // pass vertex shader to fragment shader
                float4 vertex : SV_POSITION; // clip space position
                float3 normal : TEXCOORD0; 
                float2 uv : TEXCOORD1; 
                // float2 uv : TEXCOORD0;
            };

            float4 _ColorA;
            float4 _ColorB;
            float _ColorStart;
            float _ColorEnd;

            Interpolators vert ( MeshData v ) {
                Interpolators o; // output
                o.vertex = UnityObjectToClipPos(v.vertex); // local space to clip space  
                o.normal = UnityObjectToWorldNormal(v.normals);
                o.uv = v.uv0;
                return o;
            }

            // float (32 bit float)
            // half (16 bit float)
            // fixed (lower precision) -1 to 1
            // float4 -> half4 -> fixed4
            // float4x4 -> half4x4 (c#: Matric4x4)

            // pc ussualy use float not support hafl & fixed (mobile)

            float InverLerp (float a, float b, float v) {
                return (v-a)/(b-a);
            }

            float4 frag(Interpolators i) : SV_Target{ // SV_Target is semantic, the target to fragment buffer
                // swizzling
                // float4 myValue;
                // float2 otherValue = myValue.xy;

                // blend between two colors base on uv x coordinate
                // float t = saturate( InverLerp(_ColorStart, _ColorEnd, i.uv.x) );
                // float4 outputColor = lerp(_ColorA, _ColorB, t);

                // triangle wave
                // float t = saturate( InverLerp(_ColorStart, _ColorEnd, i.uv.x) );
                // t = abs(frac(i.uv * 5) * 2 - 1);
                float t = cos(i.uv.x * TAU * 2) * 0.5 + 0.5;
                return t;

                // return outputColor;
            }
            ENDCG
        }
    }
}
