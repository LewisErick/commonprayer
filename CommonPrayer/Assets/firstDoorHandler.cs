using UnityEngine;
using System.Collections;

public class firstDoorHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Universe.candles >= 0) {
			Vector3 player = GameObject.Find("Player").transform.position;
			Vector3 myVector = transform.position;
			Vector3 yourVector = player;

			float distanceMag = Vector3.Distance(myVector, yourVector);

			if (distanceMag < 0.5f) {
				Application.LoadLevel("denialScene");
			}
		}
	}
}
