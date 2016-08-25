using UnityEngine;
using System.Collections;

public class EnemyHanlder : MonoBehaviour {

	private int health;
	private int damage;
	public int viewRange;
	public int speed;

	private GameObject target;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		target = detect();
		if (target != null) {
			chase(target.transform.position.x, target.transform.position.y);
		}
	}

	//Getters and Setters

	public GameObject getTarget() {
		return target;
	}

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
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, viewRange);
		GameObject player = null;

		foreach (Collider2D collider in colliders) {
			if (collider.gameObject.tag == "Fire") {
				player = collider.gameObject;
			}
		}

		return player;
	}
}
