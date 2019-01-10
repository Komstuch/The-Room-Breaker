using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject life;
	
	public void LoadLevel(string name){
		Debug.Log("Level load requested for " + name);
		Application.LoadLevel(name);		
		Brick.breakableCount = 0;
	}
	
	public void QuitRequest(){
		Debug.Log("Quit requested");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount<=0){
			LoadNextLevel();
		}	
	}
	
	
	void Start(){

		if(Application.loadedLevelName.Substring(0, 5) == "Level"){
			Debug.Log("Lives: " + LifeManager.livesRemaining);		
			//Spawn as many "life" images as curren remaining lifes
			Vector3 lifePosition = life.transform.position;
			for(int i = 0; i <= LifeManager.livesRemaining - 2 ; i++){
				lifePosition += new Vector3(0.4f, 0f, 0f);
			 	GameObject.Instantiate(life, lifePosition, Quaternion.identity);
				Debug.Log("Spawn object " + i + " At position " + lifePosition);	 
			}
		}
	}
	
}
