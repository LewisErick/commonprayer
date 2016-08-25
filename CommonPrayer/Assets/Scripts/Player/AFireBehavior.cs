using UnityEngine;
using System.Collections;

public class AFireBehavior : MonoBehaviour {

	private int damage;

	GlobalController controller;
	//BoxCollider2D colldr;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find("Controller").GetComponent<GlobalController>();
		//colldr = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            //Llamar al controlador para hacer daño al enemigo
            controller.performDamage(coll.gameObject.GetComponent<EnemyHanlder>(), 100);
        }
        
    }

	public int getDamage() {
		return damage;
	}

	public void setDamage(int dmg) {
		damage = dmg;
	}
}
