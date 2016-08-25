using UnityEngine;
using System.Collections;

public class SkullEnemyBeh : MonoBehaviour {

	private int health;
	private int damage;
	public int viewRange;
	public float speed;

	public bool chasing;

	private GameObject target;

	BombEnemyBeh bomb;
	Rigidbody2D rig;

	// Use this for initialization
	void Start ()
	{
		rig = GetComponent<Rigidbody2D>();
		rig.freezeRotation = true;
		chasing = false;
		if (gameObject != null) {
			bomb = gameObject.GetComponent<BombEnemyBeh>();
		} else {
			bomb = null;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		target = detect();
		if (target != null) {
			chasing = true;
			chase(target.transform.position.x-0.75f, target.transform.position.y);
		} else {
			chasing = false;
		}
	}

	public GameObject getTarget() {
		return target;
	}

	

	public bool isChasing() {
		return chasing;
	}

	//Getters and Setters

	public int getHealth(){
		return health;
	}

	public void setHealth(int h){
		health = h;
	}

	public void chase(float x, float y) {

		Vector3 chaseVector = new Vector3(0,0,0);
		if (x > transform.position.x) {
			float moveX = towards(transform.position.x, speed, x);
			chaseVector = new Vector3(moveX, 0, 0);
		}
		else { 
			if (x < transform.position.x) {
				float moveX = towards(transform.position.x, -speed, x);
				chaseVector = new Vector3(moveX, 0, 0);
			}
		}
		transform.Translate(chaseVector);
	}

	public float towards(float x, float deltaX, float targetX) {
		if (Mathf.Abs((targetX - x)) - Mathf.Abs(deltaX) < 0) {
			deltaX = targetX - x;
		}
		return deltaX;
	}

	public GameObject detect() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

		foreach (Collider2D collider in colliders) {
			if (collider.gameObject.tag == "PlayerBullet") {
				Destroy(collider.gameObject);
				Destroy(gameObject);
			}
		}

		colliders = Physics2D.OverlapCircleAll(transform.position, viewRange);
		GameObject player = null;

		foreach (Collider2D collider in colliders) {
			if (collider.gameObject.tag == "Fire") {
				player = collider.gameObject;
			}
		}

		return player;
	}
}