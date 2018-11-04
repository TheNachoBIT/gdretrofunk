using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/Color Adjustments/GrayscaleWithFade")]
	public class GrayscaleWithFade : ImageEffectBase {
		public Texture  textureRamp;
		public float    rampOffset;
		public float effectAmount = 1;
		
		// Called by camera to apply image effect
		void OnRenderImage (RenderTexture source, RenderTexture destination) {
			material.SetTexture("_RampTex", textureRamp);
			material.SetFloat("_RampOffset", rampOffset);
			material.SetFloat("_EffectAmount", effectAmount);
			Graphics.Blit (source, destination, material);
		}
	}
}
