Shader "Custom/ChromaKey"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ChromaKeyColor ("Chroma Key Color", Color) = (0,1,0,1)
        _Threshold ("Threshold", Range(0,1)) = 0.4
        _Smooth ("Smooth", Range(0,1)) = 0.1
    }
    SubShader
    {
        Tags {"Queue"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        Lighting Off
        ZWrite Off
        Cull Off
        Fog { Mode Off }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _ChromaKeyColor;
            float _Threshold;
            float _Smooth;

            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float diff = distance(col.rgb, _ChromaKeyColor.rgb);
                float alpha = smoothstep(_Threshold, _Threshold + _Smooth, diff);
                col.a *= alpha;
                return col;
            }
            ENDCG
        }
    }
}
