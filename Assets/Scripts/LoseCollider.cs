using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LifeManager lifeManager;

	void Start(){
		lifeManager = GameObject.FindObjectOfType<LifeManager>();

	}

	void OnTriggerEnter2D (Collider2D trigger){
		lifeManager.LooseLife();
		Brick.breakableCount = 0;

	}
	
	void OnCollisionEnter2D (Collision2D collision){
		print ("Collision");
	}
}
