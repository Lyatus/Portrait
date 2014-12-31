using UnityEngine;
using System.Collections;

public class DoorSounds : MonoBehaviour {
	public float threshold = 10f;
	bool closed = true;

	void Update () {
		if (closed) {
			if (Mathf.Abs (hingeJoint.angle) > threshold) {
				closed = false;
				SoundManager.play("Door/DOOR_Bedroom_06"); // Play opening sound
				SoundManager.play ("Wind/WIND_Winter_02",2f);
			}
		} else {
			if(Mathf.Abs(hingeJoint.angle) < threshold){
				closed = true;
				SoundManager.play("Door/DOOR_Bedroom_13"); // Play closing sound
			}
		}
	}
}
