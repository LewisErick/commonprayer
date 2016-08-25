using UnityEngine;
using System.Collections;

public class RockHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
		foreach (Collider2D collider in colliders) {
			if (collider.gameObject.tag == "Explosion") {
				if (collider.gameObject.GetComponent<SpriteRenderer>().sprite != null) {
					Destroy(gameObject);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log(coll.gameObject.tag);
		if (coll.gameObject.tag == "Explosion") {
			if (coll.gameObject.GetComponent<SpriteRenderer>().sprite != null) {
				Destroy(gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log(coll.gameObject.tag);
		if (coll.gameObject.tag == "Explosion") {
			if (coll.gameObject.GetComponent<SpriteRenderer>().sprite != null) {
				Destroy(gameObject);
			}
		}
	}
}
