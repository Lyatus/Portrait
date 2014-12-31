using UnityEngine;
using System.Collections;

public class SoundObject : ActivatableObject {
	public string soundName;
	public override void activate(){
		SoundManager.play ("Objects/"+soundName);
	}
}
