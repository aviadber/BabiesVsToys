using UnityEngine;
using System.Collections;

public class ObstacleHealth : MonoBehaviour {

    public GameObject deathFxGameObject;
    public int currentHealth = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        print(currentHealth);
        if (currentHealth <= 0)
        {
            Instantiate(deathFxGameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);//this unregisteres enemy from GameManger
            GameManager.obstacleList.Remove(this.gameObject);
           // EnemyAI ai = this.gameObject.GetComponent<EnemyAI>();
            print("Dsa");
            Destroy(this.gameObject);
        }

    }
}
