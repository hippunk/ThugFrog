using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerScript : MonoBehaviour {

	public GameObject firstChunk;
	public List<GameObject> chunks = new List<GameObject> ();
	private Camera mainCamera;


	void Start(){
		mainCamera = Camera.main;
		Instantiate (firstChunk,this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
