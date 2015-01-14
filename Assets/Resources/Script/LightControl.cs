using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {
	float intensity;
	// Use this for initialization
	void Start () {
		intensity = gameObject.light.intensity;
		gameObject.light.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.light.intensity != intensity) { // If it hasn't been lit up yet
			Vector3 character = GameObject.Find ("Character").transform.position;
			Vector3 light = gameObject.transform.position;
			character.z = light.z = -1;
			if(Vector3.Distance(character,light) < 4f){
				bool nohit = true;
				RaycastHit[] hits = Physics.RaycastAll (character, light-character, 4f); // Cast a ray between the character and the light
				foreach (RaycastHit hit in hits)
					if(hit.collider.gameObject.name == "Wall"
				    || hit.collider.gameObject.name == "Door") // If it hit something
						nohit = false;
				if(nohit){
					gameObject.light.intensity = intensity; // Light it up
					SoundManager.play("Lamp/Lamp_"+Random.Range(1,6),.25f); // Make lamp switch sound
				}
			}
		}
	}
}
