// Upgrade NOTE: replaced '_LightMatrix0' with 'unity_WorldToLight'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/FlashLightShader" {
	Properties{
	  _FlashColor("Diffuse Material Color", Color) = (1,1,1,1)
	  _FlashSpecColor("Specular Material Color", Color) = (1,1,1,1)
	  _Shininess("Shininess", Float) = 10
	}

		SubShader{

		Pass {
			Tags { "LightMode" = "ForwardAdd" }

			Name "FLASHLIGHT"
			Blend One One // additive blending 

			CGPROGRAM

			// #pragma multi_compile_lightpass

			#pragma vertex vert  
			#pragma fragment frag 

			#include "UnityCG.cginc"
			float4 _LightColor0;
			float4x4 unity_WorldToLight; // transformation 

		   sampler2D _LightTexture0;

		   // User-specified properties
		    float4 _FlashColor;
		    float4 _FlashSpecColor;
		    float _Shininess;

		   struct vertexOutput {
			  float4 pos : SV_POSITION;
			  float4 posWorld : TEXCOORD0;
			  float4 posLight : TEXCOORD1;
			  float3 normalDir : TEXCOORD2;
		   };

		   vertexOutput vert(appdata_base input)
		   {
			  vertexOutput output;

			  float4x4 modelMatrix = unity_ObjectToWorld;
			  float4x4 modelMatrixInverse = unity_WorldToObject;

			  output.posWorld = mul(modelMatrix, input.vertex);
			  output.posLight = mul(unity_WorldToLight, output.posWorld);
			  output.normalDir = normalize(
				 mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
			  output.pos = UnityObjectToClipPos(input.vertex);
			  return output;
		   }

		   fixed4 frag(vertexOutput input) : SV_Target
		   {
			  float3 normalDirection = normalize(input.normalDir);

			  float3 viewDirection = normalize(_WorldSpaceCameraPos - input.posWorld.xyz);
			  float3 lightDirection;
			  float attenuation = 1.0;

			  float3 vertexToLightSource = _WorldSpaceLightPos0.xyz - input.posWorld.xyz;
			  float distance = length(vertexToLightSource);
			  attenuation = 1.0 / distance;
			  lightDirection = normalize(vertexToLightSource);

			   float3 diffuseReflection = attenuation * _LightColor0.rgb * _FlashColor.rgb * max(0.0, dot(normalDirection, lightDirection));

			   float3 specularReflection;
			   if (dot(normalDirection, lightDirection) < 0.0)
				{
				   specularReflection = float3(0.0, 0.0, 0.0);
			   }
			   else
			   {
				  specularReflection = attenuation * _LightColor0.rgb  * _FlashSpecColor.rgb * pow(max(0.0, dot(reflect(-lightDirection, normalDirection), viewDirection)), _Shininess);
			   }

			   float cookieAttenuation = tex2D(_LightTexture0, input.posLight.xy / input.posLight.w + float2(0.5, 0.5)).a;

			   return fixed4(cookieAttenuation * (diffuseReflection + specularReflection), 1.0);
		   }

		   ENDCG
		   }
	}
		FallBack "Diffuse"
}
