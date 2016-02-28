using UnityEngine;
using System.Collections;

public class fortBehavior : MonoBehaviour {

	public float fortHealth = 100.0f;


	void Update () {
		if (fortHealth <= 0.0f) {
			Destroy (this.gameObject);
			global.playState = 2;
		}
	}
	
	void BlowUp (float damageTaken) {
		fortHealth -= damageTaken;
		Debug.Log ("Fort Hit");
	}
}
