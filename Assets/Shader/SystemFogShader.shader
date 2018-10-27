Shader "Custom/SystemFogShader" {
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_FogColor("Color", Color) = (1,1,1,1)
		_Ambient("Ambient", Color) = (1,1,1,1)
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}
	SubShader{

		Tags { "RenderType" = "Opaque" }
		LOD 200

		Pass{
			// use gloabe fog setting in Window -> lighting -> setting -> Scene
			Name "FOG"
			Tags { "LightMode" = "ForwardBase" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			#pragma multi_compile_fwdbase
			// make fog work
			#pragma multi_compile_fog

			struct v2f
			{
				float2 uv : TEXCOORD0;
				SHADOW_COORDS(1) // put shadows data into TEXCOORD1
				UNITY_FOG_COORDS(2) // put fog data into TEXCOORD2
				fixed3 diff : COLOR0;
				fixed3 ambient : COLOR1;
				float4 pos : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _FogColor;
			float4 _Ambient;

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				// o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				half3 worldNormal = UnityObjectToWorldNormal(v.normal);
				half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
				o.diff = nl * _LightColor0.rgb;
				//o.ambient = ShadeSH9(half4(worldNormal,1));
				o.ambient = _Ambient.rgb;
				// compute shadows data
				TRANSFER_SHADOW(o)
				UNITY_TRANSFER_FOG(o, o.pos);
				return o;
			}


			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				// compute shadow attenuation (1.0 = fully lit, 0.0 = fully shadowed)
				fixed shadow = SHADOW_ATTENUATION(i);
				// darken light's illumination with shadow, keep ambient intact
				fixed3 lighting = i.diff * shadow + i.ambient;
				col.rgb *= lighting;
				UNITY_APPLY_FOG_COLOR(i.fogCoord, col, _FogColor);
				return col;
			}
			ENDCG

		} // end Pass
	} // end Subshader
	FallBack "Diffuse"
}