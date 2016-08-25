using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerOne : MonoBehaviour {

	private bool activated = false;
	private int cutsceneTimer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			if (cutsceneTimer >= 0 && cutsceneTimer <= 100) {
				Image imageScreen = GameObject.Find ("TintScreen").GetComponent<Image>();
				imageScreen.color = new Color (0, 0, 0, (cutsceneTimer/100.0f));
			}
			if (cutsceneTimer == 101) {
				Application.LoadLevel("denialScene");
			}
			cutsceneTimer += 1;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("lel");
		if (other.gameObject.tag == "Player") {
			activated = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log("lel");
		if (other.gameObject.tag == "Player") {
			activated = true;
		}
	}
}
