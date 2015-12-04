using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

	public GameObject explosion;
	
	// Update is called once per frame
	void Update () {

		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0)
			Destroy(this.gameObject);
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			float damageDone = 100.0f;
			//Debug.Log ("Hit");
			Instantiate (explosion, other.transform.position, Quaternion.identity);
			other.gameObject.SendMessage("BlowUp", damageDone, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
	}
}
