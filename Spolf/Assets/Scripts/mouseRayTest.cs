using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mouseRayTest : MonoBehaviour {

	public Vector3 mouseOrigin;
	public Vector3 currentPos;
	public Vector3 ballOrigin;

	public RaycastHit2D line;
	public Vector3 forceDir;

	public bool isPanning;
	public bool releasedShot;

	public Rigidbody2D ball;
	public GameObject ballPos;

	public float magnitude;

	public LineRenderer shotDir;
	public bool ballShot;

	public Text text;
	public Text totalText;

	public float score;
	public float totalScore;


	void Awake(){
	
	}

	void Start () {
		ball.isKinematic = true;
		shotDir = GetComponent<LineRenderer> ();
		ballOrigin = ballPos.transform.position;
		totalText.text = "0";

		
	}
	
	void Update () {
		text.text = score.ToString();

			if (Input.GetMouseButtonDown (0)) {
				mouseOrigin = Camera.main.ScreenToWorldPoint (Input.mousePosition);  
				mouseOrigin.z = 0f;
				isPanning = true;
			} else if (isPanning) {
				currentPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				currentPos.z = 0f;
				shotDir.SetPosition (0, ballPos.transform.position);
				shotDir.SetPosition (1, ballPos.transform.position + forceDir);
				Debug.DrawLine (mouseOrigin, currentPos, Color.white);
				Debug.DrawLine (ballPos.transform.position, ballPos.transform.position + forceDir, Color.white);
				forceDir = mouseOrigin - currentPos;
				magnitude = Mathf.Clamp (forceDir.magnitude, 1f, 4.5f);

			}

			if (Input.GetMouseButtonUp (0)) {
				isPanning = false;
				ball.isKinematic = false;
				ball.AddForce (forceDir * magnitude * 15);
				shotDir.enabled = false;
				ballShot = true;
				score += 1;
			}

		if (!ballPos.GetComponent<Renderer> ().isVisible && ballShot) {
			ballPos.transform.position = ballOrigin;
			ball.isKinematic = true;
			shotDir.enabled = true;
			shotDir.SetPosition (0, Vector3.zero);
			shotDir.SetPosition (1, Vector3.zero);
			ballShot = false;
		}

		if (ballBehavior.ballInHole == true) {
			ballPos.transform.position = ballOrigin;
			ball.isKinematic = true;
			shotDir.enabled = true;
			shotDir.SetPosition (0, Vector3.zero);
			shotDir.SetPosition (1, Vector3.zero);
			ballShot = false;
			ballBehavior.ballInHole = false;
			totalScore = totalScore + score;
			totalText.text = totalScore.ToString ();
			score = 0;
		}
	}
}


	//click - set a variable = to mousePosition at the click 
	//onmousedrag - set a variable to the difference between the origin position and the current position (abs valu so no negative)
	//draw a ray between these locations
	//get direction/mag of ray
	//on release, apply vector force to game object using direction/mag of the ray

