using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {

	public float rightBorder = 0f;
	public Vector3 leftBorder;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		leftBorder = transform.position;

		if (transform.position.x < 1.7f) {
			leftBorder.x = 1.7f;
			transform.position = leftBorder;
		}

	}
}
