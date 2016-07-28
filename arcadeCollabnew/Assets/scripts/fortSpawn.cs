using UnityEngine;
using System.Collections;

public class fortSpawn : MonoBehaviour {

	public GameObject fort1;
	public GameObject fort2;
	public GameObject tank1;
	public GameObject tank2;


	// Use this for initialization
	void Start () {
		float startX = Random.Range (35, 44);
		float startY = Random.Range (-17, 17);
		fort1.transform.position = new Vector3 (-startX, -startY, fort1.transform.position.z);
		fort2.transform.position = new Vector3 (startX, startY, fort2.transform.position.z);
		tank1.transform.position = new Vector3 (fort1.transform.position.x + 5.0f, fort1.transform.position.y, fort1.transform.position.z);
		tank2.transform.position = new Vector3 (fort2.transform.position.x - 5.0f, fort2.transform.position.y, fort2.transform.position.z);

		Debug.Log ("Start");
	}
	


}
