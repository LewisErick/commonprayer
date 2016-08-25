using UnityEngine;
using System.Collections;

public class firePowaHandler : MonoBehaviour {

	public Sprite sExplode;
	public RuntimeAnimatorController aExplode;

	private int destroyWait;
	private bool gonnaDestroy = false;

	SpriteRenderer spriter;
	Animator anim;

	// Use this for initialization
	void Start () {
		destroyWait = 200;
		spriter = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}
	public void initializeFire() {
		gonnaDestroy = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.3f, 0, 0);
		if (destroyWait < 0) {
			destroyWait -= 1;
		} else {
			if (gonnaDestroy) {
				Destroy(gameObject);
			}
		}
	}

	public void explode () {
		spriter.sprite = sExplode;
		anim.runtimeAnimatorController = aExplode;
		destroyWait = 50;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		//Debug.Log(coll.gameObject.tag);
    }
}
