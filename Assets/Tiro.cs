using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {

	Vector3 thisPosition;
	private GameObject obj;
	public Mira mira;


	public float forcaTiro;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		thisPosition = transform.position;

		if (Input.GetAxis("Fire1")>0 && Input.GetMouseButtonDown(0)) {
			obj = (GameObject)Instantiate(Resources.Load<GameObject>("Tiro"), thisPosition ,transform.rotation);
			obj.GetComponent<Rigidbody2D>().AddForce(mira.mousePosition.normalized * forcaTiro);
			obj.tag = "tiro";
			//Instantiate<GameObject>(obj);

		}
	
	}









}
