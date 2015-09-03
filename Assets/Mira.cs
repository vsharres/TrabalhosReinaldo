using UnityEngine;
using System.Collections;

public class Mira : MonoBehaviour {

	Camera cam;
	public Vector3 mousePosition;

	Vector3 thisPosition;
	Vector3 mouse;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		//thisPosition = new Vector3 (transform.position.x,transform.position.y,0);
		mousePosition = new Vector3 (mousePosition.x,mousePosition.y+0.1f,0);



		if (mousePosition.x > 0) {

			transform.right = mousePosition;
			//transform.eulerAngles = new Vector3(transform.rotation.x,180,transform.rotation.z);
			transform.localScale = new Vector3(-1,1,1);
		} else {
			transform.localScale = new Vector3(1,1,1);
			transform.right = -mousePosition;

		}

		//Debug.Log (mousePosition);
	}
}
