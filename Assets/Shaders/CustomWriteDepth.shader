Shader "Custom/WriteDepth"{

  SubShader{
    Tags{ "RenderType" = "Opaque" "Queue" = "Geometry-1"}

	Pass{
	  ZWrite On
	  ZTest LEqual
	  Offset -1, -1

	  CGPROGRAM
	  #include "UnityCG.cginc"

	  #pragma vertex vert
	  #pragma fragment frag

	  struct appdata {
		float4 vertex : POSITION;
		UNITY_VERTEX_INPUT_INSTANCE_ID    // For SPIR
	  };

	  struct v2f {
		float4 position : SV_POSITION;
		UNITY_VERTEX_OUTPUT_STEREO        // For SPIR
	  };

	  v2f vert(appdata v) {
		v2f o;

		UNITY_SETUP_INSTANCE_ID(v);        // For SPIR
		UNITY_INITIALIZE_OUTPUT(v2f, o);      // For SPIR
		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);    // For SPIR

		o.position = UnityObjectToClipPos(v.vertex);
		return o;
	  }

	  fixed4 frag(v2f i) : SV_TARGET{
		return 0;
	  }

	  ENDCG
	}
  }
}
