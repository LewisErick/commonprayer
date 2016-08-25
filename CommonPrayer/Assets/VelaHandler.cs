using UnityEngine;
using System.Collections;

public class VelaHandler : MonoBehaviour {

	public int num;
	// Use this for initialization
	void Start () {
		if (Universe.candles >= num) {

		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
