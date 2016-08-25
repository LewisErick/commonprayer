using UnityEngine;
using System.Collections;

public class BombEnemyBeh : MonoBehaviour {

	private int health;
	private int damage;
	public int viewRange;
	public float speed;

	private int explodeTimer;
	private bool lit, exploded;

	ExplosionHandler explosion;

	Rigidbody2D rig;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D>();
		rig.freezeRotation = true;
		lit = false;
		explodeTimer = 0;
		exploded = false;
		explosion = transform.Find("Explosion").gameObject.GetComponent<ExplosionHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject target = detect();
		if (lit) {
			if (explodeTimer > 0) {
				explodeTimer = explodeTimer - 1;
				return;
			} else {
				explode();
			}
		}
		if (exploded) {
			if (explodeTimer > 0) {
				explodeTimer = explodeTimer - 1;
			} else {
				Destroy(gameObject);
			}
			return;
		}
		if (target != null) {
			chase(target.transform.position.x-1f, target.transform.position.y);
		}
	}

	void explode() {
		lit = false;
		exploded = true;
		explosion = transform.Find("Explosion").gameObject.GetComponent<ExplosionHandler>();
		explosion.explode();
		GetComponent<SpriteRenderer>().sprite = null;
		GetComponent<Animator>().runtimeAnimatorController = null;
		explodeTimer = 35;
	}

	void OnTriggerEnter2D(Collider2D other) {
        if ((other.gameObject.tag == "Fire" || other.gameObject.tag == "Player") && (exploded == false && explodeTimer == 0 && lit == false)) {
			explodeTimer = 40;
			lit = true;
		}
    }

    void OnCollisionEnter2D(Collision2D other) {
    	Debug.Log(other.gameObject.tag);
        if ((other.gameObject.tag == "Fire" || other.gameObject.tag == "Player") && (exploded == false && explodeTimer == 0 && lit == false)) {
			explodeTimer = 40;
			lit = true;
		}
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
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);

		foreach (Collider2D collider in colliders) {
			if ((collider.gameObject.tag == "Fire" || collider.gameObject.tag == "Player") && (exploded == false && explodeTimer == 0 && lit == false)) {
				explodeTimer = 40;
				lit = true;
				return null;
			}
		}		
		colliders = Physics2D.OverlapCircleAll(transform.position, viewRange);
		GameObject player = null;

		foreach (Collider2D collider in colliders) {
			if (collider.gameObject.tag == "Fire" || collider.gameObject.tag == "Player") {
				player = collider.gameObject;
			}
		}

		return player;
	}
}
	