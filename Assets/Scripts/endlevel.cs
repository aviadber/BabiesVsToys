using UnityEngine;
using System.Collections;

public class endlevel : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.x > 146)
            Application.LoadLevel(0);
	        
	}
}
