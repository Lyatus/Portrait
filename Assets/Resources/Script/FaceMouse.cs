using UnityEngine;
using System.Collections;

public class FaceMouse : MonoBehaviour {
	public float speed;
	void Update () {
		if (GameObject.Find ("GUI").GetComponent<GUI> ().isFree ()) {
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						RaycastHit hit;
						if (Physics.Raycast (ray, out hit)) {
								Vector2 direction = hit.point - transform.position;
								if (direction.magnitude > 0f) { // If not pointing character
										Quaternion targetRotation = Quaternion.AngleAxis (-Mathf.Atan2 (direction.x, direction.y) * 180 / Mathf.PI, Vector3.forward);
										transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, .2f);
								}
						}
				}
	}
}
