//using UnityEditorInternal;
using UnityEngine;
using System.Collections;

public class SucideCar : MonoBehaviour
{
    public float carSpeed;
    public float speedScaler;
    public float distanceToExplode;
    public GameObject explosionFX;
    public int demageAmount;
    public EnemyInfoHolder _enemyInfoHolder;
    private bool isRegistered=false;
    public float timeToLive;
    private float timeAlive=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timeAlive += Time.deltaTime;
	   
	    if (!isRegistered)
        {
            //            print("registering ennemy");
            GameManager.registerEnemy(gameObject);
            isRegistered = true;
        }
        if (Vector3.Distance(transform.position, GameManager.playerOne.transform.position) <= distanceToExplode)
	    {
	        Boom();
	    }
	    transform.position = new Vector3(transform.position.x - carSpeed*Time.deltaTime, transform.position.y
	        , transform.position.z);
	    carSpeed = carSpeed*speedScaler;
        if (timeAlive >= timeToLive)
        {
            GameManager.enemyList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
	}

    private void Boom()
    {
        Instantiate(explosionFX, this.transform.position, this.transform.rotation);
        GameManager.playObstacleExplosionSfx();
        GameManager.attackThePlayer(demageAmount);
        GameManager.enemyList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
