using UnityEngine;
using System.Collections;

public class FireBallAttack : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "ENEMY") {
			Destroy(gameObject); // Destroy GameObject
			Destroy (other.gameObject);
		}
	}
}
