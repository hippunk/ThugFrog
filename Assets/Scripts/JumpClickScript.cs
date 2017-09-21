using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpClickScript : MonoBehaviour {

	public float maxRay = 4.0f;

	public GameObject feedbackVectPrefab;
	private GameObject feedbackVect;
	public float jumpMultiplier = 2;
	private Vector2 mouseImpact;
	private Vector2 mouseDest;
	private bool drag = false;
	public Vector2 centerVectDebug;
	public Vector2 jumpVect;
	public Vector2 maxVect; //Changer max vect en norme max pour circulaire
	private GameObject centerDebug;
	public Vector2 circleWrappedVect;


	// Use this for initialization
	void Start () {
		centerDebug = new GameObject ();
		centerDebug.transform.position = Vector2.zero;
		centerDebug.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Click");

			drag = true;
			mouseImpact = Input.mousePosition;
			feedbackVect = Instantiate (feedbackVectPrefab,transform.position,Quaternion.identity,transform);

		}

		if (drag == true) {
			//Revoir calcul vecteur saut.

			//Draw vecteur saut
			Debug.Log ("Drag");
			mouseDest = Input.mousePosition;
			circleWrappedVect = (mouseDest - mouseImpact).normalized ;
			float vectMagnitude = (mouseDest - mouseImpact).magnitude;

			//jumpVect = new Vector2 (circleWrappedVect.x, circleWrappedVect.y);
			jumpVect = circleWrappedVect* Mathf.Min(vectMagnitude,maxRay);	//with vect magnitude multiplier & limiter

			//Algo : 


			//Centre Lerp
			Vector2 vectCenter = Vector2.Lerp(Vector2.zero,jumpVect*-0.25f,0.5f);

			//Center Debug

			centerDebug.name = "centerDebug";
			centerDebug.transform.localPosition = vectCenter;
			feedbackVect.transform.localPosition = vectCenter;

			//taille : norme
			float length = jumpVect.magnitude;

			centerVectDebug = new Vector2 (feedbackVect.transform.localScale.x, length);
			centerDebug.transform.localScale = new Vector2(feedbackVect.transform.localScale.x,length); 
			feedbackVect.transform.localScale = new Vector2(feedbackVect.transform.localScale.x,length*0.2f); 
			//rotation, def par vecteur, calcul ?
			feedbackVect.transform.up = transform.position - feedbackVect.transform.position;
			centerDebug.transform.up = transform.position - feedbackVect.transform.position;
		
		}

		if (Input.GetMouseButtonUp (0)) {
			Debug.Log ("Release");
			Rigidbody2D frogBody = GetComponent<Rigidbody2D> ();

			drag = false;
			mouseDest = Input.mousePosition;

			frogBody.AddForce (-1.0f*jumpVect*jumpMultiplier,ForceMode2D.Force);
			Destroy (feedbackVect);
			//Destroy (centerDebug);
			GetComponent<FrogAudioController>().playSound();
		
		}
			
	}

	private void drawVectFeedback(Vector2 origin,Vector2 dest){
		
	}

	private Vector2 wrapVector(Vector2 vect){
		return Vector2.Min (maxVect, Vector2.Max (-maxVect, vect));
	
	}

	private Vector2 wrapVectorCircle(Vector2 vect){
		return Vector2.Min (maxVect, Vector2.Max (-maxVect, vect));

	}
}
