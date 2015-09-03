using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

	private Rigidbody2D rb;
	private float velocidade;
	private GameObject[] inimigos;
	float incremento = 2f;

	private int random;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		velocidade = 0f;
		inimigos = GameObject.FindGameObjectsWithTag ("inimigo");


		random = Random.Range (0, 1);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//rb.AddForce (Vector2.right * 200);
		foreach (GameObject inimigo in inimigos) {
			Comportamento (inimigo);
		}


	
	}

	void Comportamento(GameObject inimigo)
	{



		if (inimigo.name.IndexOf("Lesma") != -1) {
			rb.velocity = new Vector2 (velocidade,0);
		}
		if (inimigo.name.IndexOf ("Mosca") != -1) {
			Debug.Log(Mathf.Sin(random + Time.time));
			inimigo.GetComponent<Rigidbody2D>().velocity = (new Vector2(2f,Mathf.Sin(random + Time.time))*0.2f);

		}
		if (inimigo.name.IndexOf ("Tartaruga") != -1) {
			incremento+= 0.0001f;
			GameObject laser = GameObject.FindGameObjectWithTag("laser");//(GameObject)Instantiate(Resources.Load<GameObject>("Laser"),inimigo.transform.position,Quaternion.identity);
			laser.transform.localScale = new Vector3(laser.transform.localScale.x + (incremento *Time.fixedDeltaTime) ,laser.transform.localScale.y,laser.transform.localScale.z     );
		}

	}




	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") {
			velocidade = 1f;
		}
		if (other.gameObject.tag == "tiro") {
			Destroy(this.gameObject);
		}
	}
}
