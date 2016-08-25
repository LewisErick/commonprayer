using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float barDisplay = 0f;
	Vector2 pos = new Vector2(20,40);
	Vector2 size = new Vector2(60,20);
	Texture2D progressBarEmpty;
	Texture2D progressBarFull;

	private int life, wallFrame, wallFrameWait;
	public int level;
	private bool isAlive, denialActivated, grounded, angerActivated;
	private float moveX, moveY;

	public float jumpPower = 2.5f;
	public float movePower = 2f;

	public bool canHit = true;
	public int hitWait = 0;

	private GlobalController controller;

	//Walk Animations
	public Sprite sWalkLeft;
	public Sprite sWalkRight;
	public RuntimeAnimatorController aWalkLeft;
	public RuntimeAnimatorController aWalkRight;
	
	//Idle Animations
	public Sprite sStandLeft;
	public Sprite sStandRight;
	//public RuntimeAnimatorController aStandLeft;
	//public RuntimeAnimatorController aStandRight;

	//Jump Animations
	public Sprite sJumpLeft;
	public Sprite sJumpRight;
	public RuntimeAnimatorController aJumpLeft;
	public RuntimeAnimatorController aJumpRight;

	Rigidbody2D rig;
	BoxCollider2D boxCollider;
	SpriteRenderer sprite;
	Animator anim;

	float oPosX, oPosY; 

	// Use this for initialization
	void Start () {
		life = 3;
		wallFrame = 500;
		controller = GameObject.FindWithTag("Controller").GetComponent<GlobalController>();
		boxCollider = GetComponent<BoxCollider2D>();
		//level = controller.getLevel();
		isAlive = true;
		denialActivated = false;
		angerActivated = false;
		grounded = false;
		rig = GetComponent<Rigidbody2D>();
		rig.freezeRotation = true;

		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();

	}
	
	//FixedUpdate
	void FixedUpdate() {
		barDisplay = Time.time * 0.05f;
		//Horizontal Movement
		moveX = Input.GetAxis("Horizontal") * movePower * Time.deltaTime;
		if (grounded == true && level != 2) {
			if (Input.GetAxis("Horizontal") > 0) {
				sprite.sprite = sWalkRight;
				anim.runtimeAnimatorController = aWalkRight;
			} else {
				if (Input.GetAxis("Horizontal") < 0) {
					sprite.sprite = sWalkLeft;
					anim.runtimeAnimatorController = aWalkLeft;
				} else {
					if (sprite.sprite == sWalkLeft || sprite.sprite == sJumpLeft) {
						sprite.sprite = sStandLeft;
						anim.runtimeAnimatorController = null;
					} else {
						if (sprite.sprite == sWalkRight || sprite.sprite == sJumpRight) {
							sprite.sprite = sStandRight;
							anim.runtimeAnimatorController = null;
						}
					}
				}
			}
		} else {
			if (Input.GetAxis("Horizontal") > 0) {
				sprite.sprite = sJumpRight;
				anim.runtimeAnimatorController = aJumpRight;
			} else {
				if (Input.GetAxis("Horizontal") < 0) {
					sprite.sprite = sJumpLeft;
					anim.runtimeAnimatorController = aJumpLeft;
				} else {
					if (sprite.sprite == sWalkLeft || sprite.sprite == sStandLeft) {
						sprite.sprite = sJumpLeft;
						anim.runtimeAnimatorController = aJumpLeft;
					} else {
						if (sprite.sprite == sWalkRight || sprite.sprite == sStandRight) {
							sprite.sprite = sJumpRight;
							anim.runtimeAnimatorController = aJumpRight;
						}
					}
				}
			}
		}

		if (level == 2) {
			if (moveX < 0) {
				moveX = 0;
				sprite.sprite = sWalkRight;
				anim.runtimeAnimatorController = aWalkRight;
			}
		}

		Vector3 moveVector = new Vector3(moveX, 0, 0);
		transform.Translate(moveVector);
	}

	void updateLaser() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

		foreach (Collider2D collider in colliders) {
			if (collider.gameObject.tag == "Bullet") {
				Destroy(collider.gameObject);
				applyDamage(1);//Hacer daño
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (hitWait > 0) {
			hitWait -= 1;
		} else {
			canHit = true;
		}
		updateLaser();
		//controller = GameObject.FindWithTag("Controller").GetComponent<GlobalController>();
		//level = controller.getLevel();

		if (grounded == true) {
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				Vector2 force = new Vector2(0, jumpPower);
				rig.AddForce(force, ForceMode2D.Impulse);
			}
		}

		switch (level) {
		case 1:
			denialHandler();
			break;
		case 2:
			angerHandler();
			break;
		case 3:
			bargainHandler();
			break;
		case 4:
			depressionHandler();
			break;
		case 5:
			acceptanceHanlder();
			break;
		}
	}
	//Getters and Setters

	public int GetLife(){
		return life;
}

	public void SetLife(int lif){
		life = lif;
	}

	public bool GetIsAlive(){
		return isAlive;
	}

	public void SetIsAlive(bool Alive){

		isAlive = Alive;
	}

	public void applyDamage(int dmg) {
		canHit = false;
		hitWait = 200;
		life = life - dmg;
		if (life <= 0) {
			isAlive = false;
			if (level == 6) {
				Application.LoadLevel("GoodEnding");
			} else {
				Application.LoadLevel("GameOver");
			}
		}
	}

	//Handlers
	public void denialHandler(){
		//if (Input.GetKeyDown(KeyCode.Space)){ //Check button for activation
		//	Debug.Log("DDD");
		//	transform.position = new Vector3(transform.position.x, (denialActivated ? transform.position.y-1f : transform.position.y+2f), transform.position.z);
		//	denialActivated = (denialActivated ? false : true);
		//	grounded = false;

		//	if (denialActivated) {
		//		wallFrameWait = wallFrame;
		//		wallFrame = wallFrame - 1;
		//	}
		//}
		//if (denialActivated) {
		//	if (wallFrameWait > 0){
		//		wallFrameWait = wallFrameWait - 1;		
		//	} else {
		//		denialActivated = false;
		//		transform.position = new Vector3(transform.position.x, transform.position.y+2f, transform.position.z);
		//	}
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (denialActivated == false)
			{
				oPosY = transform.position.y;
				transform.position = new Vector3(transform.position.x, oPosY+0.9f, transform.position.z);
				denialActivated = true;
			} else {
				transform.position = new Vector3(transform.position.x, oPosY, transform.position.z);
				denialActivated = false;
			}
		}


	}

	public void angerHandler(){
		if(Input.GetKeyDown(KeyCode.Space)) {;
			GameObject fire = GameObject.Find("firePowa");

			float xAxis = transform.position.x;
			float yAxis = transform.position.y;
			float zAxis = transform.position.z;

			Vector3 bulletVector = new Vector3 (xAxis, yAxis, zAxis);

			GameObject bull = Instantiate (fire, bulletVector, new Quaternion(0,0,0,0)) as GameObject;
			//bull.GetComponent<firePowaHandler>().initializeFire();
			//bull.GetComponent<BulletHandler>().initializeBullet(target.transform.position.x, target.transform.position.y);
		}
		Vector3 angerVector = new Vector3(movePower/100f,0,0);
		transform.Translate(angerVector);
	}

	public void bargainHandler() {
		//BargainHandler
	}

	public void depressionHandler(){
		//DepresionHandler
	}

	public void acceptanceHanlder(){
		//AcceptanceHandler
	}

	void OnCollisionEnter2D(Collision2D coll) {
        if ((coll.gameObject.tag == "Platform" || coll.gameObject.tag == "DistancePlatform" || coll.gameObject.tag == "Breakable") && coll.gameObject.transform.position.y < transform.position.y) {
            grounded = true;
        }
        Debug.Log(coll.gameObject.tag);
    }

    void OnCollisionExit2D(Collision2D coll) {
    	if ((coll.gameObject.tag == "Platform" || coll.gameObject.tag == "DistancePlatform" || coll.gameObject.tag == "Breakable") && coll.gameObject.transform.position.y < transform.position.y) {
    		grounded = false;
    	}
    }

    void OnTriggerEnter2D(Collider2D coll) {
    	if (coll.gameObject.tag == "SkullEnemy" || coll.gameObject.tag == "Bullet" || coll.gameObject.tag == "BombEnemy" || coll.gameObject.tag == "Explosion") {
    		if (canHit) {
    			applyDamage(1);
    		}
    	}
    	if (coll.gameObject.tag == "Dead") {
    		Application.LoadLevel("GameOver");
    	}
        if (coll.gameObject.tag == "DistancePlatform" && coll.gameObject.transform.position.y < transform.position.y) {
            grounded = true;
        }
        if (coll.gameObject.name == "ExitDoor") {
        	Universe.candles = Universe.candles + 1;
        	Application.LoadLevel("Lobby");
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
    	if (coll.gameObject.tag == "DistancePlatform" && coll.gameObject.transform.position.y < transform.position.y) {
    		grounded = false;
    	}
    }


}
