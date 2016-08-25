using UnityEngine;
using System.Collections;

public class waifuHandler : MonoBehaviour {

	private int counter = 0;
	// Use this for initialization
	void Start () {
	
	}

	void updateLaser() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

		foreach (Collider2D collider in colliders) {
			if (collider.gameObject.tag == "Bullet") {
				Destroy(collider.gameObject);
				counter = counter + 1;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateLaser();
		if (counter == 3) {
			Application.LoadLevel("GoodEnding");
		}
	}
}
