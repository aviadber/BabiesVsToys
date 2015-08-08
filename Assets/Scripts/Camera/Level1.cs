using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {
	//public GameObject cam;
	public float rightBorder = 0f;
	public Vector3 leftBorder;

	// Use this for initialization
	void Start () {
		leftBorder = new Vector3 (1.6f,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < leftBorder.x)
			transform.postion = leftBorder;
		//cam.transform.Translate ();
	}
}
