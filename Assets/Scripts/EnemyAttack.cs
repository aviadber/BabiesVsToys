using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 1;               // The amount of health taken away per attack.
    public float attackRange;

    Animator anim;                              // Reference to the animator component.
      GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
     public bool playerInRange = true;                         // Whether player is within the trigger collider and can be attacked.
    float timer = 0f;                                // Timer for counting up to the next attack.


    void Awake()
    {
        // Setting up the references.
        player = GameObject.Find("player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        //anim = GetComponent<Animator>();
    }



    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            playerInRange = true;
        else
        {
            playerInRange = false;
        }
        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            // ... attack.
//            GameManager.setClownAttack(true);
            Attack();
            Debug.Log("attacking player");
        }
        else
        {
//            GameManager.setClownAttack(false); 
        }

        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            //anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }
}