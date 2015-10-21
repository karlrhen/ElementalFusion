using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class Fighter : MonoBehaviour {

	/* Singleton */ 
	public static Fighter S;

	/* Sprites */ 
	public Sprite		  up_sprite;
	public Sprite		  left_sprite;
	public Sprite		  right_sprite;
	public Sprite		  down_sprite;

	public SpriteRenderer sprend;

	/* Movement */
	public float    speed         = 6.0F;
	public float    jump_speed    = 8.0F;
	public float    gravity       = 20.0F;
	public Vector3 moveDirection = Vector3.zero;
 
	public CharacterController controller{
		get{
			return GetComponent<CharacterController>();
		}
	}

	/* Fighter Stats */
	public  int   health;
	public  int   max_health;
	public  Image health_bar; 

	void Awake(){
		S = this;
	}

	void Start(){
		health     = 100;
		max_health = 100;
		health_bar = transform.FindChild ("FighterCanvas").FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
	}

	void Update(){
	
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;

		Move ();
		if(Input.GetKeyDown(KeyCode.I)){
			Timer.S.time = 0;
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			Application.LoadLevel("_Scene_1");
		}
	}

	void Move(){
 		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetKeyDown(KeyCode.Space)){
				moveDirection.y     = jump_speed;
				sprend.sprite       = up_sprite;
 			}
			if(Input.GetKeyDown(KeyCode.DownArrow)){
				print ("fix this");
				//moveDirection.z = 0; -> freeze z 
			}
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				print ("fix this");
				//moveDirection.z = 0; -> freeze z...2d movement
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				sprend.sprite = left_sprite;
			}
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				sprend.sprite = right_sprite;
			}

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		if (controller.velocity.x == 0 && controller.velocity.y == 0 ) {
			sprend.sprite = down_sprite;
		}
	}

	public void Hit(int damage){
		health -= damage;
		health_bar.fillAmount = (float)health / (float)max_health;
	}
	
}
