Shader "WFX/Scroll/Smoke"
{
  Properties
  {
    _TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
    _MainTex ("Texture", 2D) = "white" {}
    _ScrollSpeed ("Scroll Speed", float) = 2
  }
  SubShader
  {
    Tags
    { 
      "IGNOREPROJECTOR" = "true"
      "QUEUE" = "Transparent"
      "RenderType" = "Transparent"
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "IGNOREPROJECTOR" = "true"
        "QUEUE" = "Transparent"
        "RenderType" = "Transparent"
      }
      ZWrite Off
      Cull Off
      Blend DstColor SrcAlpha
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      //uniform float4 _Time;
      uniform float4 _TintColor;
      uniform float _ScrollSpeed;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          out_v.texcoord.xy = in_v.texcoord.xy;
          out_v.color = in_v.color;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float3 u_xlat10_0;
      float3 u_xlat16_1;
      float u_xlat10_2;
      int u_xlatb3;
      float u_xlat5;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.x = (_Time.x * _ScrollSpeed);
          u_xlatb3 = (u_xlat0_d.x>=(-u_xlat0_d.x));
          u_xlat0_d.x = frac(abs(u_xlat0_d.x));
          u_xlat0_d.x = (u_xlatb3)?(u_xlat0_d.x):((-u_xlat0_d.x));
          u_xlat0_d.y = ((-u_xlat0_d.x) + in_f.texcoord.y);
          u_xlat0_d.x = in_f.texcoord.x;
          u_xlat10_0.xyz = tex2D(_MainTex, u_xlat0_d.xy).xyz;
          u_xlat16_1.xyz = (in_f.color.xyz * _TintColor.xyz);
          u_xlat0_d.xyz = ((u_xlat10_0.xyz * u_xlat16_1.xyz) + float3(-0.5, (-0.5), (-0.5)));
          u_xlat10_2 = tex2D(_MainTex, in_f.texcoord.xy).w;
          u_xlat5 = (u_xlat10_2 * in_f.color.w);
          u_xlat0_d.w = ((u_xlat10_2 * in_f.color.w) + (-0.5));
          u_xlat0_d = ((float4(u_xlat5, u_xlat5, u_xlat5, u_xlat5) * u_xlat0_d) + float4(0.5, 0.5, 0.5, 0.5));
          out_f.color = u_xlat0_d;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
