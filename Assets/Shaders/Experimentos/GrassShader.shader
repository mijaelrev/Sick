Shader "Unlit/GrassShader"
{
    Properties
    {
        _MainTex ("Grass Texture", 2D) = "white" {}
        _Heing ("Heingt", Float) = 1.0
        _Base ("Base", Float) = 1.0
        _Tint ("Tint", Color) = (0.5, 0.5, 0.5, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline" }
        LOD 100

        Pass
        {
            Name "Geometry Pass"
            Tags {"LightMode" = "UniversalForward"}

            ZWrite On
            Cull Off

            HLSLPROGRAM
            



            ENDHLSL
        }
    }
}
