using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public Rigidbody FireballPrefab;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.S)) {
			FireballAttack();
		}
	}

	public void FireballAttack(){
		Rigidbody tmp_prefab = Instantiate (FireballPrefab, transform.position, Quaternion.identity) as Rigidbody;
		tmp_prefab.AddForce (Vector3.right * 500);
	}
}
