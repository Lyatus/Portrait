using UnityEngine;
using System.Collections;

public class FaceForward : MonoBehaviour {
	public float speed;
	void Update () {
		Vector2 velocity = gameObject.rigidbody.velocity;
		if (velocity.magnitude > .5f) { // If not idle
			Quaternion targetRotation = Quaternion.AngleAxis(-Mathf.Atan2(velocity.x,velocity.y)*180/Mathf.PI,Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,.2f);
		}
	}
}
