using UnityEngine;
using System.Collections;

public class ballBehavior : MonoBehaviour {
	public static bool ballInHole;

	// Use this for initialization
	void Start () {
		ballInHole = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
	
		if (other.gameObject.name == "Hole") {
		
			ballInHole = true;
			print ("ball in hole");
		
		}
	
	
	}
}
