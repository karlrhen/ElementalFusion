using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {
	public static Dialog S;
	
	void Awake(){
		S = this;
	}
	
	public bool q = false;
	public string[] queue;
	public int queueLength = 0;
	public int iter = 0;
	// Use this for initialization
	void Start () {
		HideDialogBox ();
		queue = new string[20];
	}
	
	
	//creates a Queue of messages, doesn't print anything
	public void QueueMessage(string s){
		if (queueLength < 0)
			queueLength = 0;
		queue [queueLength] = s;
		queueLength++;
	}
	
	
	//Prints messages in queue, great for long dialog
	public void PrintQueue(){
		iter = 0;
		q = true;
		//Main.S.inDialog = true;
		GameObject dialogBox = transform.Find("Text").gameObject;
		Text goText = dialogBox.GetComponent<Text>();
		goText.text = queue[iter];
		iter++;
		//Main.S.inDialogCount = 4;
	}
	
	//typical message call, used by npc
	public void ShowMessage(string message)
	{
		print("show");
		q = false;
		//Main.S.inDialog = true;
		GameObject dialogBox = transform.Find("Text").gameObject;
		Text goText = dialogBox.GetComponent<Text>();
		goText.text = message;
		//Main.S.inDialogCount = 4;
	}
	
	
	//used by the store to keep the text up
	public void StoreMessage(string message){
		GameObject dialogBox = transform.Find("Text").gameObject;
		Text goText = dialogBox.GetComponent<Text>();
		goText.text = message;
		//Main.S.inDialogCount = 4;
	}
	
	
	
	// Update is called once per frame
	void Update () {
		if (/*Main.S.inDialog && */Input.GetKeyDown (KeyCode.P)/*&& Main.S.enterDiagCount == 0*/) {
			print ("hit");
			if(!q)
			{
				HideDialogBox();
			}
			else{
				if(iter < queueLength -1){
					GameObject dialogBox = transform.Find("Text").gameObject;
					Text goText = dialogBox.GetComponent<Text>();
					goText.text = queue[iter];
					iter++;
					
				}else if(iter == queueLength - 1){
					queueLength = 0;
					ShowMessage(queue[iter]);
					print ("boom");
				}else{
					print ("ehy");
					
					HideDialogBox();
				}
			}	
		}
		
	}
	
	void HideDialogBox(){
//		if(!Main.S.inBattle){
//			Battle.S.gameObject.SetActive (false);
//		}
		
		print ("hidden");
		Color noAlpha = GameObject.Find ("DialogBackground").GetComponent <GUITexture> ().color;
		noAlpha.a = 0;
		GameObject.Find ("DialogBackground").GetComponent <GUITexture> ().color = noAlpha;
		gameObject.SetActive (false);
//		Main.S.inDialog = false;
//		if(Main.S.trainerDialog){
//			Main.S.trainerDialog = false;
//			Battle.S.startBattle(Team1.S,Temp.S);
//			
//		}
	}
}
