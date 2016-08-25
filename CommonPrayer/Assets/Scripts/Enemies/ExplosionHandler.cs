using UnityEngine;
using System.Collections;

public class ExplosionHandler : MonoBehaviour {

	public Sprite exploSprite;
	public RuntimeAnimatorController exploAnim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void explode() {
		GetComponent<SpriteRenderer>().sprite = exploSprite;
		GetComponent<Animator>().runtimeAnimatorController = exploAnim;
		Debug.Log("Explosion succeeded.");
	}
}
