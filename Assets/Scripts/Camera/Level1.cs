using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {
	//public GameObject cam;
	public float rightBorder = 0f;
	public Vector3 leftBorder;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		leftBorder = transform.position;

		if (transform.position.x < 1.6f) {
			leftBorder.x = 1.6f;
			transform.position = leftBorder;//new Vector3(1.6f,0f,0f);
		}
		//cam.transform.Translate ();
	}
}
