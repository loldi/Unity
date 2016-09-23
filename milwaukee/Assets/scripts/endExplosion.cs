using UnityEngine;
using System.Collections;

public class endExplosion : MonoBehaviour {

	private float duration = 4.5f;
	private float colliderDisable = 1.0f;
	private float endTime;
	private float disableTime;
	// Use this for initialization
	void Start () {
		endTime = Time.time + duration;
		disableTime = Time.time + colliderDisable;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > endTime) {
			Destroy (this.gameObject);
		}
		if (Time.time > disableTime) {
			this.GetComponent<CircleCollider2D>().enabled = false;
		}
	}

}
