using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

	private Rigidbody2D rb;
	private float velocidade;
	private GameObject[] inimigos;
    private GameObject player;
    private Animator animator;
	float incremento = 2f;

    public int vida;

	private int random;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		velocidade = 0f;
		inimigos = GameObject.FindGameObjectsWithTag ("inimigo");
        player = GameObject.FindGameObjectWithTag("Player");

		random = Random.Range (0, 0);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//rb.AddForce (Vector2.right * 200);
		foreach (GameObject inimigo in inimigos) {
            if (inimigo != null)
            {
                Comportamento(inimigo);
            }
		}


	
	}

	void Comportamento(GameObject inimigo)
	{

        

		if (inimigo.name.IndexOf("Lesma") != -1) {
			rb.velocity = new Vector2 (velocidade,0);
            animator = this.GetComponent<Animator>();
            

		}
		if (inimigo.name.IndexOf ("Mosca") != -1) {
			
			inimigo.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.2f,Mathf.Sin(1 + Time.time))*0.2f);
            

		}
		if (inimigo.name.IndexOf ("Tartaruga") != -1) {
            //Invoke("LaserTartaruga", 2f);
		}

	}

    void LaserTartaruga()
    {
        incremento += 2f;
        GameObject laser = GameObject.FindGameObjectWithTag("laser");
        //laser.transform.up = player.transform.position;
        laser.transform.localScale = new Vector3(laser.transform.localScale.x + (incremento * Time.fixedDeltaTime), laser.transform.localScale.y, laser.transform.localScale.z);
        laser.transform.position = new Vector3(laser.transform.position.x + ((incremento * Time.fixedDeltaTime) / 20), laser.transform.position.y, laser.transform.position.z);

    }


	void OnCollisionEnter2D(Collision2D other)
	{

        

		if (other.gameObject.tag == "ground") {
			velocidade = 1f;
            animator.SetBool("isGrounded",true);
		}
		if (other.gameObject.tag == "tiro") {

            vida--;

            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {

            //transform.right = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            
            GetComponent<Rigidbody2D>().AddForce((other.gameObject.transform.position - transform.position) * 100f);
        }
    }
}
