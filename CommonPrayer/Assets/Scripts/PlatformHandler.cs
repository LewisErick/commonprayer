using UnityEngine;
using System.Collections;

public class PlatformHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name =="Candle") {
			return;
		}
        other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
