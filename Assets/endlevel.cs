using UnityEngine;
using System.Collections;

public class endlevel : MonoBehaviour {

	public float endlevelcoords;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.x > endlevelcoords)
            Application.LoadLevel(3);
	        
	}
}
