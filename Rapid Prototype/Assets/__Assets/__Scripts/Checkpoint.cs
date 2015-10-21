using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

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
			ExerciseText.S.goText.text = "DO 100 Jumping Jacks";
		}
	}
}
