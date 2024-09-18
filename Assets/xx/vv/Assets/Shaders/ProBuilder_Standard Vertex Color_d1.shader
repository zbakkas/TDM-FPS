Shader "ProBuilder/Standard Vertex Color"
{
  Properties
  {
    _Color ("Color", Color) = (1,1,1,1)
    _MainTex ("Albedo (RGB)", 2D) = "white" {}
    _Glossiness ("Smoothness", Range(0, 1)) = 0.5
    _Metallic ("Metallic", Range(0, 1)) = 0
  }
  SubShader
  {
    Tags
    { 
      "RenderType" = "Opaque"
    }
    LOD 200
    Pass // ind: 1, name: FORWARD
    {
      Name "FORWARD"
      Tags
      { 
        "LIGHTMODE" = "FORWARDBASE"
        "RenderType" = "Opaque"
        "SHADOWSUPPORT" = "true"
      }
      LOD 200
      // m_ProgramMask = 6
      CGPROGRAM
      #pragma multi_compile DIRECTIONAL
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      #define conv_mxt4x4_0(mat4x4) float4(mat4x4[0].x,mat4x4[1].x,mat4x4[2].x,mat4x4[3].x)
      #define conv_mxt4x4_1(mat4x4) float4(mat4x4[0].y,mat4x4[1].y,mat4x4[2].y,mat4x4[3].y)
      #define conv_mxt4x4_2(mat4x4) float4(mat4x4[0].z,mat4x4[1].z,mat4x4[2].z,mat4x4[3].z)
      #define conv_mxt4x4_3(mat4x4) float4(mat4x4[0].w,mat4x4[1].w,mat4x4[2].w,mat4x4[3].w)
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_WorldToObject;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      //uniform float3 _WorldSpaceCameraPos;
      //uniform float4 _WorldSpaceLightPos0;
      //uniform float4 unity_SpecCube0_HDR;
      uniform float4 _LightColor0;
      uniform float _Glossiness;
      uniform float _Metallic;
      uniform float4 _Color;
      uniform sampler2D _MainTex;
      uniform sampler2D unity_NHxRoughness;
      //uniform samplerCUBE unity_SpecCube0;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float3 normal :NORMAL0;
          float4 texcoord :TEXCOORD0;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float3 texcoord1 :TEXCOORD1;
          float4 texcoord2 :TEXCOORD2;
          float4 color :COLOR0;
          float4 texcoord5 :TEXCOORD5;
          float4 texcoord6 :TEXCOORD6;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float3 texcoord1 :TEXCOORD1;
          float4 texcoord2 :TEXCOORD2;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      float u_xlat6;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          u_xlat0 = (in_v.vertex.yyyy * conv_mxt4x4_1(unity_ObjectToWorld));
          u_xlat0 = ((conv_mxt4x4_0(unity_ObjectToWorld) * in_v.vertex.xxxx) + u_xlat0);
          u_xlat0 = ((conv_mxt4x4_2(unity_ObjectToWorld) * in_v.vertex.zzzz) + u_xlat0);
          u_xlat1 = (u_xlat0 + conv_mxt4x4_3(unity_ObjectToWorld));
          out_v.texcoord2.xyz = ((conv_mxt4x4_3(unity_ObjectToWorld).xyz * in_v.vertex.www) + u_xlat0.xyz);
          out_v.vertex = mul(unity_MatrixVP, u_xlat1);
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          u_xlat0.x = dot(in_v.normal.xyz, conv_mxt4x4_0(unity_WorldToObject).xyz);
          u_xlat0.y = dot(in_v.normal.xyz, conv_mxt4x4_1(unity_WorldToObject).xyz);
          u_xlat0.z = dot(in_v.normal.xyz, conv_mxt4x4_2(unity_WorldToObject).xyz);
          out_v.texcoord1.xyz = normalize(u_xlat0.xyz);
          out_v.texcoord2.w = 0;
          out_v.color = in_v.color;
          out_v.texcoord5 = float4(0, 0, 0, 0);
          out_v.texcoord6 = float4(0, 0, 0, 0);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float3 u_xlat0_d;
      float3 u_xlat16_1;
      float4 u_xlat10_1;
      float3 u_xlat2;
      float3 u_xlat10_2;
      float3 u_xlat16_3;
      float3 u_xlat4;
      float3 u_xlat16_5;
      float3 u_xlat16_6;
      float3 u_xlat16_7;
      float u_xlat8;
      float u_xlat10;
      float u_xlat24;
      float u_xlat16_25;
      float u_xlat16_27;
      float u_xlat16_29;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.xyz = ((-in_f.texcoord2.xyz) + _WorldSpaceCameraPos.xyz);
          u_xlat0_d.xyz = normalize(u_xlat0_d.xyz);
          u_xlat16_1.x = dot((-u_xlat0_d.xyz), in_f.texcoord1.xyz);
          u_xlat16_1.x = (u_xlat16_1.x + u_xlat16_1.x);
          u_xlat16_1.xyz = ((in_f.texcoord1.xyz * (-u_xlat16_1.xxx)) + (-u_xlat0_d.xyz));
          u_xlat2.z = ((-_Glossiness) + 1);
          u_xlat16_25 = (((-u_xlat2.z) * 0.699999988) + 1.70000005);
          u_xlat16_25 = (u_xlat16_25 * u_xlat2.z);
          u_xlat16_25 = (u_xlat16_25 * 6);
          u_xlat10_1 = texCUBE(unity_SpecCube0, u_xlat16_1.xyz, u_xlat16_25);
          u_xlat16_3.x = (u_xlat10_1.w + (-1));
          u_xlat16_3.x = ((unity_SpecCube0_HDR.w * u_xlat16_3.x) + 1);
          u_xlat16_3.x = (u_xlat16_3.x * unity_SpecCube0_HDR.x);
          u_xlat16_3.xyz = (u_xlat10_1.xyz * u_xlat16_3.xxx);
          u_xlat4.xyz = normalize(in_f.texcoord1.xyz);
          u_xlat24 = dot(u_xlat0_d.xyz, u_xlat4.xyz);
          u_xlat10 = u_xlat24;
          u_xlat10 = clamp(u_xlat10, 0, 1);
          u_xlat24 = (u_xlat24 + u_xlat24);
          u_xlat0_d.xyz = ((u_xlat4.xyz * (-float3(u_xlat24, u_xlat24, u_xlat24))) + u_xlat0_d.xyz);
          u_xlat24 = dot(u_xlat4.xyz, _WorldSpaceLightPos0.xyz);
          u_xlat24 = clamp(u_xlat24, 0, 1);
          u_xlat16_5.xyz = (float3(u_xlat24, u_xlat24, u_xlat24) * _LightColor0.xyz);
          u_xlat0_d.x = dot(u_xlat0_d.xyz, _WorldSpaceLightPos0.xyz);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat2.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = tex2D(unity_NHxRoughness, u_xlat2.xz).x;
          u_xlat0_d.x = (u_xlat0_d.x * 16);
          u_xlat16_27 = ((-u_xlat10) + 1);
          u_xlat8 = (u_xlat16_27 * u_xlat16_27);
          u_xlat8 = (u_xlat16_27 * u_xlat8);
          u_xlat8 = (u_xlat16_27 * u_xlat8);
          u_xlat16_27 = (((-_Metallic) * 0.779083729) + 0.779083729);
          u_xlat16_29 = ((-u_xlat16_27) + _Glossiness);
          u_xlat16_29 = (u_xlat16_29 + 1);
          u_xlat16_29 = clamp(u_xlat16_29, 0, 1);
          u_xlat10_2.xyz = tex2D(_MainTex, in_f.texcoord.xy).xyz;
          u_xlat2.xyz = (u_xlat10_2.xyz * _Color.xyz);
          u_xlat16_6.xyz = ((u_xlat2.xyz * in_f.color.xyz) + float3(-0.220916301, (-0.220916301), (-0.220916301)));
          u_xlat2.xyz = (u_xlat2.xyz * in_f.color.xyz);
          u_xlat16_6.xyz = ((float3(float3(_Metallic, _Metallic, _Metallic)) * u_xlat16_6.xyz) + float3(0.220916301, 0.220916301, 0.220916301));
          u_xlat16_7.xyz = (float3(u_xlat16_29, u_xlat16_29, u_xlat16_29) + (-u_xlat16_6.xyz));
          u_xlat16_7.xyz = ((float3(u_xlat8, u_xlat8, u_xlat8) * u_xlat16_7.xyz) + u_xlat16_6.xyz);
          u_xlat16_6.xyz = (u_xlat0_d.xxx * u_xlat16_6.xyz);
          u_xlat16_6.xyz = ((u_xlat2.xyz * float3(u_xlat16_27, u_xlat16_27, u_xlat16_27)) + u_xlat16_6.xyz);
          u_xlat16_3.xyz = (u_xlat16_3.xyz * u_xlat16_7.xyz);
          out_f.color.xyz = ((u_xlat16_6.xyz * u_xlat16_5.xyz) + u_xlat16_3.xyz);
          out_f.color.w = 1;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 2, name: FORWARD
    {
      Name "FORWARD"
      Tags
      { 
        "LIGHTMODE" = "FORWARDADD"
        "RenderType" = "Opaque"
        "SHADOWSUPPORT" = "true"
      }
      LOD 200
      ZWrite Off
      Blend One One
      // m_ProgramMask = 6
      CGPROGRAM
      #pragma multi_compile POINT
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      #define conv_mxt4x4_0(mat4x4) float4(mat4x4[0].x,mat4x4[1].x,mat4x4[2].x,mat4x4[3].x)
      #define conv_mxt4x4_1(mat4x4) float4(mat4x4[0].y,mat4x4[1].y,mat4x4[2].y,mat4x4[3].y)
      #define conv_mxt4x4_2(mat4x4) float4(mat4x4[0].z,mat4x4[1].z,mat4x4[2].z,mat4x4[3].z)
      #define conv_mxt4x4_3(mat4x4) float4(mat4x4[0].w,mat4x4[1].w,mat4x4[2].w,mat4x4[3].w)
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_WorldToObject;
      //uniform float4x4 unity_MatrixVP;
      uniform float4x4 unity_WorldToLight;
      uniform float4 _MainTex_ST;
      //uniform float3 _WorldSpaceCameraPos;
      //uniform float4 _WorldSpaceLightPos0;
      uniform float4 _LightColor0;
      uniform float _Glossiness;
      uniform float _Metallic;
      uniform float4 _Color;
      uniform sampler2D _MainTex;
      uniform sampler2D _LightTexture0;
      uniform sampler2D unity_NHxRoughness;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float3 normal :NORMAL0;
          float4 texcoord :TEXCOORD0;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float3 texcoord1 :TEXCOORD1;
          float3 texcoord2 :TEXCOORD2;
          float4 color :COLOR0;
          float3 texcoord3 :TEXCOORD3;
          float4 texcoord4 :TEXCOORD4;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float3 texcoord1 :TEXCOORD1;
          float3 texcoord2 :TEXCOORD2;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      float4 u_xlat2;
      float u_xlat10;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          u_xlat1 = mul(unity_ObjectToWorld, float4(in_v.vertex.xyz,1.0));
          out_v.vertex = mul(unity_MatrixVP, u_xlat1);
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          u_xlat1.x = dot(in_v.normal.xyz, conv_mxt4x4_0(unity_WorldToObject).xyz);
          u_xlat1.y = dot(in_v.normal.xyz, conv_mxt4x4_1(unity_WorldToObject).xyz);
          u_xlat1.z = dot(in_v.normal.xyz, conv_mxt4x4_2(unity_WorldToObject).xyz);
          out_v.texcoord1.xyz = normalize(u_xlat1.xyz);
          out_v.texcoord2.xyz = ((conv_mxt4x4_3(unity_ObjectToWorld).xyz * in_v.vertex.www) + u_xlat0.xyz);
          u_xlat0 = ((conv_mxt4x4_3(unity_ObjectToWorld) * in_v.vertex.wwww) + u_xlat0);
          out_v.color = in_v.color;
          u_xlat1.xyz = (u_xlat0.yyy * conv_mxt4x4_1(unity_WorldToLight).xyz);
          u_xlat1.xyz = ((conv_mxt4x4_0(unity_WorldToLight).xyz * u_xlat0.xxx) + u_xlat1.xyz);
          u_xlat0.xyz = ((conv_mxt4x4_2(unity_WorldToLight).xyz * u_xlat0.zzz) + u_xlat1.xyz);
          out_v.texcoord3.xyz = ((conv_mxt4x4_3(unity_WorldToLight).xyz * u_xlat0.www) + u_xlat0.xyz);
          out_v.texcoord4 = float4(0, 0, 0, 0);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float3 u_xlat1_d;
      float3 u_xlat10_1;
      float3 u_xlat2_d;
      float3 u_xlat16_3;
      float3 u_xlat16_4;
      float u_xlat5;
      float u_xlat15;
      float u_xlat16_18;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.xyz = ((-in_f.texcoord2.xyz) + _WorldSpaceCameraPos.xyz);
          u_xlat0_d.xyz = normalize(u_xlat0_d.xyz);
          u_xlat1_d.xyz = normalize(in_f.texcoord1.xyz);
          u_xlat15 = dot(u_xlat0_d.xyz, u_xlat1_d.xyz);
          u_xlat15 = (u_xlat15 + u_xlat15);
          u_xlat0_d.xyz = ((u_xlat1_d.xyz * (-float3(u_xlat15, u_xlat15, u_xlat15))) + u_xlat0_d.xyz);
          u_xlat2_d.xyz = ((-in_f.texcoord2.xyz) + _WorldSpaceLightPos0.xyz);
          u_xlat2_d.xyz = normalize(u_xlat2_d.xyz);
          u_xlat0_d.x = dot(u_xlat0_d.xyz, u_xlat2_d.xyz);
          u_xlat5 = dot(u_xlat1_d.xyz, u_xlat2_d.xyz);
          u_xlat5 = clamp(u_xlat5, 0, 1);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat1_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat1_d.y = ((-_Glossiness) + 1);
          u_xlat0_d.x = tex2D(unity_NHxRoughness, u_xlat1_d.xy).x;
          u_xlat0_d.x = (u_xlat0_d.x * 16);
          u_xlat10_1.xyz = tex2D(_MainTex, in_f.texcoord.xy).xyz;
          u_xlat1_d.xyz = (u_xlat10_1.xyz * _Color.xyz);
          u_xlat16_3.xyz = ((u_xlat1_d.xyz * in_f.color.xyz) + float3(-0.220916301, (-0.220916301), (-0.220916301)));
          u_xlat1_d.xyz = (u_xlat1_d.xyz * in_f.color.xyz);
          u_xlat16_3.xyz = ((float3(float3(_Metallic, _Metallic, _Metallic)) * u_xlat16_3.xyz) + float3(0.220916301, 0.220916301, 0.220916301));
          u_xlat16_3.xyz = (u_xlat0_d.xxx * u_xlat16_3.xyz);
          u_xlat16_18 = (((-_Metallic) * 0.779083729) + 0.779083729);
          u_xlat16_3.xyz = ((u_xlat1_d.xyz * float3(u_xlat16_18, u_xlat16_18, u_xlat16_18)) + u_xlat16_3.xyz);
          u_xlat0_d.xzw = (in_f.texcoord2.yyy * conv_mxt4x4_1(unity_WorldToLight).xyz);
          u_xlat0_d.xzw = ((conv_mxt4x4_0(unity_WorldToLight).xyz * in_f.texcoord2.xxx) + u_xlat0_d.xzw);
          u_xlat0_d.xzw = ((conv_mxt4x4_2(unity_WorldToLight).xyz * in_f.texcoord2.zzz) + u_xlat0_d.xzw);
          u_xlat0_d.xzw = (u_xlat0_d.xzw + conv_mxt4x4_3(unity_WorldToLight).xyz);
          u_xlat0_d.x = dot(u_xlat0_d.xzw, u_xlat0_d.xzw);
          u_xlat0_d.x = tex2D(_LightTexture0, u_xlat0_d.xx).x;
          u_xlat16_4.xyz = (u_xlat0_d.xxx * _LightColor0.xyz);
          u_xlat16_4.xyz = (float3(u_xlat5, u_xlat5, u_xlat5) * u_xlat16_4.xyz);
          out_f.color.xyz = (u_xlat16_3.xyz * u_xlat16_4.xyz);
          out_f.color.w = 1;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 3, name: DEFERRED
    {
      Name "DEFERRED"
      Tags
      { 
        "LIGHTMODE" = "DEFERRED"
        "RenderType" = "Opaque"
      }
      LOD 200
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      #define conv_mxt4x4_0(mat4x4) float4(mat4x4[0].x,mat4x4[1].x,mat4x4[2].x,mat4x4[3].x)
      #define conv_mxt4x4_1(mat4x4) float4(mat4x4[0].y,mat4x4[1].y,mat4x4[2].y,mat4x4[3].y)
      #define conv_mxt4x4_2(mat4x4) float4(mat4x4[0].z,mat4x4[1].z,mat4x4[2].z,mat4x4[3].z)
      #define conv_mxt4x4_3(mat4x4) float4(mat4x4[0].w,mat4x4[1].w,mat4x4[2].w,mat4x4[3].w)
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_WorldToObject;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      uniform float _Glossiness;
      uniform float _Metallic;
      uniform float4 _Color;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float3 normal :NORMAL0;
          float4 texcoord :TEXCOORD0;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float3 texcoord1 :TEXCOORD1;
          float3 texcoord2 :TEXCOORD2;
          float4 color :COLOR0;
          float4 texcoord4 :TEXCOORD4;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float3 texcoord1 :TEXCOORD1;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
          float4 color1 :SV_Target1;
          float4 color2 :SV_Target2;
          float4 color3 :SV_Target3;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      float u_xlat6;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          u_xlat0 = (in_v.vertex.yyyy * conv_mxt4x4_1(unity_ObjectToWorld));
          u_xlat0 = ((conv_mxt4x4_0(unity_ObjectToWorld) * in_v.vertex.xxxx) + u_xlat0);
          u_xlat0 = ((conv_mxt4x4_2(unity_ObjectToWorld) * in_v.vertex.zzzz) + u_xlat0);
          u_xlat1 = (u_xlat0 + conv_mxt4x4_3(unity_ObjectToWorld));
          out_v.texcoord2.xyz = ((conv_mxt4x4_3(unity_ObjectToWorld).xyz * in_v.vertex.www) + u_xlat0.xyz);
          out_v.vertex = mul(unity_MatrixVP, u_xlat1);
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          u_xlat0.x = dot(in_v.normal.xyz, conv_mxt4x4_0(unity_WorldToObject).xyz);
          u_xlat0.y = dot(in_v.normal.xyz, conv_mxt4x4_1(unity_WorldToObject).xyz);
          u_xlat0.z = dot(in_v.normal.xyz, conv_mxt4x4_2(unity_WorldToObject).xyz);
          out_v.texcoord1.xyz = normalize(u_xlat0.xyz);
          out_v.color = in_v.color;
          out_v.texcoord4 = float4(0, 0, 0, 0);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float3 u_xlat10_0;
      float3 u_xlat1_d;
      float3 u_xlat16_2;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat10_0.xyz = tex2D(_MainTex, in_f.texcoord.xy).xyz;
          u_xlat0_d.xyz = (u_xlat10_0.xyz * _Color.xyz);
          u_xlat1_d.xyz = (u_xlat0_d.xyz * in_f.color.xyz);
          u_xlat16_2.xyz = ((u_xlat0_d.xyz * in_f.color.xyz) + float3(-0.220916301, (-0.220916301), (-0.220916301)));
          out_f.color1.xyz = ((float3(float3(_Metallic, _Metallic, _Metallic)) * u_xlat16_2.xyz) + float3(0.220916301, 0.220916301, 0.220916301));
          u_xlat16_2.x = (((-_Metallic) * 0.779083729) + 0.779083729);
          out_f.color.xyz = (u_xlat1_d.xyz * u_xlat16_2.xxx);
          out_f.color.w = 1;
          out_f.color1.w = _Glossiness;
          u_xlat0_d.xyz = ((in_f.texcoord1.xyz * float3(0.5, 0.5, 0.5)) + float3(0.5, 0.5, 0.5));
          u_xlat0_d.w = 1;
          out_f.color2 = u_xlat0_d;
          out_f.color3 = float4(1, 1, 1, 1);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack "Standard"
}
