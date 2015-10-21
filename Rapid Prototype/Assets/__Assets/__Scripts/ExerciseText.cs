using UnityEngine;
using System.Collections;

public class ExerciseText : MonoBehaviour {


	public static ExerciseText S;
	public string display_text;
	public GUIText goText;

	void Awake () {
		S = this;
	}


	// Use this for initialization
	void Start () {
		display_text = "WARM UP: RUN IN PLACE-DONT STOP!";
	    goText = GetComponent<GUIText> ();
		goText.text = display_text;
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (Timer.S.time <= 0) {
//			goText.text = display_text;
//		}
	
	}
}
