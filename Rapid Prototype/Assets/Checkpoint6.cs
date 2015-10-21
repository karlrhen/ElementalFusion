using UnityEngine;
using System.Collections;

public class Checkpoint6 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.name == "Fighter") {
			Destroy(this.gameObject);
			print("YES");
			
			Timer.S.time = 0;
			Destroy(Timer.S.gameObject);
			ExerciseText.S.goText.text = "FINISHED - Press Q to Restart!!!!";
			Timer.S.FreezeFighter();
		}
	}
}
