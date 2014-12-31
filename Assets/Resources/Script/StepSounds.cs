using UnityEngine;
using System.Collections;

public class StepSounds : MonoBehaviour {
	public float stepDistance = 1f; // Distance between two steps
	float traveledDistance = 0f;
	
	void Update () {
		traveledDistance += rigidbody.velocity.magnitude * Time.deltaTime;
		if (traveledDistance > stepDistance) {
			traveledDistance -= stepDistance;
			SoundManager.play("Footsteps/Footsteps1_"+Random.Range(1,25));
		}
	}
}
