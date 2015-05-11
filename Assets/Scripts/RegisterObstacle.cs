using UnityEngine;
using System.Collections;

public class RegisterObstacle : MonoBehaviour {
    private bool isRegistered = false;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (!isRegistered)
        {
            print("registering Obstacle");
            GameManager.registerObstacle(this.gameObject);
            isRegistered = true;
        }
	}
}
