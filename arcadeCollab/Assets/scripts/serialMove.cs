using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class serialMove : MonoBehaviour {

	SerialPort stream = new SerialPort("COM3", 115200);


	public GameObject tank1;
	public GameObject tank2;

	public tankBehavior tankBehavior1;
	public tankBehavior tankBehavior2;

	private int crankSpeed1 = 0;
	private int crankSpeed2 = 0;
	private int crankSpeed3 = 0;
	private int crankSpeed4 = 0;

	private float tankSpeed1 = 0;
	private float tankSpeed2 = 0;
	private float turnPower1 = 0;
	private float turnPower2 = 0;

	private float turnFactor = 0.01f;
	private float speedFactor = 0.05f;
		
	void Start () {
		string[] portList= SerialPort.GetPortNames();
		for (int i = 0; i < portList.Length; i++) {
			Debug.Log (portList[i]);
		}
	}
	
	

	void Update () {


		try{
			stream.Open();
			string serialInput = stream.ReadLine();
			
			string[] strEul= serialInput.Split (',');
			if (strEul.Length == 5) {

				crankSpeed1 = int.Parse(strEul[4]);
				crankSpeed2 = int.Parse(strEul[3]);
				crankSpeed3 = int.Parse(strEul[2]);
				crankSpeed4 = int.Parse(strEul[1]);
				//Debug.Log (serialInput);
				//int.Parse(strEul[2]

				crankSpeed1 = crankSpeed1 - 511;
				crankSpeed2 = crankSpeed2 - 511;
				crankSpeed3 = crankSpeed3 - 511;
				crankSpeed4 = crankSpeed4 - 511;
			}
			
			stream.Close ();
		}
		catch{
			Debug.Log("Could not open serial port");
			
		}

		tankSpeed1 = (crankSpeed1 + crankSpeed2) / 2.0f;
		tankSpeed2 = (crankSpeed3 + crankSpeed4) / 2.0f;
		turnPower1 = (crankSpeed1 - crankSpeed2) * turnFactor;
		turnPower2 = (crankSpeed3 - crankSpeed4) * turnFactor; 
 


		if (tankBehavior1.dead) {
			tankSpeed1 = 0;
		}
		if (tankBehavior2.dead) {
			tankSpeed2 = 0;
		}
		if (global.playState == 1) {
			tank1.transform.Rotate (Vector3.forward * turnPower1);
			tank2.transform.Rotate (Vector3.forward * turnPower2);
			tank1.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector3.right * tankSpeed1 * speedFactor);
			tank2.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector3.right * tankSpeed2 * speedFactor);
		}

	}
	
}
