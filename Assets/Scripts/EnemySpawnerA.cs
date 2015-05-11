using UnityEngine;
using System.Collections;
using Random = System.Random;

public class EnemySpawnerA : MonoBehaviour {
    //type of enemies
    public GameObject typeA, typeB, typeC, typeD;
    //*********************************************
    public bool enabled ;
    public float enemySpawnInterval;
    private float startTime;
    private Vector3 pointA, pointB, pointC, pointD;

   



	// Use this for initialization
	void Start ()
	{
     
	    setUpPoints();
	    SpawnEnemies();
        startTime = 0;
        
	}



    // Update is called once per frame
	void Update ()
	{
	    startTime += Time.deltaTime;
	    if (startTime >= enemySpawnInterval)
	    {
	        SpawnEnemies();
	        startTime = 0;

	    }
	}

    private void setUpPoints()
    {
        pointA = new Vector3(this.transform.position.x-1, this.transform.position.y + 3, this.transform.position.z);
        pointB = new Vector3(this.transform.position.x+1, this.transform.position.y + 2, this.transform.position.z);
        pointC = new Vector3(this.transform.position.x+0.5f, this.transform.position.y + 1, this.transform.position.z);
        pointD = new Vector3(this.transform.position.x-0.5f, this.transform.position.y, this.transform.position.z);
    }
    private void SpawnEnemies()
    {
        if (enabled)
        {
            if (typeA != null) Instantiate(typeA, pointA, this.transform.rotation);
            if (typeB != null) Instantiate(typeB, pointB, this.transform.rotation);
            if (typeC != null) Instantiate(typeC, pointC, this.transform.rotation);
            if (typeD != null) Instantiate(typeD, pointD, this.transform.rotation);
        }

    }

}
