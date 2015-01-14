using UnityEngine;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour {
	static Dictionary<string,AudioSource> musicParts;
	void Start () {
		musicParts = new Dictionary<string,AudioSource>();
		AudioSource[] sounds = gameObject.GetComponents<AudioSource>();
		foreach (AudioSource sound in sounds) {
			//sound.volume = 0;
			musicParts.Add (sound.clip.name, sound);
		}
	}
	public static void makeAppear(string name){
		AudioSource sound;
		if (musicParts.TryGetValue (name, out sound))
			sound.volume = .70f;
		else Debug.Log("Unknown music part "+name);
	}
}
