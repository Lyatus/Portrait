using UnityEngine;
using System.Collections;

public abstract class ActivatableObject : MonoBehaviour {
	Material material;
	Shader originalShader;
	Shader highlightShader;
	int count = 0; // Serves for countdown

	public abstract void activate();
	void Start(){
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		if (sr) material = sr.material;
		MeshRenderer mr = gameObject.GetComponent<MeshRenderer> ();
		if (mr) material = mr.material;
		originalShader = material.shader;
		highlightShader = Shader.Find ("Transparent/Cutout/Specular");
	}
	public void highlight(){
		material.shader = highlightShader;
		material.SetFloat("_Shininess", 0f);
		material.SetColor("_SpecColor", new Color(.06f,.05f,.05f));
		count = 5; // Set countdown to keep the highlight shader
	}
	void Update(){
		if (count == 0)
			material.shader = originalShader;
		else count--;
	}
}
