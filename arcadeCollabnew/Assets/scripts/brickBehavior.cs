using UnityEngine;
using System.Collections;

public class brickBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Explosion") {
			global.AddExplosionForce (this.GetComponent<Rigidbody2D>(), -2000.0f, other.transform.position, 0.5f);
		}
	}
}
