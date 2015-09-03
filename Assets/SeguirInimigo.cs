using UnityEngine;
using System.Collections;

public class SeguirInimigo : MonoBehaviour {

	private float forcaTiro;

    
	// Use this for initialization
	void Start () {
		forcaTiro = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	void OnTriggerStay2D(Collider2D other)
	{
		//Debug.Log("Inimigo encontrado");
		if (other.gameObject.tag == "inimigo") {
            
			Debug.Log("Inimigo encontrado");
            this.transform.right = -other.gameObject.transform.position.normalized;
            this.GetComponent<Rigidbody2D>().AddForce((other.gameObject.transform.position - transform.position) * forcaTiro);
            if (GetComponentInChildren<Animator>() != null)
            {
                this.GetComponentInChildren<Animator>().SetTrigger("Detectou");
            }

            if (GameObject.FindGameObjectWithTag("impulso").transform.parent != null)
            {

                GameObject.FindGameObjectWithTag("impulso").transform.parent = null;
            }
		}
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Destroy (this.gameObject);
        if (GameObject.FindGameObjectWithTag("impulso").gameObject != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("impulso").gameObject);
        }
	}
}
