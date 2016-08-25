using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cutscene2 : MonoBehaviour {

	private int cutsceneTimer;
	public RuntimeAnimatorController sTalk;
	// Use this for initialization
	void Start () {
		cutsceneTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (cutsceneTimer >= 0 && cutsceneTimer <= 100) {
			Image imageScreen = GameObject.Find ("TintScreen").GetComponent<Image>();
			imageScreen.color = new Color (0, 0, 0, 1-(cutsceneTimer/100.0f));
		}
		cutsceneTimer += 1;
	}
}
