using UnityEngine;
using System.Collections;

public class PointCollider : MonoBehaviour {

	// Use this for initialization
  
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        GameManager.DisablePoint(other.gameObject.name);

    }
    
    void OnTriggerExit(Collider other)
    {
        GameManager.EnablePoint(other.gameObject.name);


    }
}
