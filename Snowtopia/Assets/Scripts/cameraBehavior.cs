using UnityEngine;
using System.Collections;

public class cameraBehavior : MonoBehaviour {


	public float ScrollSpeed = 15;

	public GameObject target;

	public float ScrollEdge = 0.1f;

	public float PanSpeed = 100;

	public Vector2 zoomRange = new Vector2( 1, 100 );

	public float CurrentZoom = 0;

	public float ZoomZpeed = 1;

	public float ZoomRotation = 0;

	public Vector2 zoomAngleRange = new Vector2( 0, 0 );

	public float rotateSpeed = 10;

	private Vector3 initialPosition;

	private Vector3 initialRotation;

	private Vector3 camTransform;

	private Camera camera;

	private Vector3 delta;
	private Vector3 lastPos;
	float yRotation;
	float xRotation;
	float rotationSpeed = 200.0f;

	void Start () {
		initialPosition = transform.position;      
		initialRotation = transform.eulerAngles;
		camera = GetComponent<Camera> ();
	}

	void Update () {


		if (Input.GetMouseButton(0)) {
			yRotation -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
			yRotation = Mathf.Clamp(yRotation, -80, 80);
			xRotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
			xRotation = xRotation % 360;
			transform.localEulerAngles = new Vector3(yRotation + initialRotation.x, xRotation + initialRotation.y, 0);
		}
			
			if ( Input.GetKey("d") ) {             
				transform.Translate(Vector3.right * Time.deltaTime * PanSpeed, Space.Self );   
			}
			else if ( Input.GetKey("a") ) {            
				transform.Translate(Vector3.right * Time.deltaTime * -PanSpeed, Space.Self );              
			}

			if ( Input.GetKey("w")) {            
				transform.Translate(Vector3.forward * Time.deltaTime * PanSpeed, Space.Self );             
			}
			else if ( Input.GetKey("s")) {         
				transform.Translate(Vector3.forward * Time.deltaTime * -PanSpeed, Space.Self );            
			}  

//		CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 10000 * ZoomZpeed;
//		CurrentZoom = Mathf.Clamp( CurrentZoom, zoomRange.x, zoomRange.y );

		Camera.main.fieldOfView += Input.GetAxis("Mouse ScrollWheel") * 7500 * Time.deltaTime * -1f;
		Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 10, 70);

		//transform.position = new Vector3( transform.position.x, transform.position.y - (transform.position.y - (initialPosition.y)), transform.position.z );
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0 );
	}

	void FixedUpdate()
	{
		//not necessary, just used for camera direction debugging.
		Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0.5f));
		RaycastHit hit;
		Debug.DrawRay(ray.origin, ray.direction , Color.green);
		if (Physics.Raycast (ray, out hit)) {
			target.transform.position = new Vector3 (hit.point.x, 0.0f, hit.point.z);
		} 
	}
}
