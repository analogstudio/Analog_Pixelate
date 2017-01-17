using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class pixelateImageEffector : MonoBehaviour {

	public float reduction = 1;

	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		//temp RT attributes
		RenderTextureFormat format = RenderTextureFormat.ARGB32;
		int lowresDepthWidth = (int)(source.width/reduction);
		int lowresDepthHeight = (int)(source.height/reduction);

		//make RT
		RenderTexture lowresRT = RenderTexture.GetTemporary (lowresDepthWidth, lowresDepthHeight, 0, format);

		//point sampling for crispness sake
		lowresRT.filterMode = FilterMode.Point;

		//Blit source to lowres RT
		Graphics.Blit (source, lowresRT);
		//Blit lowres to screen
		Graphics.Blit (lowresRT, destination);

		//release lowres RT from memory
		RenderTexture.ReleaseTemporary(lowresRT);
	}
}