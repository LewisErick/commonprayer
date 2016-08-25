using UnityEngine;
using System.Collections;

public class GlobalController : MonoBehaviour {

	//Attributes
	public int level;

	//Methods
	public void GameOver(){
		//Game Over
	}

	public void NextLevel(){
		//Next Level
	}
	// Use this for initialization
	void Start () {
		level = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getLevel() {
		return level;
	}

	public void performDamage(EnemyHanlder g, int dmg) {
		if (g.getHealth() - dmg >= 0)
			g.setHealth(g.getHealth() - dmg);
	}
}
