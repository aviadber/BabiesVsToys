using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;
[System.Serializable]
public  class GameManager:MonoBehaviour
{
    public static ArrayList collectableList;
    public static ArrayList enemyList;
    public static ArrayList obstacleList; //#distObs
    public static GameObject playerOne;
    public static PlayerPointHandler pointHandler;
    void Start()
    {
        collectableList=new ArrayList();
        enemyList = new ArrayList();
        obstacleList = new ArrayList(); //#distObs
        playerOne = GameObject.Find("player");
        if (playerOne != null)
        {
            pointHandler = playerOne.GetComponent<PlayerPointHandler>();//this attaches the script
        }
    }

    public static bool RegisterCollectable(GameObject collectable)
    {
        if (collectable != null)
        {
            if (collectableList != null)
            {
                collectableList.Add(collectable);
                return true;
            }
            
        }
        return false;
    }

    public static void registerEnemy(GameObject enemy)
    {
 
        if (enemyList != null)
        {
            enemyList.Add(enemy);
     
        }
    }

    public static void registerObstacle(GameObject obs)
    {

        if (obstacleList != null)
        {
            obstacleList.Add(obs);

        }
    }

    public static bool isFreePoints()
    {
        return pointHandler.isFreePoints();
    }



    public static EnemyInfoHolder getInfo4Enemy(Transform enemyPos)
    {
    
        PlayerPoint point = pointHandler.getFreePoint(enemyPos);
        return new EnemyInfoHolder(playerOne,point);
    }

    public static ArrayList GetEnemyList()
    {
        return enemyList;
    }

    public static ArrayList GetObstacleList()
    {
        return obstacleList;
    }

    public static void OccupyPoint(PlayerPoint point)
    {
        pointHandler.OccupyPoint(point);
    }

    public static void ReleasePoint(PlayerPoint point)
    {
        pointHandler.ReleasePoint(point);
    }

    public static void DisablePoint(string s)
    {
        pointHandler.DisablePoint(s);
    }

    public static void EnablePoint(string s)
    {
        pointHandler.EnablePoint(s);
    }
}
