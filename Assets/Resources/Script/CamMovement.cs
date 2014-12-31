using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {
	public float speed = 1;
	float targetFoV;
	float targetMask;

	void Start () {
		changeCamera (0);
	}
	void Update () {
		Vector3 character = GameObject.Find ("Character").transform.position;
		Vector3 cam = gameObject.transform.position;
		character.z = cam.z = 0; // We're working in 2D
		if (Vector3.Distance (character, cam) > camera.orthographicSize/2)
			gameObject.transform.position += (character-cam)*(Time.deltaTime*speed);
	}
	public void changeCamera(int i){
		switch (i) {
			case 0:
				changeFoV(16);
				changeMask(.5f);
				break;
			case 1:
				changeFoV(16);
				changeMask(.75f);
				break;
			case 2:
				changeFoV(16);
				changeMask(1f);
				break;
			case 3:
				changeFoV(32);
				changeMask(1f);
				break;
			case 4:
				changeFoV(48);
				changeMask(1f);
				break;
			case 5:
				changeFoV(64);
				changeMask(1f);
				break;
			default:
				Debug.Log("No camera option for "+i);
				break;
		}
	}
	void changeFoV(float fov){
		gameObject.camera.fieldOfView = fov;
	}
	void changeMask(float ratio){
		float size = (1-ratio)/2f;
		//gameObject.camera.rect = new Rect(pos,pos,size,size);
		GameObject.Find ("Top Cache").camera.rect = new Rect (0, 1-size, 1, size);
		GameObject.Find ("Bottom Cache").camera.rect = new Rect (0, 0, 1, size);
		GameObject.Find ("Left Cache").camera.rect = new Rect (0, 0, size, 1);
		GameObject.Find ("Right Cache").camera.rect = new Rect (1-size, 0, size, 1);
	}

}
