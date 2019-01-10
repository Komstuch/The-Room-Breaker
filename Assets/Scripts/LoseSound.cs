using UnityEngine;
using System.Collections;

public class LoseSound : MonoBehaviour {

	public AudioClip looseSound;
	
	void Awake(){
		
		AudioSource.PlayClipAtPoint(looseSound, transform.position, 2f);
		
	}
}
