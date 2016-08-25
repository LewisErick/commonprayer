using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalCut : MonoBehaviour {

	private int cutsceneTimer;
	public RuntimeAnimatorController sTalk;
	// Use this for initialization
	void Start () {
		cutsceneTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (cutsceneTimer == 0) {
			GameObject.Find("LaughObject").GetComponent<AudioSource>().Play();
			GameObject.Find("CutText").GetComponent<Text>().text = "Did you think it was going to be that easy?";
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = sTalk;
		}
		cutsceneTimer += 1;
	}
}
