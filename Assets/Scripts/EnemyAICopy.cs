using UnityEngine;
using System.Collections;

public class EnemyAICopy : MonoBehaviour
{
    public float moveSpeed;
    private float range;

    public bool gotPlayerPoint = false;
    public EnemyInfoHolder _enemyInfoHolder;

    private EnemyAttack EnemyAttack;

    private bool isRegistered = false;
    // Use this for initialization

    void Awake()
    {
        // Setting up the references.

        EnemyAttack = GetComponent<EnemyAttack>();

    }
    void Start()
    {
        //        print("start");
        //		   GameManager.registerEnemy(gameObject);

        //playerObj = AiController.choosePolicy (); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRegistered)
        {
            print("registering ennemy");
            GameManager.registerEnemy(this.gameObject);
            isRegistered = true;
        }
        if (!gotPlayerPoint)
        {
            _enemyInfoHolder = GameManager.getInfo4Enemy(this.gameObject.transform);

            /* moved inside the if (NullReferenceException: Object reference not set to an instance of an object
                                            EnemyAI.Update () (at Assets/Scripts/EnemyAI.cs:37)) -alon*/
            if (_enemyInfoHolder.point != null)
                range = Vector3.Distance(this.transform.position, _enemyInfoHolder.point.dockPoint.position); //range between enemy and player
        }

        if (_enemyInfoHolder != null && GameManager.isFreePoints())
        {

            if (range < 0.1) // checks when enemy is near the player attack point and then occupies it 
            {
                _enemyInfoHolder.point.occupied = 1;
                gotPlayerPoint = true;
                // alon
                Debug.Log("inragne");
                EnemyAttack.playerInRange = true;
            }
            transform.position = Vector3.MoveTowards(this.transform.position, _enemyInfoHolder.point.dockPoint.position, moveSpeed * Time.deltaTime);
        }
        float rangeFromPlayer = Vector3.Distance(this.transform.position, _enemyInfoHolder.playerGameObject.transform.position);
        print(rangeFromPlayer);
        if (rangeFromPlayer > 0.30f)//releases the attack point if the enemy is not near it 
        {
            if (_enemyInfoHolder.point != null) _enemyInfoHolder.point.occupied = 0;//REFACTOR THIS 
            gotPlayerPoint = false;
            if (EnemyAttack != null) EnemyAttack.playerInRange = false;
            print("releasing point");
        }
        CheckSide(_enemyInfoHolder); // this changes rotation according to player location
    }

    public void CheckSide(EnemyInfoHolder _enemyInfoHolder)
    {
        if (transform.position.x - _enemyInfoHolder.playerGameObject.transform.position.x < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
