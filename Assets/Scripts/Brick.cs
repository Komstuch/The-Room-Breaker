using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public AudioClip ahaha;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable){
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length+1;
		if(timesHit >= maxHits){
			KillBricks();
			AudioSource.PlayClipAtPoint (crack, transform.position, 1f);
			PuffSmoke();
			Destroy(gameObject);
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
			AudioSource.PlayClipAtPoint (ahaha, transform.position, 1f);
		}
	
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void KillBricks(){
		breakableCount--;
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit-1;
		if (hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick Sprite Missing");		
		}
	}
	
	// TODO Remove this method once we actually can win!
	void SimulateWin(){
		levelManager.LoadNextLevel();
	
	}
}

