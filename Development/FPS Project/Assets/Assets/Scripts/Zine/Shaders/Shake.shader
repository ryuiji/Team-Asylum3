﻿Shader "Custom/Shake" {
	Properties
	{

	}
	SubShader
	{
		Cull off ZWrite Off Ztest Always

		Pass
		{ 
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXTCOORD0;
			};
			struct v2f
			{
				float2 uv : TEXTCOORD0;
				float4 vertex : SV_POSITION;
			};
			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			float2 _shake;
			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
			fixed4 col2 = tex2D(_MainTex, i.uv + _shake);
			return lerp(col, col2, .5);
			}
			ENDCG
		}
		
	}


}
