using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaskHandler : MonoBehaviour {

	private int damage = 10;
	public float speed;
	private int viewRange;
	int shootWait;
	List<Collider2D> colliders = new List<Collider2D>();

	Collider2D[] collidersArr;
	GameObject target;
	Vector3 chaseVector;
	Physics2D physics;
	Camera camera;

	Vector3 corner1;
	Vector3 corner2;


	// Use this for initialization
	void Start (){
		camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		shootWait = 25;
	}

	void FixedUpdate() {
		shootWait = shootWait - 1;
	}

	// Update is called once per frame
	void Update (){

		corner1 = camera.ScreenToWorldPoint(new Vector3(0,0,0));
		corner2 = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight,0));

		checkBullets();

		target = detect();


		if (target != null) {
			chase (target.transform.position.x, target.transform.position.y);
		}

		if(colliders.Count<10 && shootWait == 0){
			shootWait = 25;
			bulletCreation();
		}
	}

	void bulletCreation(){

		GameObject mask = GameObject.Find("Mask");
		GameObject bullet = GameObject.Find("Bullet");

		float xAxis = mask.transform.position.x;
		float yAxis = mask.transform.position.y;
		float zAxis = mask.transform.position.z;

		Vector3 bulletVector = new Vector3 (xAxis, yAxis, zAxis);

		GameObject bull = Instantiate (bullet, bulletVector, new Quaternion(0,0,0,0)) as GameObject;
		bull.GetComponent<BulletHandler>().initializeBullet(target.transform.position.x, target.transform.position.y);

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

	public GameObject detect() {
		GameObject player = GameObject.FindWithTag("Player");

		return player;
	}

	public float towards(float x, float deltaX, float targetX) {
		if (Mathf.Abs((targetX - x)) - Mathf.Abs(deltaX) < 0) {
			deltaX = targetX - x;
		}
		return deltaX;
	}

	public void checkBullets(){

		collidersArr = Physics2D.OverlapAreaAll (corner1, corner2);

		for (int i = 0; i < collidersArr.Length; i++) {
			if (collidersArr[i].tag == "Bullet") {
				colliders [i] = collidersArr [i];
			}
		}

		if (colliders.Count > 10) {
			
			colliders.RemoveAt(0);
		}
	}
}
