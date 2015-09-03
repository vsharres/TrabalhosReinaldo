using UnityEngine;
using System.Collections;

public class JogadorCamera : MonoBehaviour {

	public GameObject jogador;
    public float velInterp = 4.0f;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = new Vector3(Mathf.Lerp(transform.position.x, jogador.transform.position.x, velInterp),
          this.transform.position.y, -2.0f); 
	
	}
}

