﻿using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;
[System.Serializable]
public  class GameManager:MonoBehaviour
{
    public static ArrayList collectableList;
    public static ArrayList enemyList;
    public static ArrayList obstacleList; //#distObs
    public static GameObject playerOne;
    public static GameObject deathHandler;
    public static GameObject sfxHandler;
    public static GameObject scoreObject;
    public static PlayerPointHandler pointHandler;
    public static DeathFxHandler DeathFxHandler;
    public static MusicFxHandler MusicFxHandler;
    public static ScoreHandler scoreHandler;
    
     
    void Start()
    {
        scoreObject = GameObject.Find("scoreHandler");
        sfxHandler = GameObject.Find("sfxHandler");
        deathHandler = GameObject.Find("deathHandler");
        collectableList=new ArrayList();
        enemyList = new ArrayList();
        obstacleList = new ArrayList(); //#distObs
        playerOne = GameObject.Find("player");
        if (playerOne != null)
        {
            pointHandler = playerOne.GetComponent<PlayerPointHandler>();//this attaches the script
        }
        if (deathHandler != null)
        {
            DeathFxHandler = deathHandler.GetComponent<DeathFxHandler>();
        }
        if (sfxHandler != null)
        {
            MusicFxHandler = sfxHandler.GetComponent<MusicFxHandler>();
        }
        if (scoreObject != null)
        {
            scoreHandler = scoreObject.GetComponent<ScoreHandler>();
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

    public static void instantiateObsticleFx(Transform otherTransform)
    {
        DeathFxHandler.instantiateObsibleFx(otherTransform);
        
    }

    public static void instantiateEnemyFx(Transform otherTransform)
    {
        DeathFxHandler.instantiateEnemyFx(otherTransform);
       
        
    }

    public static void activateContinueTextBlink()
    {
        GameObject textGameObject = GameObject.Find("TextHandler");
        ContinueText text= textGameObject.GetComponent<ContinueText>();
        text.activate = true;

    }

   
    public static void playProjectileHitSoundFx()
    {
        MusicFxHandler.playProjectileHitSfx();
    }

    public static void playObstacleExplosionSfx()
    {
        MusicFxHandler.playObstableExplosionSoundFx();
    }

    public static void increaseScore(int scoreAmount)
    {
       scoreHandler.increaseScore(scoreAmount);
    }
}
