using UnityEngine;
using System.Collections;


public class Fighter : MonoBehaviour {

	/* Singleton */
	public static Fighter S;

	/* Fighter Stats */
	public int HP;
	public int curHP;

	/* Sprites */
	public Sprite		  upSprite;
	public Sprite		  downSprite;
	public Sprite		  leftSprite;
	public Sprite		  rightSprite;
	public SpriteRenderer sprend;

	/* Movement */
	public RaycastHit	hitInfo;
	public bool 		moving = false;
	public Vector3		targetPos;
	public Direction 	direction;
	public Vector3		moveVec;
	public Vector3      start;
	public float 		moveSpeed;
	
	public enum Direction{
		down,
		left,
		up,
		right
	}
	
	new public Rigidbody rigidbody{
		get {return gameObject.GetComponent<Rigidbody>();}
	}
	
	public Vector3 pos{
		get{return transform.position; }
		set { transform.position = value;}
	}

	void Awake(){
		S = this;
		
	}

	void Start(){
		
		sprend = gameObject.GetComponent<SpriteRenderer> ();
		
	}
	
	void FixedUpdate(){
		if (curHP <= 0)
			gameObject.SetActive (false);
		if (!moving) {
			if(Input.GetKeyDown(KeyCode.A)){
				//Action();
				print ("Attack!");
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				moveVec = Vector3.right;
				direction = Direction.right;
				sprend.sprite = rightSprite;
				
				moving = true;
				
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				moveVec = Vector3.left;
				direction = Direction.left;
				sprend.sprite = leftSprite;
				
				moving = true;
				
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				moveVec = Vector3.down;
				direction = Direction.down;
				sprend.sprite = downSprite;
				
				moving = true;
				
			} else if (Input.GetKey (KeyCode.UpArrow)) {
				moveVec = Vector3.up;
				direction = Direction.up;
				sprend.sprite = upSprite;
				
				moving = true;
				
				
			} else {
				moveVec = Vector3.zero;
				moving = false;
			}
			
			if(Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] {"Ground"}))){
				moveVec = Vector3.zero;
				moving = false;
				
			}
			
			
			targetPos = pos + moveVec;
			
		} else {
			
			if((targetPos - pos).magnitude < moveSpeed * Time.fixedDeltaTime ){
				pos = targetPos;
				moving = false;
			}
			else{
				pos += (targetPos - pos).normalized * moveSpeed * Time.fixedDeltaTime;
			}
			
		}
		
	}
	
	/*public void Action(){
		Vector3 org = pos;
		Direction orgd = direction;
		direction = Direction.up;
		bool hit = false;
		for (int i = 0; i < curMove.rangeSize; i++) {
			pos = curMove.range[i] + org;
			if(Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] {"Sign"}))){
				hit = true;
			}
		}
		if (hit) {
			Enemy.S.curHP -= curMove.damage;
		}
		else{
			
		}
		pos = org;
		
		curMove.ShowSelf ();
		
	}*/
	
	Ray GetRay(){
		switch(direction){
		case Direction.down:
			return new Ray(pos,Vector3.down);
		case Direction.left:
			return new Ray(pos,Vector3.left);
		case Direction.right:
			return new Ray(pos,Vector3.right);
		case Direction.up:
			return new Ray(pos,Vector3.up);
		default:
			return new Ray();
		}
	}
	
	int GetLayerMask(string[] layerNames){
		int layerMask = 0;
		
		foreach(string layer in layerNames){
			layerMask = layerMask | (1 << LayerMask.NameToLayer(layer));
		}
		
		return layerMask;
	}
	
	/*public void AssignSprites(){
		if (PokemonSelection.S.chosen_pokemon.Equals("Pikachu")) {
			upSprite = pikachuUp;
			downSprite = pikachuDown;
			leftSprite = pikachuLeft;
			rightSprite = pikachuRight;
		} else if (PokemonSelection.S.chosen_pokemon.Equals("Bulbasaur")) {
			upSprite    = bulbasaurUp;
			downSprite  = bulbsaurDown;
			leftSprite  = bulbasaurLeft;
			rightSprite = bulbasaurRight;
		}
		else if (PokemonSelection.S.chosen_pokemon.Equals("Charmander")) {
			upSprite    = charmanderUp;
			downSprite  = charmanderDown;
			leftSprite  = charmanderLeft;
			rightSprite = charmanderRight;
		}
		else if (PokemonSelection.S.chosen_pokemon.Equals("Squirtle")) {
			upSprite    = squirtleUp;
			downSprite  = squirtleDown;
			leftSprite  = squirtleLeft;
			rightSprite = squirtleRight;
		}
		
	}*/
	
	
}
