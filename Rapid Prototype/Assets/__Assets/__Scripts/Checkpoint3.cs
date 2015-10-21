using UnityEngine;
using System.Collections;

public class Checkpoint3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.name == "Fighter") {
			Destroy(this.gameObject);
			print("YES:");
			
			Timer.S.time = 60;
			ExerciseText.S.goText.text = "DO 30 SQUATS";
		}
	}
}
