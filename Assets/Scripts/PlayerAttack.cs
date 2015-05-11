using System;
using UnityEngine;
using System.Collections;
[System.Serializable]
public class PlayerAttack : MonoBehaviour
{
    public GameObject projectileGameObject;
    public GameObject EffectGameObject;
    public GameObject offensePoint;
    public GameObject waterGunExitPoint;
    public float minAttackRange;
    private float range;
    private bool canAttack = false;
    public ArrayList canAttackList;
    public string attackKey;
    public int typeOfAttack;
    public string rangedAttackKey;
    public int meleeAttackDmg;

    // Use this for initialization
    void Start()
    {
        canAttackList = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.enemyList.Count > 0)
        {
            for (int i = 0; i < GameManager.enemyList.Count; i++)
            {
                GameObject t = (GameObject)GameManager.enemyList[i];

                if (t.transform != null) range = Vector3.Distance(offensePoint.transform.position, t.transform.position);
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
                GameObject t = (GameObject)GameManager.obstacleList[i];

                if (t.transform != null) range = Vector3.Distance(offensePoint.transform.position, t.transform.position);
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
                    Attack((GameObject)canAttackList[i]);
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
                EnemyHealth health = obj.GetComponent<EnemyHealth>();
                print("enemydsaasdsad");
                if (typeOfAttack == 0)// melee attack
                {
                    Instantiate(EffectGameObject, offensePoint.transform.position, offensePoint.transform.rotation);
                    health.DecreaseHealth(meleeAttackDmg);
                }
            
            }
            else
            {
                print("obs attack");
                ObstacleHealth health = obj.GetComponent<ObstacleHealth>(); //#distObs
                if (typeOfAttack == 0)// melee attack
                {
                    Instantiate(EffectGameObject, offensePoint.transform.position, offensePoint.transform.rotation);
                    health.DecreaseHealth(meleeAttackDmg);
                }
            
            }
     

            
        }
        if (typeOfAttack == 1)//ranged attack
        {
            print("attacking water");
            Instantiate(projectileGameObject, waterGunExitPoint.transform.position, waterGunExitPoint.transform.rotation);


        }
            


    }
}

