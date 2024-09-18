Shader "Unlit/Transparent Packed"
{
  Properties
  {
    _MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
  }
  SubShader
  {
    Tags
    { 
      "DisableBatching" = "true"
      "IGNOREPROJECTOR" = "true"
      "QUEUE" = "Transparent"
      "RenderType" = "Transparent"
    }
    LOD 200
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "DisableBatching" = "true"
        "IGNOREPROJECTOR" = "true"
        "QUEUE" = "Transparent"
        "RenderType" = "Transparent"
      }
      LOD 200
      ZWrite Off
      Cull Off
      Offset -1, -1
      Fog
      { 
        Mode  Off
      } 
      Blend SrcAlpha OneMinusSrcAlpha
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float4 color :COLOR0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float4 color :COLOR0;
          float2 texcoord :TEXCOORD0;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float4 color :COLOR0;
          float2 texcoord :TEXCOORD0;
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
          out_v.color = in_v.color;
          out_v.texcoord.xy = in_v.texcoord.xy;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat16_0;
      float4 u_xlat10_1;
      float2 u_xlat16_2;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat16_0 = (in_f.color + float4(-0.5, (-0.5), (-0.5), (-0.5)));
          u_xlat16_0 = ceil(u_xlat16_0);
          u_xlat16_0 = clamp(u_xlat16_0, 0, 1);
          u_xlat10_1 = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat16_2.xy = (u_xlat16_0.xy * u_xlat10_1.xy);
          u_xlat16_2.x = (u_xlat16_2.y + u_xlat16_2.x);
          u_xlat16_2.x = ((u_xlat10_1.z * u_xlat16_0.z) + u_xlat16_2.x);
          u_xlat16_2.x = ((u_xlat10_1.w * u_xlat16_0.w) + u_xlat16_2.x);
          u_xlat16_0 = ((u_xlat16_0 * float4(0.50999999, 0.50999999, 0.50999999, 0.50999999)) + (-in_f.color));
          u_xlat16_0 = (u_xlat16_0 * float4(-2.04081631, (-2.04081631), (-2.04081631), (-2.04081631)));
          u_xlat16_0 = clamp(u_xlat16_0, 0, 1);
          out_f.color.w = (u_xlat16_2.x * u_xlat16_0.w);
          out_f.color.xyz = u_xlat16_0.xyz;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
