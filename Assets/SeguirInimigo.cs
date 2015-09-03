using UnityEngine;
using System.Collections;

public class SeguirInimigo : MonoBehaviour {

	private float forcaTiro;

	// Use this for initialization
	void Start () {
		forcaTiro = 40f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log("Inimigo encontrado");
		if (other.gameObject.tag == "inimigo") {
			Debug.Log("Inimigo encontrado");
			this.GetComponent<Rigidbody2D>().AddForce(other.gameObject.transform.position * forcaTiro);
		}
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Destroy (this.gameObject);
		
	}
}
