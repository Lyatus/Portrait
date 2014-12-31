using UnityEngine;
using System.Collections;

public class TextObject : ActivatableObject {
	public string[] texts;
	public override void activate(){
		GUI gui = GameObject.Find ("GUI").GetComponent<GUI> (); // Get GUI component
		if(gui && gui.isFree ()) // If it exists and it's not busy
			foreach (string text in texts) // For each text we have to render
				gui.showText (text); // Add it to the queue
	}
}
