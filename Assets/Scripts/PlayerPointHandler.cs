using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public  class PlayerPointHandler : MonoBehaviour
{
    
    public PlayerPoint [] attackPointsList;
    public PlayerPoint[] parameterPointsList;
    
	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    public bool isFreePoints()
    {
        for (int i = 0; i < attackPointsList.Length; i++)
        {
            if (attackPointsList[i].occupied == 0)
                return true;
        }
        for (int i = 0; i < parameterPointsList.Length; i++)
        {
            if (parameterPointsList[i].occupied == 0)
                return true;
        }
        return false;
    }
   public PlayerPoint getFreePoint(Transform enemyPos)
    {
         List<PlayerPoint> availablePoints = new List<PlayerPoint>();
        for (int i = 0; i < attackPointsList.Length; i++)
        {
            if (attackPointsList[i].occupied == 0 && attackPointsList[i].active==true )
            {
//                if (parameterPointsList[i].dockPoint.transform.position.y < 1.79f)
             availablePoints.Add( attackPointsList[i]);
            }
        }
       if (availablePoints.Count > 0)
       {
           return GetClosestPoint(availablePoints,enemyPos);
       }
       for (int i = 0; i < parameterPointsList.Length; i++)
       {
           if (parameterPointsList[i].occupied == 0 && parameterPointsList[i].active==true)
//               if(parameterPointsList[i].dockPoint.transform.position.y<1.79f)
                availablePoints.Add(parameterPointsList[i]);
       }
       if (availablePoints.Count > 0)
       {
           return GetClosestPoint(availablePoints, enemyPos);
       }
        return null;
    }

    private PlayerPoint GetClosestPoint(List<PlayerPoint> availablePoints, Transform enemyPos)
    {
        int index = -1;
        float range = 999999;
        for (int i = 0; i < availablePoints.Count; i++)
        {
            if (Vector3.Distance(enemyPos.position, availablePoints[i].dockPoint.position) < range)
            {
                range = Vector3.Distance(enemyPos.position, availablePoints[i].dockPoint.position);
                index = i;
            }
        }
//        print("returning "+availablePoints[index].name);
        return availablePoints[index];
    }

    public void OccupyPoint(PlayerPoint point)
    {
        for (int i = 0; i < attackPointsList.Length; i++)
        {
            if (attackPointsList[i]==point)
            {
                attackPointsList[i].occupied = 1;
               
            }
        }
        for (int i = 0; i < parameterPointsList.Length; i++)
        {
            if (parameterPointsList[i]==point)
            {
                parameterPointsList[i].occupied = 1;
            }
        }
    }

    public void ReleasePoint(PlayerPoint point)
    {
        for (int i = 0; i < attackPointsList.Length; i++)
        {
            if (attackPointsList[i] == point)
            {
                attackPointsList[i].occupied = 0;

            }
        }
        for (int i = 0; i < parameterPointsList.Length; i++)
        {
            if (parameterPointsList[i] == point)
            {
                parameterPointsList[i].occupied = 0;
            }
        }
    }

    public void DisablePoint(string s)
    {
        for (int i = 0; i < attackPointsList.Length; i++)
        {
            if (attackPointsList[i].name == s)
            {
                attackPointsList[i].active = false;
                ReleasePoint(attackPointsList[i]);
            }
        }
        for (int i = 0; i < parameterPointsList.Length; i++)
        {
            if (parameterPointsList[i].name == s)
            {
                parameterPointsList[i].active = false;
            }
        }
    }

    public void EnablePoint(string s)
    {
        for (int i = 0; i < attackPointsList.Length; i++)
        {
            if (attackPointsList[i].name == s)
            {
                attackPointsList[i].active = true;
            }
        }
        for (int i = 0; i < parameterPointsList.Length; i++)
        {
            if (parameterPointsList[i].name == s)
            {
                parameterPointsList[i].active = true;
            }
        }
    }
}
