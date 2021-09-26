


Shader "Unlit/Invlerp_remap shader"
{
    Properties
    {
         _ColorA("ColorA", Color) = (0,0,0,1)
         _ColorB("ColorB", Color) = (1,1,1,1)
         _ColorStart("Color Start", Range(0,1)) = 0
         _ColorEnd("Color end", Range(0,1)) = 1
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque"}
        LOD 100

        Pass
        {
            CGPROGRAM

            //float lerp(float from, float to, float rel)
            //{
            //    return ((1 - rel) * from) + (rel * to);
            //}


//            float remap(float origFrom, float origTo, float targetFrom, float targetTo, float value) {
//                float rel = invLerp(origFrom, origTo, value);
//                return lerp(targetFrom, targetTo, rel);
//}

            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            float4 _ColorA;
            float4 _ColorB;

            float _ColorStart;
            float _ColorEnd;

            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normal:NORMAL;
                float2 uv0 : TEXCOORD0;
            };

            struct Interpolator
            {
                float2 uv : TEXCOORD1;
                float3 normal : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            Interpolator vert (MeshData v)
            {
                Interpolator o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.uv = v.uv0;

                return o;
            }



            float invLerp(float from, float to, float value) {
                return (value - from) / (to - from);
            }

            float4 frag(Interpolator i) : SV_Target
            {
                // sample the texture

            float t = invLerp(_ColorStart, _ColorEnd, i.uv.x);
            float4 col = lerp(_ColorA, _ColorB, t);
                return col;
            }
            ENDCG
        }
    }
}
