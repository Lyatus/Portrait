using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour {
	static HashSet<string> enteredRooms;
	void Start () {
		enteredRooms = new HashSet<string> ();
	}
	public static void enterRoom(string name){
		enteredRooms.Add (name);
		GameObject.Find ("Main Camera").GetComponent<CamMovement> ().changeCamera (enteredRooms.Count);
		MusicManager.makeAppear (name);
	}
}
