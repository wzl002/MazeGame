Shader "Custom/WallShader"
{
	Properties{
		_MainTex("Albedo", 2D) = "white" {}

		_FogColor("Fog Color", Color) = (1, 0, 0, 0)
		_FogIntensity("Fog Intensity", Range(0, 1)) = 0.18
		_FogStart("Fog Start", float) = 0
		_FogEnd("Fog End", float) = 300
		[Enum(Linear,0,Exponential, 1, Exp2, 2)] _FogMode("Fog Mode", Float) = 2

		_Ambient("Ambient", Color) = (1,1,1,1)

		//Flashlight
		_FlashColor("Flash Color", Color) = (1,1,1,1)
		[HideInInspector]_FlashSpecColor("Flash Specular Color", Color) = (1,1,1,1)
		[HideInInspector]_Shininess("Shininess", Float) = 10

		// Fog
		[HideInInspector]_Ramp("Ramp Texture", 2D) = "white" {}
		[HideInInspector]_Tooniness("Tooniness", Range(0.1,20)) = 0 // disable Tooniness

	}
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 100
			
		//	UsePass "Standard/FORWARD"
		//UsePass "Custom/LightShadowShader/LIGHT"

		//	UsePass "Standard/SHADOWCASTER"
		UsePass "Custom/LightShadowShader/SHADOWCASTER"
		
		// Fog shader contains light forward
		UsePass "Custom/FogShader/FOG"
		//UsePass "Custom/SystemFogShader/FOG"
			UsePass "Custom/FlashLightShader/FLASHLIGHT"
	}
	// FallBack "Diffuse" //  if no SubShaders from the current shader can run
}
