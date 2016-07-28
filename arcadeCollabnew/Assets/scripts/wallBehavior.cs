using UnityEngine;
using System.Collections;

public class wallBehavior : MonoBehaviour {

	public float wallHealth = 100.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (wallHealth <= 0.0f) {

			Destroy (this.gameObject);
		}
	}
	
	void BlowUp (float damageTaken) {
		wallHealth -= damageTaken;
	}
}
