Shader "SupGames/Mobile/PostProcess"
{
  Properties
  {
    _MainTex ("Base (RGB)", 2D) = "" {}
  }
  SubShader
  {
    Tags
    { 
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      Fog
      { 
        Mode  Off
      } 
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float _BlurAmount;
      uniform float4 _MainTex_TexelSize;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float4 texcoord :TEXCOORD0;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float4 texcoord :TEXCOORD0;
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
          u_xlat0 = UnityObjectToClipPos(in_v.vertex);
          out_v.vertex = u_xlat0;
          out_v.texcoord.xy = (((-_MainTex_TexelSize.xy) * float2(_BlurAmount, _BlurAmount)) + in_v.texcoord.xy);
          out_v.texcoord.zw = ((_MainTex_TexelSize.xy * float2(_BlurAmount, _BlurAmount)) + in_v.texcoord.xy);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xw);
          u_xlat0_d = (u_xlat0_d + u_xlat1_d);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.zy);
          u_xlat0_d = (u_xlat0_d + u_xlat1_d);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.zw);
          u_xlat0_d = (u_xlat0_d + u_xlat1_d);
          u_xlat0_d = (u_xlat0_d * float4(0.25, 0.25, 0.25, 0.25));
          out_f.color = u_xlat0_d;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 2, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      Fog
      { 
        Mode  Off
      } 
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float _Offset;
      uniform float4 _MainTex_TexelSize;
      uniform float4 _VignetteColor;
      uniform float _VignetteAmount;
      uniform float _VignetteSoftness;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float4 texcoord :TEXCOORD0;
          float4 texcoord1 :TEXCOORD1;
          float4 texcoord2 :TEXCOORD2;
          float2 texcoord3 :TEXCOORD3;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float4 texcoord :TEXCOORD0;
          float4 texcoord2 :TEXCOORD2;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      float u_xlat16_2;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          u_xlat0 = UnityObjectToClipPos(in_v.vertex);
          out_v.vertex = u_xlat0;
          out_v.texcoord = in_v.texcoord.xyxy;
          out_v.texcoord1.xy = (in_v.texcoord.xy + (-_MainTex_TexelSize.xy));
          out_v.texcoord1.zw = (in_v.texcoord.xy + _MainTex_TexelSize.xy);
          u_xlat16_2 = (((-_Offset) * _MainTex_TexelSize.x) + in_v.texcoord.x);
          u_xlat0.x = (u_xlat16_2 + (-0.5));
          u_xlat16_2 = ((_Offset * _MainTex_TexelSize.x) + in_v.texcoord.x);
          u_xlat0.y = (u_xlat16_2 + (-0.5));
          u_xlat0.zw = (in_v.texcoord.xy + float2(-0.5, (-0.5)));
          out_v.texcoord2 = u_xlat0;
          out_v.texcoord3.xy = u_xlat0.zw;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float u_xlat16_0;
      float4 u_xlat1_d;
      float3 u_xlat16_2_d;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat16_0 = length(in_f.texcoord2.zw);
          u_xlat16_0 = (u_xlat16_0 + (-_VignetteAmount));
          u_xlat16_2_d.x = ((-_VignetteAmount) + _VignetteSoftness);
          u_xlat16_2_d.x = (float(1) / u_xlat16_2_d.x);
          u_xlat16_0 = (u_xlat16_2_d.x * u_xlat16_0);
          u_xlat16_0 = clamp(u_xlat16_0, 0, 1);
          u_xlat16_2_d.x = ((u_xlat16_0 * (-2)) + 3);
          u_xlat16_0 = (u_xlat16_0 * u_xlat16_0);
          u_xlat16_0 = (u_xlat16_0 * u_xlat16_2_d.x);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat16_2_d.xyz = (u_xlat1_d.xyz + (-_VignetteColor.xyz));
          out_f.color.w = u_xlat1_d.w;
          out_f.color.xyz = ((float3(u_xlat16_0, u_xlat16_0, u_xlat16_0) * u_xlat16_2_d.xyz) + _VignetteColor.xyz);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
