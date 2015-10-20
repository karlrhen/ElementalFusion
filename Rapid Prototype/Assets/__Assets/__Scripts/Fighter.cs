using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class Fighter : MonoBehaviour {
	/*
	// Singleton 
	public static Fighter S;

	// Fighter Stats  
	public int fighter_health;

	// Sprites  
	public Sprite		  up_sprite;
	public Sprite		  left_sprite;
	public Sprite		  right_sprite;
	public SpriteRenderer sprend;

	// Movement  
	public Vector3		target_velocity;
	public float 		movement_speed;
	
	new public Rigidbody rigidbody{
		get {return gameObject.GetComponent<Rigidbody>();}
	}

	void Awake(){
		S = this;
	}

	void Start(){
		sprend = gameObject.GetComponent<SpriteRenderer> ();	
	}
	
	void FixedUpdate(){
		 target_velocity = rigidbody.velocity;

		if(Input.GetKeyDown(KeyCode.A)){
			print ("Attack!");
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			target_velocity.x += 1f;
			sprend.sprite = right_sprite;
		} 
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			target_velocity.x -= 1f;
			sprend.sprite = left_sprite;
		} 
		else if (Input.GetKey (KeyCode.UpArrow)) {
			sprend.sprite = up_sprite;
			target_velocity.y += 0.5f;
		} 
		else {
			target_velocity.x = 0;
		}
		rigidbody.velocity = target_velocity;
	}*/


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
	private Vector3 moveDirection = Vector3.zero;
 
	private CharacterController controller{
		get{
			return GetComponent<CharacterController>();
		}
	}

	/* Fighter Stats */
	public  int   health;
	public  int   max_health;
	public  Image health_bar; 

	void Start(){
		health     = 100;
		max_health = 100;
		health_bar = transform.FindChild ("FighterCanvas").FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
	}

	void Update(){
		Move ();
		if(Input.GetKeyDown(KeyCode.A)){
			Hit (10);
			print ("inflicting damage!");
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
			}
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				print ("fix this");
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
