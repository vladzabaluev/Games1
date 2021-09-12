// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/My First shader"
{
    Properties
    {
    _Tint("Tint", Color) = (1, 1, 1, 1)
    _MainTex("Texture", 2D) = "white" {}
    _DopTex("Texture", 2D) = "black" {}
    }


    Subshader
    {

        Pass
        {
            CGPROGRAM
            #pragma vertex MyVertexProgram
            #pragma fragment MyFragmentProgram

            #include "UnityCG.cginc"
            float4 _Tint;
            sampler2D _MainTex;
            sampler2D _DopTex;
            float4 _MainTex_ST;
            float4 _DopTex_ST;

            struct Interpolators {
               float4 position : SV_POSITION;
               float2 uv :TEXTCOORD0;
            };


            struct VertexData {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
            };


            Interpolators MyVertexProgram(VertexData v) {
                Interpolators i;
                i.position = UnityObjectToClipPos(v.position);
                i.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return i;
            }


            float4 MyFragmentProgram(Interpolators i) : SV_TARGET{
            return  tex2D(_MainTex, i.uv) * _Tint;

            }
            
            
            ENDCG

        }
    }

}
