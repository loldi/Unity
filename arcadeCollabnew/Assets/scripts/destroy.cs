using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

	public GameObject explosion;
	public GameObject nonDestroyableExplosion;
	public GameObject destroyableExplosion;
	
	// Update is called once per frame
	void Update () {

		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0) { 
			//Destroy(this.gameObject); 		
		}
		if (global.playState == 2) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			float damageDone = 100.0f;
			Instantiate (explosion, other.transform.position, Quaternion.identity);
			other.gameObject.SendMessage("BlowUp", damageDone, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}

		if (other.gameObject.tag == "NonDestroyable") {
			float damageDone = 0.0f;
			//Debug.Log ("Hit");
			Instantiate (nonDestroyableExplosion, this.transform.position, Quaternion.identity);
			//other.gameObject.SendMessage("StayHere", damageDone, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
		if (other.gameObject.tag == "Destroyable") {
			float damageDone = 100.0f;
			//Debug.Log ("Hit");
			Instantiate (destroyableExplosion, this.transform.position, Quaternion.identity);
			other.gameObject.SendMessage("BlowUp", damageDone, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
		if (other.gameObject.tag == "Explosion") {
			Instantiate (nonDestroyableExplosion, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
		if (other.gameObject.tag == "Flag") {
			float damageDone = 100.0f;
			Instantiate (explosion, other.transform.position, Quaternion.identity);
			other.gameObject.SendMessage("BlowUp", damageDone, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
	}
}
