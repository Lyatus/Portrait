using UnityEngine;
using System.Collections;

public class DisplayInformations : MonoBehaviour {

	public string[] description;
	
	private int textFrame = 0;
	private string button = "Fire1"; 
	private bool isDisplayed = false;

	private GameObject texte,texture;



	private  string[] words;
	private  ArrayList wordsList;
	private  string result = "";
	private  Rect TextSize;
	private int numberOfLines = 1;
	public int lineLength = 20; // Maximum width in pixels before it'll wrap


	void Start () {
		 texte =  GameObject.Find("Text");
		 texture = GameObject.Find("TextWindow");
	}
	
	void Update () {}

	public void showInformation(){	
		if (isDisplayed == false) {
						texte.guiText.enabled = true;
						texture.guiTexture.enabled = true;
						Time.timeScale = 0;
						isDisplayed = true;
						StartCoroutine (WaitForKeyPress ());
				}
	}

	public IEnumerator WaitForKeyPress()
	{
		while(isDisplayed)
		{
			if(Input.GetButtonDown(button))
			{
				if(textFrame > description.Length-1){
					isDisplayed = false;	
					break;
				}
				texte.guiText.text =  description[textFrame];   
				FormatString(texte.guiText.text);
				textFrame++;
			}
			yield return 0;
		}
		texte.guiText.enabled = false;
		texture.guiTexture.enabled = false;
		textFrame = 0;
		Time.timeScale = 1;
	}

	void FormatString (  string text) {
		
		words = text.Split(" "[0]); //Split the string into seperate words
		result = "";
		
		for( var index = 0; index < words.Length; index++) {
			
			string word = words[index].Trim();
			
			if (index == 0) {
				result = words[0];
				texte.guiText.text = result;
			}
			
			if (index > 0 ) {
				
				result += " " + word;
				
				texte.guiText.text = result;
			}
			
			TextSize = texte.guiText.GetScreenRect();
			
			if (TextSize.width > lineLength)
			{
				//remover
				result = result.Substring(0,result.Length-(word.Length));
				
				result += "\n" + word;
				numberOfLines += 1;
				texte.guiText.text = result;
			}
		}
	}
}