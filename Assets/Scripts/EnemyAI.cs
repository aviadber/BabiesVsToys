using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum BLOCKED
{
    UP,
    DOWN,
    RIGHT,
    LEFT,
    NULL
};
public enum DODGE
{
    UP,
    DOWN,
    RIGHT,
    LEFT,
    NULL
};

public enum ANIM
{
    WALKING,
    ATTACKING,
    STANDING
};

public class EnemyAI : MonoBehaviour
{
    public BLOCKED MOVEMENT = BLOCKED.NULL;
    public ANIM STATE = ANIM.STANDING;
    public DODGE TURN = DODGE.NULL;
    public EnemyInfoHolder _enemyInfoHolder;
    public bool dodgeByPlayerPos = true, dodging = false;
    private EnemyAttack enemyAttack;
    public bool faceRight = false;
    public bool gotPlayerPoint = false;
    private bool isRegistered;
    public float moveSpeed;
    public string pointHolding;
    public bool predictPlayerMovment = false;
    private float range;
    public bool stop = false;

    private void Awake()
    {
        // Setting up the references.

        enemyAttack = GetComponent<EnemyAttack>();
    }

    private void Start()
    {
        //        print("start");
        //		   GameManager.registerEnemy(gameObject);

        //playerObj = AiController.choosePolicy (); 
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isRegistered)
        {
//            print("registering ennemy");
            GameManager.registerEnemy(gameObject);
            isRegistered = true;
        }
        if (!gotPlayerPoint && GameManager.isFreePoints())
        {
            _enemyInfoHolder = GameManager.getInfo4Enemy(gameObject.transform);

            //                range = Vector3.Distance(this.transform.position, _enemyInfoHolder.point.dockPoint.position); //range between enemy and player
            //          
        }
        if (!stop)
        {
            range = Vector3.Distance(transform.position, _enemyInfoHolder.point.dockPoint.position);
            if (range <= 0.2f) // checks when enemy is near the player dock point and then occupies it 
            {
                GameManager.OccupyPoint(_enemyInfoHolder.point);

                STATE = ANIM.ATTACKING;
                GetComponentInChildren<Animator>().Play("Attacking");

                pointHolding = _enemyInfoHolder.point.name;
                gotPlayerPoint = true;
            }
            if (GameManager.isFreePoints())
            {
                if (dodging)
                    dodge();


                    // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                else if (MOVEMENT == BLOCKED.NULL)
                {
                    float oldY = transform.position.y;
                    transform.position = Vector3.MoveTowards(transform.position,
                        _enemyInfoHolder.point.dockPoint.position, moveSpeed*Time.deltaTime);
                    if (transform.position.y >= 1.76f)
                    {
                        transform.position = new Vector3(transform.position.x, oldY, transform.position.z);
                        MOVEMENT = BLOCKED.UP;
                        TURN = DODGE.DOWN;
                        dodging = true;
                    }
                    else if (transform.position.y <= 0.18f)
                    {
                        transform.position = new Vector3(transform.position.x, oldY, transform.position.z);
                        MOVEMENT = BLOCKED.DOWN;
                        TURN = DODGE.UP;
                        dodging = true;
                    }
                }
                else
                    rayHit();
            }
        }


        if (range > 0.30 && gotPlayerPoint) //releases the attack point if the enemy is not near it 
        {
            GameManager.ReleasePoint(_enemyInfoHolder.point);
            //GameManager.setClownWalk(true);
            GetComponentInChildren<Animator>().Play("Walking");
            STATE = ANIM.WALKING;

            pointHolding = _enemyInfoHolder.point.name;
            gotPlayerPoint = false;

            if (enemyAttack != null) enemyAttack.playerInRange = false;
        }
        CheckSide(_enemyInfoHolder); // this changes rotation according to player location
    }

    public void CheckSide(EnemyInfoHolder _enemyInfoHolder)
    {
        if (transform.position.x - _enemyInfoHolder.playerGameObject.transform.position.x < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            faceRight = true;
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            faceRight = false;
        }
    }

    private void rayHit()
    {
        print("in RAYHIT!");

        if (!dodging)
        {
            switch (MOVEMENT)
            {
                case BLOCKED.DOWN:
                case BLOCKED.UP:

                    // direction += Vector3.down;
                    if (dodgeByPlayerPos)
                    {
                        if (_enemyInfoHolder.point.dockPoint.transform.position.x < transform.position.x)
                        {
                            TURN = DODGE.LEFT;
                        }
                        else
                        {
                            TURN = DODGE.RIGHT;
                        }
                    }
                    else // random
                    {
                        if (Random.value < 0.5f)
                        {
                            TURN = DODGE.LEFT;
                        }
                        else
                        {
                            TURN = DODGE.RIGHT;
                        }
                    }
                    if (predictPlayerMovment)
                    {
                        float absDiff =
                            Math.Abs(_enemyInfoHolder.point.dockPoint.transform.position.y - transform.position.y);
                        if (absDiff < 0.25)
                        {
                            if (GameObject.FindGameObjectWithTag("player").GetComponent<boxMov>().moveLeft)
                                TURN = DODGE.LEFT;
                            else
                                TURN = DODGE.RIGHT;
                        }
                    }
                    dodging = true;


                    break;

                case BLOCKED.RIGHT:
                case BLOCKED.LEFT:
                    if (dodgeByPlayerPos)
                    {
                        if ((_enemyInfoHolder.point.dockPoint.transform.position.y > transform.position.y ||
                             transform.position.y <= 1.76f) && !(transform.position.y <= 0.18f))
                        {
                            TURN = DODGE.UP;
                        }
                        else
                        {
                            TURN = DODGE.DOWN;
                        }
                    }
                    else // random
                    {
                        if (Random.value < 0.5f)
                        {
                            TURN = DODGE.UP;
                        }
                        else
                        {
                            TURN = DODGE.DOWN;
                        }
                    }
                    if (predictPlayerMovment)
                    {
                        float absDiff =
                            Math.Abs(_enemyInfoHolder.point.dockPoint.transform.position.x - transform.position.x);
                        if (absDiff < 0.25)
                        {
                            if (GameObject.FindGameObjectWithTag("player").GetComponent<boxMov>().moveUp)
                                TURN = DODGE.UP;
                            else
                                TURN = DODGE.DOWN;
                        }
                    }
                    dodging = true;


                    break;
            }
        }
    }

    private void dodge()
    {
        // print("in DODGE!");

        if (MOVEMENT == BLOCKED.NULL)
        {
            dodging = false;
            TURN = DODGE.NULL;
            return;
        }

        var direction = new Vector3(0, 0, 0);
        var translation = new Vector3(0, 0, 0);

        switch (TURN)
        {
            case DODGE.UP:
                translation = moveSpeed*Vector3.up*Time.deltaTime;
                if (transform.position.y >= 1.76f)
                {
                    TURN = DODGE.DOWN;
                }
                else
                {
                    transform.Translate(translation);
                }
                break;
            case DODGE.DOWN:
                translation = moveSpeed*Vector3.down*Time.deltaTime;
                if (transform.position.y <= 0.18f)
                {
                    TURN = DODGE.UP;
                }
                else
                {
                    transform.Translate(translation);
                }
                break;

            case DODGE.RIGHT:


                if (faceRight)
                    direction += Vector3.left;
                else
                    direction += Vector3.right;


                transform.Translate(moveSpeed*direction.normalized*Time.deltaTime);

                break;

            case DODGE.LEFT:
                if (faceRight)
                    transform.Translate(moveSpeed*Vector3.right*Time.deltaTime);
                else
                    transform.Translate(moveSpeed*Vector3.left*Time.deltaTime);

                break;
            default:
                break;
        }
    }
}