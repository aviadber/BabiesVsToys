using UnityEngine;
using System.Collections;

public class TrackScript : MonoBehaviour {

    public Transform camera;
    public float percent;

	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(camera.position.x * percent, 0, transform.position.z);
	}
}
