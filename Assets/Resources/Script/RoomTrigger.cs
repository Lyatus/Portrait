using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {
	public string roomName;
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "Character")
			Level.enterRoom (roomName);
	}
}
