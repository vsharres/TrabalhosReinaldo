using UnityEngine;
using System.Collections;

public class ManagerInimigo : MonoBehaviour {

	public GameObject inimigo;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (1)) {

			inimigo = (GameObject)Instantiate(Resources.Load<GameObject> ("InimigoMosca"),this.transform.position,Quaternion.identity);
			inimigo.tag = "inimigo";
		}
	
	}
}
