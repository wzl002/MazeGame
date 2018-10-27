Shader "Custom/FogShader" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {} // 2D texture 
		_Ramp("Ramp Texture", 2D) = "white" {}
		_Tooniness("Tooniness", Range(0.1,20)) = 4
		_Outline("Outline", Range(0,1)) = 0.1

		_Ambient("Ambient", Color) = (1,1,1,1)

		_FogColor("Fog Color", Color) = (1, 0, 0, 0)
		_FogIntensity("Fog Intensity", Range(0, 1)) = 0.1
		_FogStart("Fog Start", float) = 0
		_FogEnd("Fog End", float) = 300
		[Enum(Linear,0,Exponential, 1, Exp2, 2)] _FogMode("Fog Mode", float) = 2

	}
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGINCLUDE
		#include "UnityCG.cginc" 

		sampler2D _MainTex;
		sampler2D _Ramp;

		float4 _MainTex_ST;

		float _Tooniness;
		float _Outline;

		float4 _FogColor;
		float _FogIntensity;
		float _FogStart;
		float _FogEnd;
		float _FogMode;

		float4 LinearFog(float4 pos, float4 col)
		{
			pos.w = 0.0;
			float dist = length(pos);
			//	float dist = pos.z;
			// Linear
			float fogFactor = (_FogEnd - abs(dist)) / (_FogEnd - _FogStart);
			fogFactor = clamp(fogFactor, 0.0, 1.0);

			float3 afterFog = lerp(_FogColor.rgb, col.rgb, fogFactor);

			return float4(afterFog, col.a);
		}

		float4 ExponentialFog(float4 pos, float4 col)
		{
			pos.w = 0.0;
			float dist = length(pos);

			// Exponential
			float fogFactor = exp(-abs(_FogIntensity * dist));
			fogFactor = clamp(fogFactor, 0.0, 1.0);

			float3 afterFog = lerp(_FogColor.rgb, col.rgb, fogFactor);

			return float4(afterFog, col.a);
		}

		float4 Exp2Fog(float4 pos, float4 col)
		{
			pos.w = 0.0;
			float dist = length(pos);
			//			float dist = pos.z;
			float fogFactor = exp(-(_FogIntensity * dist) * (_FogIntensity * dist));
			fogFactor = clamp(fogFactor, 0.0, 1.0);

			float3 afterFog = lerp(_FogColor.rgb, col.rgb, fogFactor);
			return float4(afterFog, col.a);
		}

		float4 ApplyFog(float4 pos, float4 col)
		{
			if (_FogMode == 0)
				return LinearFog(pos, col);
			else if (_FogMode == 1)
				return ExponentialFog(pos, col);
			else if (_FogMode == 2)
				return Exp2Fog(pos, col);
			else return Exp2Fog(pos, col); // default
		}

		ENDCG

		Pass {
			// fog diffuse, only work on sphere, has problem on cube, set outline=0 to close this.
			Name "HALO"
			Tags { "LightMode" = "ForwardBase" }

			Cull Front
			Lighting Off
			ZWrite On

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#pragma multi_compile_fwdbase

			#include "UnityCG.cginc"

			struct a2v
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : POSITION;
				float4 viewSpacePos : TEXCOORD0;
			};

			v2f vert(a2v v)
			{
				v2f o;

				float4 pos = mul(UNITY_MATRIX_MV, v.vertex);
				float3 normal = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				normal.z = -0.5;
				pos = pos + float4(normalize(normal),0) * _Outline;
				o.pos = mul(UNITY_MATRIX_P, pos);

				o.viewSpacePos = mul(UNITY_MATRIX_MV, v.vertex);

				return o;
			}

			float4 frag(v2f i) : COLOR
			{
				return ApplyFog(i.viewSpacePos, float4(0, 0, 0, 0));
			}

			ENDCG
		}

		Pass {
			Name "FOG"
			Tags { "LightMode" = "ForwardBase" }

			Cull Back
			Lighting On

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#pragma multi_compile_fwdbase

			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			#include "UnityShaderVariables.cginc"

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				fixed3 diff : COLOR0;
				fixed3 ambient : COLOR1;
				float4 viewSpacePos : TEXCOORD2;
				LIGHTING_COORDS(3, 4)
			};

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
				//o.ambient = ShadeSH9(half4(worldNormal,1)); // system ambient
				o.ambient = _Ambient.rgb;
				// compute shadows data
				TRANSFER_SHADOW(o);

				o.viewSpacePos = mul(UNITY_MATRIX_MV, v.vertex);

				// pass lighting information to pixel shader
				TRANSFER_VERTEX_TO_FRAGMENT(o);
				return o;
			}

			float4 frag(v2f i) : COLOR
			{
				//Get the color of the pixel from the texture
				float4 c = tex2D(_MainTex, i.uv);
				
				//Merge the colours, limit color amout for cartoony.
				if(_Tooniness !=0) c.rgb = (floor(c.rgb*_Tooniness) / _Tooniness);

				fixed shadow = SHADOW_ATTENUATION(i);
				// darken light's illumination with shadow, keep ambient intact
				fixed3 lighting = i.diff * shadow + i.ambient;
				c.rgb *= lighting;

				return ApplyFog(i.viewSpacePos, c);
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
