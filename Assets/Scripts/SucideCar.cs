using UnityEditorInternal;
using UnityEngine;
using System.Collections;

public class SucideCar : MonoBehaviour
{
    public float carSpeed;
    public float speedScaler;
    public GameObject babyGameObject;
    public float distanceToExplode;
    public GameObject explosionFX;
    public int demageAmount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Vector3.Distance(transform.position, babyGameObject.transform.position) <= distanceToExplode)
	    {
	        Boom();
	    }
	    transform.position = new Vector3(transform.position.x - carSpeed*Time.deltaTime, transform.position.y
	        , transform.position.z);
	    carSpeed = carSpeed*speedScaler;
	}

    private void Boom()
    {
        Instantiate(explosionFX, this.transform.position, this.transform.rotation);
        GameManager.playObstacleExplosionSfx();
        GameManager.attackThePlayer(demageAmount);
        Destroy(this.gameObject);
    }
}
