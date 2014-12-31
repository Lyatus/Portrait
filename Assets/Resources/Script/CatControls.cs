using UnityEngine;
using System.Collections;

public class CatControls : MonoBehaviour {
	public float maxSpeed;
	public float acceleration;
	Vector2 direction;
	// Use this for initialization
	void Start () {
		changeDirection ();
	}

	void changeDirection(){
		direction = new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0, 128) == 0)
			changeDirection ();
		if(gameObject.rigidbody.velocity.magnitude < maxSpeed)
			gameObject.rigidbody.AddForce(direction.normalized*Time.deltaTime*acceleration); // Accelerate
		else gameObject.rigidbody.velocity *= .8f;
		float speed = gameObject.rigidbody.velocity.magnitude/4;
		gameObject.GetComponentInChildren<Animator> ().speed = speed / maxSpeed;
	}
}
