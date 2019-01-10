using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	public static int livesRemaining; 
	public int maxLives;
	private LevelManager levelManager;

	void Awake(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		if(Application.loadedLevelName == "Start Menu"){

			livesRemaining = Mathf.Clamp(maxLives, 1, 16);;
		}
	}
	
	public void LooseLife(){
		livesRemaining--;
		print (livesRemaining);
		if(livesRemaining <= 0){
			livesRemaining = maxLives;
			levelManager.LoadLevel("Loose Screen");
		} else {
			
			Application.LoadLevel(Application.loadedLevel);
		}	
	}
}
