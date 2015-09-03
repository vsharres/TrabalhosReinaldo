using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    GameObject player;


	// Use this for initialization
	void Start () {

        player = (GameObject)GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x >= 0.4f)
        {
            transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y + 0.9f, player.transform.position.z - 10);
        }
	}
}
