using UnityEngine;
using System.Collections;

public class PlayerMovHUB : MonoBehaviour {

	//Walk Animations
	public Sprite sWalkLeft;
	public Sprite sWalkRight;
	public RuntimeAnimatorController aWalkLeft;
	public RuntimeAnimatorController aWalkRight;

	//Idle Animations
	public Sprite sStandLeft;
	public Sprite sStandRight;

	public bool canMove;
	float moveX, moveY, moveZ;

	SpriteRenderer spriter;
	Animator anim;
	Rigidbody rig;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody>();
		rig.freezeRotation = true;
		spriter = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	public void movePlayer(float mX, float mY) {
		moveX = mX;
		moveY = mY;
	}
	
	// Update is called once per frame
	void Update () {
		spriter = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		if (canMove) {
			moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 2;
			moveY = Input.GetAxis("Vertical") * Time.deltaTime * 2;
			//moveZ = Input.GetAxis("Vertical") * Time.deltaTime;
		}

		if (moveX > 0) {
			spriter.sprite = sWalkRight;
			anim.runtimeAnimatorController = aWalkRight;
		} else {
			if (moveX < 0) {
				spriter.sprite = sWalkLeft;
				anim.runtimeAnimatorController = aWalkLeft;
			} else {
				if (moveY == 0) {
					if (spriter.sprite == sWalkLeft) {
						spriter.sprite = sStandLeft;
						anim.runtimeAnimatorController = null;
					} else {
						if (spriter.sprite == sWalkRight) {
							spriter.sprite = sStandRight;
							anim.runtimeAnimatorController = null;
						}
					}
				} else {
					if (spriter.sprite == sStandLeft) {
						spriter.sprite = sWalkLeft;
						anim.runtimeAnimatorController = aWalkLeft;
					} else {
						if (spriter.sprite == sStandRight) {
							spriter.sprite = sWalkRight;
							anim.runtimeAnimatorController = aWalkRight;
						}
					}
				}
			}
		}

		transform.Translate(moveX, moveZ, moveY);
	}

	void OnTriggerEnter2D(Collider2D coll){
		Debug.Log(coll.gameObject);
	}
}
