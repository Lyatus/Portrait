using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUI : MonoBehaviour {
	private bool displaying = false;
	private bool free = true;
	private Queue<string> texts;
	private new GUIText guiText;
	private new GUITexture guiTexture;
	public int lineLength = 20; // Maximum width in pixels before it'll wrap

	void Start(){
		texts = new Queue<string> ();
		guiText = GameObject.Find ("Text").GetComponent<GUIText> ();
		guiTexture = GameObject.Find ("Text Box").GetComponent<GUITexture> ();
		guiText.enabled = false; // Hide text
		guiTexture.enabled = false; // Hide borders
	}
	void Update(){
		if (!displaying) {
			free = true;
		}
		if (Input.GetMouseButtonDown (0)) { // Mouse clicked

			guiText.enabled = false; // Hide text
			guiTexture.enabled = false; // Hide borders
			Time.timeScale = 1; // Unpause physics
			displaying = false;
		}
		if (!displaying && texts.Count>0) { // There is something to display
			SoundManager.play("dialbox");
			guiText.text = texts.Dequeue(); // Set next text
			FormatString(guiText.text); // Format text (add newlines)
			guiText.enabled = true; // Display text
			guiTexture.enabled = true; // Display borders
			Time.timeScale = 0; // Pause physics
			displaying = true;
			free = false;
		}
	}

	public void showText(string text){	
		texts.Enqueue (text);
	}
	public bool isFree(){
		return free;
	}

	void FormatString (  string text) {
		string[] words;
		string result = "";
		Rect TextSize;
		int numberOfLines = 1;
		words = text.Split(" "[0]); //Split the string into seperate words

		for( var index = 0; index < words.Length; index++) {
			
			string word = words[index].Trim();
			
			if (index == 0) {
				result = words[0];
				guiText.text = result;
			}
			
			if (index > 0 ) {
				
				result += " " + word;
				
				guiText.text = result;
			}
			
			TextSize = guiText.GetScreenRect();
			
			if (TextSize.width > lineLength)
			{
				//remover
				result = result.Substring(0,result.Length-(word.Length));
				
				result += "\n" + word;
				numberOfLines += 1;
				guiText.text = result;
			}
		}
	}
}
