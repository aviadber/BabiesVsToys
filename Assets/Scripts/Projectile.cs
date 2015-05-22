using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float currentTime;
    private float distance;
    private float distanceFromEnemy;
    public float hitRange;
    public GameObject projEffect;
    public int projectileDamage;
    public GameObject projectileHitFX;
    public float projectileSpeed;
    public float rangeOfProjectile;
    private Transform startPosition;
    // Use this for initialization
    private void Start()
    {
        startPosition = transform;
        Instantiate(projEffect, startPosition.position, startPosition.rotation);
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.rotation.y == 0)
        {
            transform.position = new Vector3(transform.position.x + projectileSpeed*Time.deltaTime,
                transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - projectileSpeed*Time.deltaTime,
                transform.position.y, transform.position.z);
        }
        currentTime += Time.deltaTime; // checks projectile flying time 
        if (currentTime >= rangeOfProjectile)
        {
            Destroy(gameObject);
        }
        checkIfHit();
    }

    public void checkIfHit()
    {
        if (GameManager.enemyList.Count > 0)
        {
            ArrayList enemyList = GameManager.GetEnemyList();
//            print("checking");
            for (int i = 0; i < enemyList.Count; i++)
            {
                var enemy = (GameObject) enemyList[i];
                distanceFromEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceFromEnemy <= hitRange && Mathf.Abs(transform.position.z - enemy.transform.position.z) < 0.5)
                {
                    var enemyHealth = enemy.GetComponent<EnemyHealth>();
                    Instantiate(projectileHitFX, transform.position, transform.rotation);
                    GameManager.playProjectileHitSoundFx();
                    enemyHealth.DecreaseHealth(projectileDamage);
                    Destroy(gameObject);
                }
            }
        }
        if (GameManager.obstacleList.Count > 0)
        {
            ArrayList obstacleList = GameManager.GetObstacleList();
            //            print("checking");
            for (int i = 0; i < obstacleList.Count; i++)
            {
                var obs = (GameObject) obstacleList[i];
                distanceFromEnemy = Vector3.Distance(transform.position, obs.transform.position);
                if (distanceFromEnemy <= hitRange && Mathf.Abs(transform.position.z - obs.transform.position.z) < 0.5)
                {
                    var health = obs.GetComponent<ObstacleHealth>();
                    Instantiate(projectileHitFX, transform.position, transform.rotation);
                    GameManager.playProjectileHitSoundFx();
                    health.DecreaseHealth(projectileDamage);
                    Destroy(gameObject);
                }
            }
        }
    }
}