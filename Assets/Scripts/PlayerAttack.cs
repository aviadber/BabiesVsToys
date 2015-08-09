using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class PlayerAttack : MonoBehaviour
{
    public GameObject EffectGameObject;
    public float attackAnimTime = 1;
    private float attackAnimTimeSoFar;
    public string attackKey;
    private bool canAttack = false;
    public ArrayList canAttackList;
    private bool isAttacking;
    public int meleeAttackDmg;
    public float minAttackRange;
    public GameObject offensePoint;
    public GameObject projectileGameObject;
    private float range;
    public string rangedAttackKey;
    public int typeOfAttack;
    public GameObject waterGunExitPoint;

    // Use this for initialization
    private void Start()
    {
        canAttackList = new ArrayList();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAttacking)
        {
            attackAnimTimeSoFar += Time.deltaTime;
            if (attackAnimTimeSoFar >= attackAnimTime)
            {
                GameManager.setAttackAnim(false);
                attackAnimTimeSoFar = 0;
                isAttacking = false;
            }
        }
        if (typeOfAttack == 1)
        {

            GameManager.isWithGun = true;


        }
        else
        {
            GameManager.isWithGun = false;
        }

        if (GameManager.enemyList.Count > 0)
        {
            for (int i = 0; i < GameManager.enemyList.Count; i++)
            {
                var t = (GameObject) GameManager.enemyList[i];

                if (t.transform != null)
                    range = Vector3.Distance(offensePoint.transform.position, t.transform.position);
                //            print("range is :"+range);
                if (range <= minAttackRange)
                    canAttackList.Add(t);
                if (range > minAttackRange)
                    canAttackList.Remove(t);
            }
        }

        //#distObs
        if (GameManager.obstacleList.Count > 0)
        {
            for (int i = 0; i < GameManager.obstacleList.Count; i++)
            {
                var t = (GameObject) GameManager.obstacleList[i];

                if (t.transform != null)
                    range = Vector3.Distance(offensePoint.transform.position, t.transform.position);
                if (range <= minAttackRange)
                {
                    canAttackList.Add(t);
                }
                if (range > minAttackRange)
                    canAttackList.Remove(t);
            }
        }
        if (Input.GetKeyDown(rangedAttackKey))
        {
            Attack(null);
        }
        if (Input.GetKeyDown(attackKey) && canAttackList.Count > 0)
        {
            if (typeOfAttack == 0)
            {
                for (int i = 0; i < canAttackList.Count; i++)
                {
                    Attack((GameObject) canAttackList[i]);
                }
            }
        }
        canAttackList.Clear();
    }

    public void Attack(GameObject obj)
    {
        if (obj != null)
        {
            if (obj.tag == "Enemy")
            {
                var health = obj.GetComponent<EnemyHealth>();

                if (typeOfAttack == 0) // melee attack
                {
                    Instantiate(EffectGameObject, offensePoint.transform.position, offensePoint.transform.rotation);
                    isAttacking = true;
                    GameManager.setAttackAnim(true);
                    if (health != null) health.DecreaseHealth(meleeAttackDmg);
                }
            }
            else
            {
                var health = obj.GetComponent<ObstacleHealth>(); //#distObs
                if (typeOfAttack == 0) // melee attack
                {
                    Instantiate(EffectGameObject, offensePoint.transform.position, offensePoint.transform.rotation);
                    isAttacking = true;
                    GameManager.setAttackAnim(true);

                    health.DecreaseHealth(meleeAttackDmg);
                }
            }
        }
        if (typeOfAttack == 1) //ranged attack
        {
            GameManager.playShootSound();
            Instantiate(projectileGameObject, waterGunExitPoint.transform.position, waterGunExitPoint.transform.rotation);
        }
    }
}