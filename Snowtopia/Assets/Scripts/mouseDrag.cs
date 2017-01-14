using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour {

	public float panSpeed = 4.0f;
	private Vector3 mouseOrigin;
	private bool isPanning;
	private Vector3 initialPosition;
	private Vector3 initialRotation;
	private Vector3 currentPosition;
	float yRotation;
	float xRotation;
	float rotationSpeed = 200.0f;

	float scrollAxis;

	void Start(){
		initialPosition = transform.position;
		initialRotation = transform.eulerAngles;

	}
	void Update ()
	{
		currentPosition = transform.position;
		scrollAxis = Input.GetAxis ("Mouse ScrollWheel");
		if (Input.GetMouseButtonDown (0)) 
		{
			mouseOrigin = Input.mousePosition;  
			isPanning = true;
		}
		if (!Input.GetMouseButton (0)) 
		{
			isPanning = false;
		}
		//move camera on X & Y
		else if (isPanning) 
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - mouseOrigin);
			Vector3 move = new Vector3 (pos.x * -panSpeed, pos.y * -panSpeed, 0);
			Camera.main.transform.Translate (move, Space.Self);
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0 );
			transform.localPosition = new Vector3( transform.position.x, initialPosition.y, transform.position.z );
		}
		//rotate camera with mousewheel click
		if (Input.GetMouseButton(2)) {
			yRotation -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
			yRotation = Mathf.Clamp(yRotation, -80, 80);
			xRotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
			xRotation = xRotation % 360;
			transform.localEulerAngles = new Vector3(yRotation + initialRotation.x, xRotation + initialRotation.y, 0);
		}
		//zoom with scroll
		if ( Input.GetAxis("Mouse ScrollWheel") != 0) {             
			transform.Translate(Vector3.forward * Time.deltaTime * 10000f * scrollAxis, Space.Self); 
			initialPosition = transform.position;
		}
	}
}
