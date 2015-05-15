using UnityEditor;
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
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
            GameManager.instantiateEnemyFx(this.transform);
            GameManager.enemyList.Remove(this.gameObject);
            EnemyAI ai = this.gameObject.GetComponent<EnemyAI>();
            if (ai.gotPlayerPoint==true)
            {
                ai._enemyInfoHolder.point.occupied = 0;
            }

            Destroy(this.gameObject);
        }

    }

}
