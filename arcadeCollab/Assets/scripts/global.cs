using UnityEngine;
using System.Collections;

public static class global {

	public static int playState = 0;

	public static int wallPos = Random.Range(1,4);

	public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
	{
		var dir = (body.transform.position - explosionPosition);
		float wearoff = 1 - (dir.magnitude / explosionRadius);
		body.AddForce(dir.normalized * explosionForce * wearoff);	
	}
}
