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
    public bool isMoving=false;
    private Animator animator;
    // attack handling 
    public int attackDamage = 1; // The amount of health taken away per attack.
    public float attackRange;
    public float timeBetweenAttacks = 0.5f; // The time in seconds between each attack.
    private float timer; // Timer for counting up to the next attack.

    

    private void Awake()
    {
        // Setting up the references.
        animator = GetComponentInChildren<Animator>();
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
        }
//        if (!stop)
//        {


        if (GameManager.isFreePoints())
        {

            range = Vector3.Distance(transform.position, _enemyInfoHolder.point.dockPoint.position);

            if (range <= 0.2f) // checks when enemy is near the player dock point and then occupies it 
            {
                if (!gotPlayerPoint)
                {
                    GameManager.OccupyPoint(_enemyInfoHolder.point);
                    gotPlayerPoint = true;
                    pointHolding = _enemyInfoHolder.point.name;
                }
                if (STATE != ANIM.ATTACKING)
                {

//                    print(gameObject.name);
                    

                    STATE = ANIM.ATTACKING;
                }
                timer += Time.deltaTime;
             if(gotPlayerPoint && timer>=timeBetweenAttacks)AttackPlayer();
             else
             {
//                 animator.Play("stand");
             }
            }
            else if (range > 0.3f )
            {
                timer = 0f;
                if (STATE != ANIM.WALKING)
                {
                    if (gotPlayerPoint)
                    GameManager.ReleasePoint(_enemyInfoHolder.point);
                    gotPlayerPoint = false;
                    isMoving = true;
                    STATE = ANIM.WALKING;
                    animator.Play("Walking");
                }
            }
            
            if (STATE == ANIM.WALKING)
            {
                if (dodging)
                    dodge();
                else if (MOVEMENT == BLOCKED.NULL)
                {
                    float oldY = transform.position.y;
                    transform.position = Vector3.MoveTowards(transform.position,
                        _enemyInfoHolder.point.dockPoint.position, moveSpeed*Time.deltaTime);
                    isMoving = true;

                    if (transform.position.y >= 1.76f)
                    {
                        transform.position = new Vector3(transform.position.x, oldY, transform.position.z);
                        MOVEMENT = BLOCKED.UP;
                        TURN = DODGE.DOWN;
                        dodging = true;
                        isMoving = true;

                    }
                    else if (transform.position.y <= 0.18f)
                    {
                        transform.position = new Vector3(transform.position.x, oldY, transform.position.z);
                        MOVEMENT = BLOCKED.DOWN;
                        TURN = DODGE.UP;
                        dodging = true;
                        isMoving = true;

                    }
                }
                                else
                    rayHit();

            }
        }

        CheckSide(_enemyInfoHolder); // this changes rotation according to player location
    }

    private void AttackPlayer()
    {
        timer = 0f;
        if ( GameManager.GetPlayerHealth() > 0 )
        {
            // ... attack.
            //GameManager.setClownAttack(true);
            animator.Play("Attacking");
            print("attacking");
            GameManager.attackThePlayer(attackDamage);
        }
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