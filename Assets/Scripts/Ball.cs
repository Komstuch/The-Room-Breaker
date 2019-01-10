using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	public AudioClip hiMark;
	public AudioClip ahaha;
	
	// Use this for initialization
	public void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position-paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
		// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position+paddleToBallVector;
			
			//Wait for the mouse press to launch
			if(Input.GetMouseButtonDown(0)){
				print("Mouse clicked, launch ball!");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(2f, 10f);
				this.rigidbody2D.angularVelocity = 100f;
			}
		}	
	}
	
	void OnCollisionEnter2D(Collision2D col){
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.3f), Random.Range(0f, 0.3f));
		float tweakAngVel = Random.Range (-50f, 50f);
	
		// Play the sound if hits something unbreakable
		if(hasStarted){
			if(col.gameObject.tag != "Breakable" && col.gameObject.tag != "Player"){
				AudioSource.PlayClipAtPoint(ahaha, transform.position);
			}
			if(col.gameObject.tag == "Player"){
				AudioSource.PlayClipAtPoint(hiMark, transform.position);
			
			}
			rigidbody2D.velocity += tweak;
			rigidbody2D.angularVelocity += tweakAngVel;
		}
	}
}
