using UnityEngine;
using System.Collections;

public class ManagerInimigo : MonoBehaviour {

	public GameObject inimigo;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		//if (Input.GetMouseButtonDown (1)) {
            if (Random.Range(0, 1500) == 1)
            {
                inimigo = (GameObject)Instantiate(Resources.Load<GameObject>("InimigoMosca"), this.transform.position, Quaternion.Euler(new Vector3(0,180,0)));
                inimigo.tag = "inimigo";
            }

            if (Random.Range(0, 700) == 1)
            {
                inimigo = (GameObject)Instantiate(Resources.Load<GameObject>("InimigoLesma"), this.transform.position, Quaternion.Euler(new Vector3(0,180,0)));
                inimigo.tag = "inimigo";
            }
            

		//}
	
	}
}
