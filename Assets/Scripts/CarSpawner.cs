using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

    // GameObjects
    public GameObject enemy;
    public GameObject player;

    //info
    public float distanceFromPlayer;
    // Options

    public bool pause = false;

    // Timing
    public float spawnInterval = 3f;

    // By player distance
    public bool byPlayerDistance = false;
    public int distance = 8;
    public float tempDistance; // for testing, change to private

    // Max ememies
    public bool useMaxEnemyes = false;
    public int MaxEnemyes = 10;
    public int enemyesDeployed = 0;

    // Boss
    public bool boss = false;
    public int bossHPMultiplier = 2;

    // Spawn Points
    public bool randomSpawnPoints = false;
    public Transform[] spawnPointsContainer;

    // Spawn Points
    public bool randomEnemyes = false;
    public GameObject[] enemyContainer;
    // private variables
    private int health;
    //private bool spawning = false;
    private float timer;






    void Awake()
    {
        timer = Time.time + spawnInterval;
    }

    void Start()
    {
        //	    if (!pause && !byPlayerDistance)
        //	    {
        //            InvokeRepeating("Spawn",spawnInterval,spawnInterval);
        //	        spawning = true;
        //	    }
    }

    void Update()
    {
        if (!pause && !(useMaxEnemyes && (MaxEnemyes <= enemyesDeployed)))
        {


            if (byPlayerDistance)
            {
                tempDistance = Vector3.Distance(this.transform.position, player.transform.position);
                distanceFromPlayer = tempDistance;
                if (tempDistance <= distance)
                {
                    if (timer < Time.time)
                    {
                        Spawn();
                        timer = Time.time + spawnInterval;
                    }
                }
            }
            else
            {
                if (timer < Time.time)
                {
                    Spawn();
                    timer = Time.time + spawnInterval;
                }
            }

        }
    }

    private void Spawn()
    {
        if (!pause /* && playerHealth>0 */) // when player will have health
        {
            if (randomEnemyes)
            {
                int enemyIndex = Random.Range(0, enemyContainer.Length);
                enemy = enemyContainer[enemyIndex];
            }
            if (boss)
            {
                health = enemy.GetComponent<EnemyHealth>().currentHealth;
                enemy.GetComponent<EnemyHealth>().currentHealth = health * bossHPMultiplier;
            }
            if (!randomSpawnPoints)
            {
                Instantiate(enemy, transform.position, transform.rotation);
            }
            else
            {
                int spawnPointIndex = Random.Range(0, spawnPointsContainer.Length);
                Instantiate(enemy, spawnPointsContainer[spawnPointIndex].position, spawnPointsContainer[spawnPointIndex].rotation);
            }
            enemyesDeployed++;
        }
    }
}
