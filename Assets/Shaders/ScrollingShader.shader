Shader "Custom/Scrolling shader" {
     Properties{
         _MainTint("Diffuse tint", Color) = (1,1,1,1)
         _MainTex("Base (RGB)", 2D) = "white" {}
         _NormalTex("Normap map", 2D) = "bump" {}
         _ScrollXSpeed("X scroll speed", Range(-10, 10)) = 0
         _ScrollYSpeed("Y scroll speed", Range(-10, 10)) = -0.4
     }
     SubShader{
         Tags { "RenderType" = "Opaque" }
         LOD 200

         CGPROGRAM
         // Physically based Standard lighting model, and enable shadows on all light types
         #pragma surface surf Standard fullforwardshadows

         // Use shader model 3.0 target, to get nicer looking lighting
         #pragma target 3.0

         fixed4 _MainTint;
         fixed _ScrollXSpeed;
         fixed _ScrollYSpeed;
         sampler2D _MainTex;
         sampler2D _NormalTex;

         struct Input {
             float2 uv_MainTex;
             float2 uv_NormalTex;
         };

         void surf(Input IN, inout SurfaceOutputStandard o) {
             fixed offsetX = _ScrollXSpeed * _Time;
             fixed offsetY = _ScrollYSpeed * _Time;
             fixed2 offsetUV = fixed2(offsetX, offsetY);

             fixed2 normalUV = IN.uv_NormalTex + offsetUV;
             fixed2 mainUV = IN.uv_MainTex + offsetUV;

             float4 normalPixel = tex2D(_NormalTex, normalUV);
             float3 n = UnpackNormal(normalPixel);
             float4 c = tex2D(_MainTex, mainUV);

             o.Albedo = c.rgb * _MainTint;
             o.Normal = n.xyz;
             o.Alpha = c.a;
         }
         ENDCG
     }
     FallBack "Diffuse"
 }
