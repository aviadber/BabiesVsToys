using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 100;
    public int scoreAmount;
    // Use this for initialization
    private void Start()
    {
//        if (currentHealth > 100)
//            currentHealth = 100;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            GameManager.increaseScore(scoreAmount);
            GameManager.instantiateEnemyFx(transform);
            GameManager.playObstacleExplosionSfx();
            GameManager.enemyList.Remove(gameObject);
            var ai = gameObject.GetComponent<EnemyAI>();
            if (ai.gotPlayerPoint)
            {
                ai._enemyInfoHolder.point.occupied = 0;
            }

            Destroy(gameObject);
        }
    }
}