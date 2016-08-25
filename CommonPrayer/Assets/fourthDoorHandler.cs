using UnityEngine;
using System.Collections;

public class fourthDoorHandler : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Universe.candles >= 3) {
			Vector3 player = GameObject.Find("Player").transform.position;
			Vector3 myVector = transform.position;
			Vector3 yourVector = player;

			float distanceMag = Vector3.Distance(myVector, yourVector);

			if (distanceMag < 0.6f) {
				Application.LoadLevel("acceptanceScene");
			}
		}
	}
}
