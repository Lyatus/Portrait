using UnityEngine;
using System.Collections;

public class SpriteObject : ActivatableObject {
	public Sprite sprite;
	public override void activate(){
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		if (sr)
			sr.sprite = sprite;
		else
			Debug.Log ("A sprite object needs a sprite renderer");
	}
}
