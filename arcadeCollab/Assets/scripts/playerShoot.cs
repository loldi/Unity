using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour {
	
	public Rigidbody2D bulletYellow;
	public float attackSpeed = 0.5f;
	public float coolDown1;
	public float coolDown2;
	public float bulletSpeed = 500;

	public GameObject tank1;
	public GameObject tank2;
	private float recoil = 20.0f ;
	public float recoilTwist = 0.005f;



	// Update is called once per frame
	void Update () 
	{
		
		if(Time.time >= coolDown1) {
			if(Input.GetKeyDown (KeyCode.LeftControl)) {
				Fire(tank1, coolDown1);
			}
		}

		if(Time.time >= coolDown2) {
			if(Input.GetKeyDown (KeyCode.RightControl)) {
			
				Fire(tank2, coolDown2);
			}
		}
	}
	
	void Fire(GameObject tank, float coolDown)
	{
		//Rigidbody2D bPrefab = Instantiate(bulletPrefab,transform.position,Quaternion.identity) as Rigidbody2D;

		Quaternion tankRotationOffset = tank.transform.rotation;
		tankRotationOffset.eulerAngles = new Vector3 (tank.transform.rotation.eulerAngles.x, tank.transform.rotation.eulerAngles.y, tank.transform.rotation.eulerAngles.z - 90.0f);
		Rigidbody2D bPrefab = Instantiate(bulletYellow, new Vector3(tank.transform.position.x, tank.transform.position.y + 1.0f, tank.transform.position.z), tankRotationOffset) as Rigidbody2D;
		bPrefab.transform.parent = tank.transform;
		bPrefab.transform.localPosition = new Vector3 (1.0f, 0.0f, 0.0f);
		bPrefab.transform.parent = null;
		bPrefab.AddForce(tank.transform.right * bulletSpeed);
		
		coolDown = Time.time + attackSpeed;

		tank.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector2.left * recoil);
		//tank.GetComponent<Rigidbody2D> ().AddTorque (Random.Range(-recoilTwist, recoilTwist));
	}
}