using UnityEngine;
using System.Collections;

public class ZAxisHandler : MonoBehaviour {

	// Use this for initialization
    public float zFactor = 1.2f;
    
	void Update ()
	{
	    this.transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.y-2f)*zFactor);
	}
}
