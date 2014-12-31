using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {
	public float maxSpeed;
	public float acceleration;
	void Update () {
		if (GameObject.Find ("GUI").GetComponent<GUI> ().isFree ()) {
				// Direction
				Vector2 direction = Vector2.zero;

				if (Input.GetKey (KeyCode.Z))
						direction += Vector2.up;
				if (Input.GetKey (KeyCode.S))
						direction -= Vector2.up;
				if (Input.GetKey (KeyCode.D))
						direction += Vector2.right;
				if (Input.GetKey (KeyCode.Q))
						direction -= Vector2.right;


				if (direction == Vector2.zero // There is no input
						|| gameObject.rigidbody.velocity.magnitude >= maxSpeed) // Over maxSpeed
						gameObject.rigidbody.velocity *= .8f; // Decelerate
				else
						gameObject.rigidbody.AddForce (direction.normalized * Time.deltaTime * acceleration); // Accelerate
				float speed = gameObject.rigidbody.velocity.magnitude;
				gameObject.GetComponentInChildren<Animator> ().speed = speed / maxSpeed;
				gameObject.GetComponentInChildren<Animator> ().SetBool ("stopped", (speed < .1f));

				// Action
				ActivatableObject[] aos;
				RaycastHit[] rchs = Physics.RaycastAll (gameObject.transform.position, gameObject.transform.rotation * Vector3.up, 1f);
				foreach (RaycastHit rch in rchs) { // For each hit
						aos = rch.collider.gameObject.GetComponents<ActivatableObject> (); // Get ActivatableObject component
						foreach (ActivatableObject ao in aos)
								reachableObject (ao);
				}
		}
	}
	void OnTriggerStay(Collider c){
		ActivatableObject[] aos = c.gameObject.GetComponents<ActivatableObject> ();
		foreach (ActivatableObject ao in aos)
			reachableObject (ao);
	}
	void reachableObject(ActivatableObject ao){
		ao.highlight();
		if (Input.GetMouseButtonDown(0))
			ao.activate();
	}
}
