using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinalBossGirlAttack : MonoBehaviour {

	public int health;
	public int damage;
	public int speed;
	public int attackTimer;

	private int counter = 0;

	private int waitForAttackGirl, waitTimeGirl, blockedAttacks;
	Collider2D[] collidersArr;
	Physics2D physics;
	GameObject target;
	Vector3 chaseVector;
	Camera camera;
	List<Collider2D> colliders = new List<Collider2D>();
	PlayerMovement player;

	Vector3 corner1;
	Vector3 corner2;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		player = GameObject.Find ("Waifu").GetComponent<PlayerMovement> ();

		attackTimer = 100;


	}
	
	// Update is called once per frame
	void Update () {
	
		corner1 = camera.ScreenToWorldPoint(new Vector3(0,0,0));
		corner2 = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight,0));

		checkBullets ();


		if (waitForAttackGirl <= 0 && colliders.Count < 10) {
			attackGirl ();
			waitForAttackGirl += 100;
		}
			
	}

	void FixedUpdate() {
		waitForAttackGirl -= 1;
		attackTimer -= 1;
	}
			
	
	public void attackPlayer(){
	
		target = detect();


		bulletCreation ();
	}

	public void attackGirl(){


		target = detect();

		bulletCreation ();

	}

	//BulletCreation
	public void bulletCreation(){

		GameObject bullet = GameObject.Find("Bullet");


		float xAxis = transform.position.x;
		float zAxis = transform.position.z;
		float yAxis = transform.position.y;

		Vector3 bulletVector = new Vector3 (xAxis, yAxis, zAxis);

		counter = counter + 1;

		if (counter > 3) {
			Application.LoadLevel("GoodEnding");
			colliders.RemoveAt(0);
		}

		GameObject bull = Instantiate (bullet, bulletVector, new Quaternion(0,0,0,0)) as GameObject;
	
		bull.GetComponent<BulletHandler>().initializeBullet (target.transform.position.x, target.transform.position.y);
		bull.GetComponent<BulletHandler>().changeSpeed(0.125f);
		//bull.GetComponent<BulletHandler>().chase (target.transform.position.x, target.transform.position.y);
		}

	//Check if collides with Player
	void OnCollisionEnter2D(Collision2D coll) { // Siempre ejecut
		if (coll.gameObject.tag == "Player") {
			blockedAttacks += 1;
		}
		}

	//Look for player
	public GameObject detect() {
		GameObject waifu = GameObject.FindWithTag("Waifu"); //SET TO WAIFU

		return waifu;
	}

	//Check amount of bullets in screen
	public void checkBullets(){
	}

	//Spikes attack
	public void Spikeattack(){
		
		GameObject spikeBox;
		spikeBox = GameObject.CreatePrimitive(PrimitiveType.Cube);


		if(attackTimer == 80){
			spikeBox.transform.position = camera.ScreenToWorldPoint(new Vector3((Random.Range(0f,1f)),0,0));

		}
		if (attackTimer == 30) {
			spikeBox.transform.Translate(Vector3.up * 50);


		}

		if (attackTimer == 0) {
			DestroyObject (spikeBox);
		}

	}
	void OnCollisionEnter2D(Collider col){
		if (col.gameObject.tag == "Player") {
			
			player.SetLife(damage);
			Destroy (col.gameObject);
		}
		}
	}
	

	
	