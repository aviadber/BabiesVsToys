using UnityEngine;
using System.Collections;

// #obs
public enum BLOCKED { UP, DOWN, RIGHT, LEFT, NULL };
public enum DODGE { UP, DOWN, RIGHT, LEFT, NULL };
// #obsend
//ALON!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
public class EnemyAI : MonoBehaviour
{
    public float moveSpeed;
    private float range;

    public bool gotPlayerPoint = false;
    public EnemyInfoHolder _enemyInfoHolder;
    public string pointHolding;

    private EnemyAttack enemyAttack;

    private bool isRegistered = false;
    // Use this for initialization

    // #obs
    public bool stop = false, faceRight = false, dodgeByPlayerPos = true, dodging = false;
    public BLOCKED MOVEMENT = BLOCKED.NULL;
    public DODGE TURN = DODGE.NULL;
    // #obsend

    void Awake()
    {
        // Setting up the references.

        enemyAttack = GetComponent<EnemyAttack>();

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
//            print("registering ennemy");
            GameManager.registerEnemy(this.gameObject);
            isRegistered = true;
        }
        if (!gotPlayerPoint && GameManager.isFreePoints())
        {
            _enemyInfoHolder = GameManager.getInfo4Enemy(this.gameObject.transform);

            //                range = Vector3.Distance(this.transform.position, _enemyInfoHolder.point.dockPoint.position); //range between enemy and player
            //          
        }

        range = Vector3.Distance(this.transform.position, _enemyInfoHolder.point.dockPoint.position);
        if (range <= 0.2f) // checks when enemy is near the player dock point and then occupies it 
        {

            GameManager.OccupyPoint(_enemyInfoHolder.point);
            pointHolding = _enemyInfoHolder.point.name;
            gotPlayerPoint = true;

        }
        if (GameManager.isFreePoints())
        {
            /*#obs*/
            // print(MOVEMENT);
            if (dodging)
                dodge();
            else if (MOVEMENT == BLOCKED.NULL)
            { /*#obsend*/
               // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(this.transform.position, _enemyInfoHolder.point.dockPoint.position, moveSpeed * Time.deltaTime);
                
            }

            // #obsk
            else
                rayHit();

            // #obsend
        }


        if (range > 0.30 && gotPlayerPoint)//releases the attack point if the enemy is not near it 
        {

            GameManager.ReleasePoint(_enemyInfoHolder.point);
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
            //#obs
            faceRight = true;
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            //#obs
            faceRight = false;
        }
    }
    //#obs
    void rayHit()
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
                    dodging = true;


                    break;
                //case BLOCKED.DOWN:
                //    if (byPlayerPos)
                //    {
                //        if (_enemyInfoHolder.point.attackPoint.transform.position.x < transform.position.x)
                //        {
                //            TURN = DODGE.LEFT;
                //        }
                //    }
                //    else // random
                //    {
                //        if (Random.value < 0.5f)
                //        {
                //            TURN = DODGE.LEFT;
                //        }
                //        else
                //        {
                //            TURN = DODGE.RIGHT;
                //        }
                //    }
                //    dodging = true;
                //    if (_enemyInfoHolder.point.attackPoint.transform.position.x > transform.position.x)
                //        direction += Vector3.right;
                //    else
                //        direction += Vector3.left;

                //    transform.Translate(moveSpeed * direction.normalized * Time.deltaTime);
                //    break;
                case BLOCKED.RIGHT:
                case BLOCKED.LEFT:
                    if (dodgeByPlayerPos)
                    {
                        if (_enemyInfoHolder.point.dockPoint.transform.position.y > transform.position.y)
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
                    dodging = true;


                    break;
                //case BLOCKED.RIGHT:
                //    direction += Vector3.left;
                //    if (_enemyInfoHolder.point.attackPoint.transform.position.y > transform.position.y)
                //        direction += Vector3.up;
                //    else
                //        direction += Vector3.down;

                //    transform.Translate(moveSpeed * direction.normalized * Time.deltaTime);
                //    break;
                //default:
                //    break;
            }
        }
    }

    void dodge()
    {
       // print("in DODGE!");

        if (MOVEMENT == BLOCKED.NULL)
        {
            dodging = false;
            TURN = DODGE.NULL;
            return;
        }

        Vector3 direction = new Vector3(0, 0, 0);

        switch (TURN)
        {
            case DODGE.UP:

                transform.Translate(moveSpeed * Vector3.up * Time.deltaTime);
                break;
            case DODGE.DOWN:

                transform.Translate(moveSpeed * Vector3.down * Time.deltaTime);

                break;
            case DODGE.RIGHT:

                //if (MOVEMENT == BLOCKED.UP)
                //    direction += Vector3.down;
                //else
                //    direction += Vector3.up;

                if (faceRight)
                    direction += Vector3.left;
                else
                    direction += Vector3.right;


                transform.Translate(moveSpeed * direction.normalized * Time.deltaTime);

                break;

            case DODGE.LEFT:
                if (faceRight)
                    transform.Translate(moveSpeed * Vector3.right * Time.deltaTime);
                else
                    transform.Translate(moveSpeed * Vector3.left * Time.deltaTime);

                break;
            default:
                break;


        }

    }
    //#obsend
}


