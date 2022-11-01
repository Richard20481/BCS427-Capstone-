Shader "Unlit/NewUnlitShader"{

    /**
     * 
     */
    Properties{
        _Color("Colour", Color) = (1,1,1,1)
    }

    SubShader{

        Pass{

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"    //From Nvidia?

            /**
            * 
            */
            struct appdata{

                float4 vertex : POSITION;
            };

            /**
            * 
            */
            struct v2f{

                float4 vertex : POSITION;
                fixed4 vertexColors : COLOR;
            };

           /**
            * Vertex Shader part.
            */
            v2f vert (appdata v){

                v2f o;  //O is sceen space.
                o.vertex = UnityObjectToClipPos(v.vertex);  //V is world space!

                //Basic vertex transfrom.
                //o.vertex.y += 0.0f;

                //Sets the colors...
                o.vertexColors = fixed4(0.0f, v.vertex.z/1.0f * 2.0f, 0.0f, 1.0f);    //Sets color..

                return o;
            }

            /**
            * Fragment Shader part.
            */
            fixed4 _Color;

            fixed4 frag (v2f i) : SV_Target{
      
                //return _Color * (1, 0, 0, 1);
                return fixed4(i.vertexColors.rgb, 1.0f);
            }
            ENDCG
        }
    }
}
