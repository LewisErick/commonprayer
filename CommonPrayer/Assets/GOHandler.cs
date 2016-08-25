using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GOHandler : MonoBehaviour {

	private bool goTo;
	private int cutsceneTimer;
	// Use this for initialization
	void Start () {
		goTo = false;
		cutsceneTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
			goTo = true;
		if (goTo) {
			if (cutsceneTimer >= 0 && cutsceneTimer <= 100) {
				Image imageScreen = GameObject.Find ("TintScreen").GetComponent<Image>();
				imageScreen.color = new Color (0, 0, 0, (cutsceneTimer/100.0f));
			}
			if (cutsceneTimer >= 200) {
				Application.LoadLevel("Lobby");
			}
			cutsceneTimer += 1;
		}
	}
}
