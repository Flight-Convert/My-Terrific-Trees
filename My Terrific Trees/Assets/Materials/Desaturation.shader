Shader "Hidden/Desaturation"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Saturation ("Saturation", Range(0,1)) = 1.0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
			float _Saturation;

            fixed4 frag (v2f i) : SV_Target
            {
				fixed4 col = tex2D(_MainTex, i.uv);

				fixed4 saturatedColor;
				fixed average = (col.r + col.g + col.b) / 3;
				saturatedColor.r = lerp(average, col.r, _Saturation);
				saturatedColor.g = lerp(average, col.g, _Saturation);
				saturatedColor.b = lerp(average, col.b, _Saturation);
				saturatedColor.a = col.a;

				return saturatedColor;
            }
            ENDCG
        }
    }
}
