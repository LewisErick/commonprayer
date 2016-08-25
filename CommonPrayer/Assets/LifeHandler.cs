using UnityEngine;
using System.Collections;

public class LifeHandler : MonoBehaviour {

	public int life;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Player").GetComponent<PlayerMovement>().GetLife() >= life) {

		} else {
			Destroy(gameObject);
		}
	}
}
