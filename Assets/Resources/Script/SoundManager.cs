using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {
	static GameObject source;
	static Dictionary<string,AudioSource> sounds;

	void Start(){
		source = gameObject;
		sounds = new Dictionary<string,AudioSource>();
	}
	public static void play(string name, float volume=1f, float pitch=1f){
		AudioSource sound;
		if (sounds.TryGetValue (name, out sound))
			sound.Play ();
		else {
			AudioClip clip = Resources.Load<AudioClip> ("Sound/" + name);
			if(clip){
				sound = source.AddComponent<AudioSource> ();
				sound.clip = clip;
				sound.volume = volume;
				sound.pitch = pitch;
				sound.Play ();
				sounds.Add (name,sound);
			}
			else Debug.Log("Unknown sound: "+name);
		}
	}
}
