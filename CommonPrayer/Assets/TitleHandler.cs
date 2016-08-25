using UnityEngine;
using System.Collections;

public class TitleHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			GetComponent<AudioSource>().Stop();
			Application.LoadLevel("introScene");
		}
	}
}
