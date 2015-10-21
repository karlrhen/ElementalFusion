using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static Timer S;

	public float time = 60;
	// Use this for initialization
	void Awake () {
		S = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (time >= 0) {
			time -= Time.deltaTime;
			GUIText goText = GetComponent<GUIText> ();
			int integer_time = (int)time;
			goText.text = integer_time.ToString ();  

			FreezeFighter ();

			Fighter.S.health_bar.fillAmount = (float)time / 60;

		} else {
			UnfreezeFighter();
			GUIText goText = GetComponent<GUIText> ();
			int integer_time = (int)time;
			goText.text = integer_time.ToString (); 

			ExerciseText.S.goText.text = "MOVE AHEAD";

		}

	}

	public void FreezeFighter()
	{
		Vector3 pos = Fighter.S.moveDirection; 
		pos.x = 0;
		pos.y = 0;
		pos.z = 0;
		Fighter.S.moveDirection = pos;
		Fighter.S.speed = 0;
		Fighter.S.jump_speed = 0;

	}

	public void UnfreezeFighter()
	{
		Fighter.S.speed = 6.0F;
		Fighter.S.jump_speed = 8.0F;
	}
}

