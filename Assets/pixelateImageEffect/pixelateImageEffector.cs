

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class pixelateImageEffector : MonoBehaviour {

	public float Size;
	private Material material;


	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/pixelate"));
		material.SetVector ("_CellSize",new Vector4(Size,Size,0,0));
	}

	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit (source, destination, material);
	}
}