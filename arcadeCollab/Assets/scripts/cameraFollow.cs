using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
		
	void Update () {

		transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
		//transform.rotation = target.rotation;
	}
}
