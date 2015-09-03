using UnityEngine;
using UnityEditor.VersionControl;

public class Move : MonoBehaviour {

	WheelJoint2D[] rodas;
	public float velocidade;
	JointMotor2D motorJoint;

	// Use this for initialization
	void Start () {


		motorJoint.maxMotorTorque = 1000f;
		rodas = GetComponents<WheelJoint2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {

        //if (!Jogador.EstaVivo())
        //{
        //    Application.LoadLevel("Game");
        //}

		if (Input.GetAxis ("Horizontal") > 0) {
			motorJoint.motorSpeed = -velocidade;
			for (int i = 0; i<rodas.Length; i++) {
				rodas [i].motor = motorJoint;
			}

		} else if (Input.GetAxis ("Horizontal") < 0) {
			motorJoint.motorSpeed = velocidade;
			for (int i = 0; i<rodas.Length; i++) {
				rodas [i].motor = motorJoint;
			}	
		} else {
			motorJoint.motorSpeed = 0;
			for (int i = 0; i<rodas.Length; i++) {
				rodas [i].motor = motorJoint;
			}
		}
	}

    

}
