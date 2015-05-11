using UnityEngine;
using System.Collections;

public class EnemyInfoHolder
{
   
    public GameObject playerGameObject;
    public PlayerPoint point;

    public EnemyInfoHolder(GameObject playerOne, PlayerPoint point)
    {
        playerGameObject = playerOne;
        this.point = point;
 
    }
}
