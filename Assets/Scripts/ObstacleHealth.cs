using UnityEngine;
using System.Collections;

public class ObstacleHealth : MonoBehaviour {

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
            GameManager.instantiateObsticleFx(this.transform);
            GameManager.obstacleList.Remove(this.gameObject);
           // EnemyAI ai = this.gameObject.GetComponent<EnemyAI>();
            print("Dsa");
            Destroy(this.gameObject);
        }

    }
}
