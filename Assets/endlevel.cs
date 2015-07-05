using UnityEngine;
using System.Collections;

public class endlevel : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (player.transform.position.x > 146)
            Application.LoadLevel(0);
	        
	}
}
