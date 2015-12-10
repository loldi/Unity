using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour {
	
	public Rigidbody2D bulletYellow;
	private float attackSpeed = 2.0f;
	public float coolDown1 = 0;
	public float coolDown2 = 0;
	public float bulletSpeed = 500;

	public GameObject tank1;
	public GameObject tank2;
	public tankBehavior tankBehavior1;
	public tankBehavior tankBehavior2;
	public Camera camera1;
	public Camera camera2;
	private float camShake1 = 0;
	private float camShake2 = 0;
	private float shakeAmount = 0.05f;
	private float shakeDecay = 3.0f;
	private float recoil = 100.0f ;
	public float recoilTwist = 0.005f;

	public fortBehavior fortBehavior1;
	public fortBehavior fortBehavior2;

	public Camera splashCam;
	public GameObject startScreen;
	public GameObject greenWin;
	public GameObject blueWin;

	public GameObject wallPos1;
	public GameObject wallPos2;
	public GameObject wallPos3;

	// Update is called once per frame
	void Update () {
		camShake1 = CameraShake (camera1, camShake1);
		camShake2 = CameraShake (camera2, camShake2);
		if ((Time.time >= coolDown1) && (!tankBehavior1.dead) && (global.playState == 1)) {
			if(Input.GetKeyDown (KeyCode.LeftControl)) {
				coolDown1 = Fire(tank1, coolDown1);
				camShake1 = 1.0f;
				tank2.GetComponent<AudioSource>().Play();
			}
		}

		if ((Time.time >= coolDown2) && (!tankBehavior2.dead) && (global.playState == 1)) {
			if(Input.GetKeyDown (KeyCode.RightControl)) {
				camShake2 = 1.0f;
				coolDown2 = Fire(tank2, coolDown2);
				tank2.GetComponent<AudioSource>().Play();
			}
		}

		if (global.playState == 0) {
			if ((Input.GetKeyDown (KeyCode.LeftControl)) || (Input.GetKeyDown (KeyCode.RightControl))) {
				splashCam.enabled = false;
				startScreen.GetComponent<SpriteRenderer>().enabled = false;

				global.playState = 1;
			}
			if(global.wallPos == 1){
				Instantiate(wallPos1, new Vector3(0,0,0), Quaternion.identity);
				wallPos1.SetActive(true);
				global.wallPos = 0;
			} else if(global.wallPos == 2){
				Instantiate(wallPos2, new Vector3(0,0,0), Quaternion.identity);
				wallPos2.SetActive(true);
				global.wallPos = 0;
			} else if(global.wallPos == 3){
				Instantiate(wallPos3, new Vector3(0,0,0), Quaternion.identity);
				wallPos3.SetActive(true);
				global.wallPos = 0;
			}

		}

		if (global.playState == 2) {
			splashCam.enabled = true;

			if (fortBehavior1.fortHealth <= 0) {
				Debug.Log (" Player 2 - You win!");
				blueWin.GetComponent<SpriteRenderer>().enabled = true;
			}
			if (fortBehavior2.fortHealth <= 0) {
				Debug.Log (" Player 1 - You win!");
				greenWin.GetComponent<SpriteRenderer>().enabled = true;
			}
			if ((Input.GetKeyDown (KeyCode.LeftControl)) || (Input.GetKeyDown (KeyCode.RightControl))) {
				Debug.Log (" Reload");
				global.playState = 0;
				Application.LoadLevel(0);
			}
		}
	}
	
	float Fire(GameObject tank, float coolDown)
	{
		//Rigidbody2D bPrefab = Instantiate(bulletPrefab,transform.position,Quaternion.identity) as Rigidbody2D;

		Quaternion tankRotationOffset = tank.transform.rotation;
		tankRotationOffset.eulerAngles = new Vector3 (tank.transform.rotation.eulerAngles.x, tank.transform.rotation.eulerAngles.y, tank.transform.rotation.eulerAngles.z - 90.0f);
		Rigidbody2D bPrefab = Instantiate(bulletYellow, new Vector3(tank.transform.position.x, tank.transform.position.y, tank.transform.position.z), tankRotationOffset) as Rigidbody2D;
		bPrefab.transform.parent = tank.transform;
		bPrefab.transform.localPosition = new Vector3 (0.7f, 0.0f, 0.0f);
		bPrefab.transform.parent = null;
		bPrefab.AddForce(tank.transform.right * bulletSpeed);
		
		coolDown = Time.time + attackSpeed;

		tank.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector2.left * recoil);
		//tank.GetComponent<Rigidbody2D> ().AddTorque (Random.Range(-recoilTwist, recoilTwist));


		return(coolDown);
	}

	float CameraShake (Camera cam, float camShake) {
		if (camShake > 0) {
			Vector2 newCamLocation = Random.insideUnitCircle * shakeAmount;
			cam.transform.localPosition = new Vector3 (newCamLocation.x, newCamLocation.y, 0.0f);
			camShake -= Time.deltaTime * shakeDecay;
		} else {
			camShake = 0.0f;
		}
		return camShake;
	}
}