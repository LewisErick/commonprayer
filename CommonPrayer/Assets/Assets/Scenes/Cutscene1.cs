using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cutscene1 : MonoBehaviour {

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
		if (cutsceneTimer == 101) {
			GameObject.Find("Player").GetComponent<PlayerMovHUB>().movePlayer(-0.025f, 0.0135f);
		}
		if (cutsceneTimer == 151) {
			GameObject.Find("Player").GetComponent<PlayerMovHUB>().movePlayer(0f, 0.0125f);
		}
		if (cutsceneTimer == 200) {
			GameObject.Find("Player").GetComponent<PlayerMovHUB>().movePlayer(0.0125f, 0.0125f);
		}
		if (cutsceneTimer == 300) {
			GameObject.Find("Player").GetComponent<PlayerMovHUB>().movePlayer(0f, 0f);
		}
		if (cutsceneTimer == 500) {
			Destroy(GameObject.Find("Entorno"));
		}
		if (cutsceneTimer == 650) {
			GameObject.Find("LaughObject").GetComponent<AudioSource>().Play();
			GameObject.Find("Catrina").GetComponent<SpriteRenderer>().enabled = true;
		}
		if (cutsceneTimer == 720) {
			GameObject.Find("LaughObject").GetComponent<AudioSource>().Stop();
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = null;
		}
		if (cutsceneTimer == 850) {
			GameObject.Find("CutText").GetComponent<Text>().text = "Greetings";
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = sTalk;
		}
		if (cutsceneTimer == 900) {
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = null;
		}
		if (cutsceneTimer == 950) {
			GameObject.Find("CutText").GetComponent<Text>().text = "It seems you've come here out of your own accord.";
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = sTalk;
		}
		if (cutsceneTimer == 1000) {
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = null;
		}
		if (cutsceneTimer == 1100) {
			GameObject.Find("LaughObject").GetComponent<AudioSource>().Play();
			GameObject.Find("CutText").GetComponent<Text>().text = "Beware,";
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = sTalk;
		}
		if (cutsceneTimer == 1125) {
			GameObject.Find("LaughObject").GetComponent<AudioSource>().Stop();
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = null;
		}
		if (cutsceneTimer == 1200) {
			GameObject.Find("CutText").GetComponent<Text>().text = "of the results of your desire";
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = sTalk;
		}
		if (cutsceneTimer == 1270) {
			GameObject.Find("CutText").GetComponent<Text>().text = "to be above consequences.";
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = sTalk;
		}
		if (cutsceneTimer == 1350) {
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = null;
			GameObject.Find("CutText").GetComponent<Text>().text = "";
		}
		if (cutsceneTimer == 1500) {
			GameObject.Find("CutText").GetComponent<Text>().text = "You've been warned.";
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = sTalk;
		}
		if (cutsceneTimer == 1600) {
			GameObject.Find("Catrina").GetComponent<Animator>().runtimeAnimatorController = null;
			GameObject.Find("CutText").GetComponent<Text>().text = "";
		}
		if (cutsceneTimer == 1800) {
			GameObject.Find("LaughObject").GetComponent<AudioSource>().Play();
			GameObject.Find("Catrina").GetComponent<SpriteRenderer>().enabled = false;
		}
		if (cutsceneTimer == 1900) {
			GameObject.Find("LaughObject").GetComponent<AudioSource>().Stop();
		}
		if (cutsceneTimer == 2050) {
			Application.LoadLevel("Lobby");
		}
		cutsceneTimer += 1;
	}
}
