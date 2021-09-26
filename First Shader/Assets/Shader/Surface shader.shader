
Shader "Unlit/Surface shader"
{

    Properties
    {
        _Color("Tint", Color) = (0,0,0,1)
        _MainTex("Texture", 2D) = "white" {}
        _Smoothness("Smoothness", Range(0,1)) = 0
        _Metallic("Metallic", Range(0,1)) = 0
        [HDR]_Emission("Emission", Color) = (0,0,0)
        _MainBG("BackGround", 2D) = "white" {}
        _BGColor("BGColor", Color) = (0,0,0,1)
        _BGSmoothness("BGSmoothness", Range(0,1)) = 0
        _BGMetallic("BGMetallic", Range(0,1)) = 0
        [HDR]_BGEmission("Emission", Color) = (0,0,0)

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue" = "Geometry"}
    CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0
        
        sampler2D _MainTex, _MainBG;
        fixed4 _Color, _BGColor;

        half _Smoothness, _BGSmoothness;
        half _Metallic, _BGMetallic;
        half3 _Emission, _BGEmission;

        struct Input {
            float2 uv_MainTex, uv_MainBG;
        };

        void surf(Input i, inout SurfaceOutputStandard o) {
            fixed4 col = tex2D(_MainTex, i.uv_MainTex);
            fixed4 bg = tex2D(_MainBG, i.uv_MainTex);
            col *= _Color;
            bg *= _BGColor;
            o.Albedo = col.rgb * col.a + (1 - col.a) * bg.rgb;
            o.Metallic = _Metallic * col.a + (1 - col.a) * _BGMetallic;
            o.Smoothness = _Smoothness * col.a + (1 - col.a) * _BGSmoothness;
            o.Emission = _Emission * col.a + (1 - col.a) * _BGEmission;
            UNITY_APPLY_FOG(i.fogCoord, col);
        }

    ENDCG

        
    }
        FallBack "Standart"
}

