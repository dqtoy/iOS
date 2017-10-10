Shader "Mobile/iPhoneReflection"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "black" {}
		_envTex ("Env", 2D) = "black" { TexGen SphereMap }
		
	}

	SubShader
	{
		Lighting Off

		Pass
		{
			Name "BASE"
			ZWrite On
			Cull Front
			Material {
                Diffuse [_Color]
                Ambient [_Color]
            }
			SetTexture [_MainTex] 
		}

		Pass
		{
			Name "ENV"
			ZWrite on
			Cull Back
			Blend One One

			BindChannels {
				Bind "Vertex", vertex
				Bind "normal", normal
				Bind "texcoord", texcoord // main uses 1st uv
			}
						
			SetTexture [_envTex] {
				combine texture, previous
			}
		}


	}
}

