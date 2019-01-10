using UnityEngine;
using System.Collections;

public class WinSound : MonoBehaviour {

	public AudioClip winSound;
	
	void Awake(){
		
		AudioSource.PlayClipAtPoint(winSound, transform.position, 2f);
		
	}
}
