using UnityEngine;
using System.Collections;

public class tankBehavior : MonoBehaviour {

	public float tankHealth = 100.0f;
	public bool dead = false;
	private float deathDelay = 3.5f;
	public float respawnTime = 0.0f;
	private Vector3 originalPosition;
	// Use this for initialization
	void Start () {
		originalPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead && (tankHealth <= 0)) {
			this.GetComponent<SpriteRenderer> ().enabled = false;
			//this.GetComponents<BoxCollider2D> ().enabled = false;
			BoxCollider2D[] hitBoxes = this.GetComponents<BoxCollider2D> ();
			foreach (BoxCollider2D hitBox in hitBoxes) {
				hitBox.enabled = false;
			}
			dead = true;
			respawnTime = Time.time + deathDelay;


		}

		//ebug.Log (Time.time);
		if (dead && (Time.time > respawnTime)) {
			dead = false;
			//Debug.Log ("Respawn");
			this.GetComponent<SpriteRenderer> ().enabled = true;
			//this.GetComponents<BoxCollider2D> ().enabled = true;
			BoxCollider2D[] hitBoxes = this.GetComponents<BoxCollider2D> ();
			foreach (BoxCollider2D hitBox in hitBoxes) {
				hitBox.enabled = true;
			}
			tankHealth = 100.0f;
			this.transform.position = originalPosition;
		}
	}

	void BlowUp (float damageTaken) {
		tankHealth -= damageTaken;
	}
}
