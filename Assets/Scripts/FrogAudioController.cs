using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class FrogAudioController : MonoBehaviour {

	public List<AudioClip> sfxs; 
	private AudioSource source;


	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		//source.clip = sfxs [0];
	}
	
	// Update is called once per frame

	public void playSound(){
		int index = UnityEngine.Random.Range (0,sfxs.Count-1);
		source.clip = sfxs [index];
		source.Play ();
	}
}
