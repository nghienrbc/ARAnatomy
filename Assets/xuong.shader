// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:3,spmd:1,trmd:1,grmd:0,uamb:False,mssp:False,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,imps:False,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:True,dith:3,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:35570,y:31946,varname:node_2865,prsc:2|diff-84-OUT,spec-2170-OUT,gloss-5441-OUT,normal-153-OUT,emission-6586-OUT,transm-2467-OUT,lwrap-2467-OUT,alpha-7654-OUT,refract-2428-OUT,olwid-5049-OUT,olcol-3240-RGB;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32386,y:33190,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Power,id:2916,x:33232,y:31867,varname:node_2916,prsc:2|VAL-7953-RGB,EXP-7216-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7216,x:33031,y:31948,ptovrint:False,ptlb:Pow,ptin:_Pow,varname:node_7216,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Slider,id:4564,x:32651,y:32642,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4,max:1;n:type:ShaderForge.SFN_Lerp,id:5441,x:33164,y:32317,varname:node_5441,prsc:2|A-1036-OUT,B-6408-OUT,T-4564-OUT;n:type:ShaderForge.SFN_Vector1,id:6408,x:32634,y:32518,varname:node_6408,prsc:2,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:2293,x:32400,y:33398,ptovrint:False,ptlb:NormalIntensity,ptin:_NormalIntensity,varname:node_2293,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Append,id:5305,x:32626,y:33327,varname:node_5305,prsc:2|A-2293-OUT,B-2293-OUT;n:type:ShaderForge.SFN_Append,id:153,x:32924,y:33323,varname:node_153,prsc:2|A-3013-OUT,B-2822-OUT;n:type:ShaderForge.SFN_Vector1,id:2822,x:32760,y:33472,varname:node_2822,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:3013,x:32774,y:33187,varname:node_3013,prsc:2|A-4456-OUT,B-5305-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4456,x:32568,y:33177,varname:node_4456,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-5964-RGB;n:type:ShaderForge.SFN_Tex2d,id:7953,x:32829,y:31809,ptovrint:False,ptlb:Maintex,ptin:_Maintex,varname:node_7953,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:2170,x:32718,y:32053,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_2170,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2,max:1;n:type:ShaderForge.SFN_Vector1,id:1036,x:32650,y:32279,varname:node_1036,prsc:2,v1:1;n:type:ShaderForge.SFN_Color,id:146,x:32946,y:31428,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_146,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6244207,c2:1,c3:0.3676471,c4:1;n:type:ShaderForge.SFN_SwitchProperty,id:84,x:33440,y:31801,ptovrint:False,ptlb:On_Off,ptin:_On_Off,varname:node_84,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-6399-OUT,B-2916-OUT;n:type:ShaderForge.SFN_Slider,id:7654,x:33856,y:32309,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_7654,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1225878,max:1;n:type:ShaderForge.SFN_Multiply,id:6399,x:33265,y:31591,varname:node_6399,prsc:2|A-146-RGB,B-7953-RGB;n:type:ShaderForge.SFN_TexCoord,id:2643,x:32161,y:32957,varname:node_2643,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:9556,x:33472,y:32880,ptovrint:False,ptlb:Refraction Intensity,ptin:_RefractionIntensity,varname:_RefractionIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:2428,x:34209,y:32824,varname:node_2428,prsc:2|A-1975-OUT,B-737-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1975,x:33964,y:32706,varname:node_1975,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-2277-OUT;n:type:ShaderForge.SFN_TexCoord,id:9650,x:33443,y:32569,varname:node_9650,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:2277,x:33614,y:32630,varname:node_2277,prsc:2|A-9650-UVOUT,B-6833-OUT;n:type:ShaderForge.SFN_Vector1,id:6833,x:33443,y:32726,varname:node_6833,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2467,x:34208,y:32642,varname:node_2467,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:737,x:34039,y:32867,varname:node_737,prsc:2|A-9556-OUT,B-7421-OUT;n:type:ShaderForge.SFN_Vector1,id:7421,x:33540,y:32960,varname:node_7421,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Slider,id:5049,x:34383,y:33058,ptovrint:False,ptlb:width,ptin:_width,varname:node_8396,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.02,max:1;n:type:ShaderForge.SFN_Fresnel,id:6723,x:33611,y:33068,varname:node_6723,prsc:2|EXP-5184-OUT;n:type:ShaderForge.SFN_Slider,id:5184,x:33227,y:33088,ptovrint:False,ptlb:FresnelEffect,ptin:_FresnelEffect,varname:node_2672,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.801867,max:10;n:type:ShaderForge.SFN_Multiply,id:4590,x:33934,y:33139,varname:node_4590,prsc:2|A-6723-OUT,B-589-RGB;n:type:ShaderForge.SFN_Color,id:589,x:33450,y:33317,ptovrint:False,ptlb:ColorFresnel,ptin:_ColorFresnel,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9705882,c2:0.722,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:3240,x:35022,y:32898,ptovrint:False,ptlb:OutlineColor,ptin:_OutlineColor,varname:node_3240,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9787018,c3:0.6911765,c4:1;n:type:ShaderForge.SFN_Multiply,id:1191,x:34074,y:33289,varname:node_1191,prsc:2|A-4590-OUT,B-5573-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:6586,x:34898,y:32336,ptovrint:False,ptlb:emisive,ptin:_emisive,varname:node_6586,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-1191-OUT,B-1429-OUT;n:type:ShaderForge.SFN_Vector4,id:1429,x:34682,y:32544,varname:node_1429,prsc:2,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector1,id:5573,x:33740,y:33455,varname:node_5573,prsc:2,v1:5;proporder:5964-7216-4564-2293-7953-2170-146-84-7654-5184-589-5049-3240-9556-6586;pass:END;sub:END;*/

Shader "Shader Forge/xuong" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Pow ("Pow", Float ) = 1
        _Gloss ("Gloss", Range(0, 1)) = 0.4
        _NormalIntensity ("NormalIntensity", Float ) = 1
        _Maintex ("Maintex", 2D) = "white" {}
        _Specular ("Specular", Range(0, 1)) = 0.2
        _Color ("Color", Color) = (0.6244207,1,0.3676471,1)
        [MaterialToggle] _On_Off ("On_Off", Float ) = 0
        _Opacity ("Opacity", Range(0, 1)) = 0.1225878
        _FresnelEffect ("FresnelEffect", Range(0, 10)) = 1.801867
        _ColorFresnel ("ColorFresnel", Color) = (0.9705882,0.722,0,1)
        _width ("width", Range(0, 1)) = 0.02
        _OutlineColor ("OutlineColor", Color) = (1,0.9787018,0.6911765,1)
        _RefractionIntensity ("Refraction Intensity", Range(0, 1)) = 0
        [MaterialToggle] _emisive ("emisive", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ "Refraction" }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform float _width;
            uniform float4 _OutlineColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*_width,1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                return fixed4(_OutlineColor.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform sampler2D Refraction;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Pow;
            uniform float _Gloss;
            uniform float _NormalIntensity;
            uniform sampler2D _Maintex; uniform float4 _Maintex_ST;
            uniform float _Specular;
            uniform float4 _Color;
            uniform fixed _On_Off;
            uniform float _Opacity;
            uniform float _RefractionIntensity;
            uniform float _FresnelEffect;
            uniform float4 _ColorFresnel;
            uniform fixed _emisive;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 screenPos : TEXCOORD7;
                LIGHTING_COORDS(8,9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.screenPos = float4( o.pos.xy / o.pos.w, 0, 0 );
                o.screenPos.y *= _ProjectionParams.x;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = float3((_BumpMap_var.rgb.rg*float2(_NormalIntensity,_NormalIntensity)),1.0);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float node_2428 = ((i.uv0*1.0).r*(_RefractionIntensity*0.2));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + float2(node_2428,node_2428);
                float4 sceneColor = tex2D(Refraction, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = lerp(1.0,0.0,_Gloss);
                float perceptualRoughness = 1.0 - lerp(1.0,0.0,_Gloss);
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Specular;
                float specularMonochrome;
                float4 _Maintex_var = tex2D(_Maintex,TRANSFORM_TEX(i.uv0, _Maintex));
                float3 diffuseColor = lerp( (_Color.rgb*_Maintex_var.rgb), pow(_Maintex_var.rgb,_Pow), _On_Off ); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float node_2467 = 1.0;
                float3 w = float3(node_2467,node_2467,node_2467)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(node_2467,node_2467,node_2467);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotLWrap);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((forwardLight+backLight) + ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL)) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = lerp( ((pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelEffect)*_ColorFresnel.rgb)*5.0), float4(0,0,0,0), _emisive ).rgb;
/// Final Color:
                float3 finalColor = diffuse * _Opacity + specular + emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,_Opacity),1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
