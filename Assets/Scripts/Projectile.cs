    using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private Transform startPosition;
    public float projectileSpeed;
    private float distance;
    public float rangeOfProjectile;
    public GameObject projEffect;
    private float currentTime=0;
    public int projectileDamage;
    private float distanceFromEnemy;
    public GameObject projectileHitFX;
	// Use this for initialization
	void Start ()
	{
      
	    startPosition = this.transform;
	    Instantiate(projEffect, startPosition.position, startPosition.rotation);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (transform.rotation.y == 0)
	    {
	        transform.position = new Vector3(transform.position.x + projectileSpeed*Time.deltaTime,
	            transform.position.y, transform.position.z);
	    }
	    else
	    {
            transform.position = new Vector3(transform.position.x - projectileSpeed * Time.deltaTime,
                transform.position.y, transform.position.z);
	    }
	     currentTime+=Time.deltaTime;// checks projectile flying time 
	    if (currentTime >= rangeOfProjectile)
	    {
	        Destroy(this.gameObject);
	    }
	    checkIfHit();
	}   

    public void checkIfHit()
    {
        if (GameManager.enemyList.Count > 0)
        {
            ArrayList enemyList = GameManager.GetEnemyList();
//            print("checking");
            for (int i = 0; i <enemyList.Count;i++)
            {
                GameObject enemy = (GameObject) enemyList[i];
                distanceFromEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);
                if (distanceFromEnemy <= 1.1)
                {
                    EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                    Instantiate(projectileHitFX,this.transform.position,this.transform.rotation);
                    enemyHealth.DecreaseHealth(projectileDamage);
                    Destroy(this.gameObject);
                } 
            }

        }
        if (GameManager.obstacleList.Count > 0)
        {
            ArrayList obstacleList  = GameManager.GetObstacleList();
            //            print("checking");
            for (int i = 0; i < obstacleList.Count; i++)
            {
                GameObject obs = (GameObject)obstacleList[i];
                distanceFromEnemy = Vector3.Distance(this.transform.position, obs.transform.position);
                if (distanceFromEnemy <= 1.2)
                {
                    ObstacleHealth health = obs.GetComponent<ObstacleHealth>();
                    Instantiate(projectileHitFX, this.transform.position, this.transform.rotation);
                    health.DecreaseHealth(projectileDamage);
                    Destroy(this.gameObject);
                }
            }

        }
    }
}
