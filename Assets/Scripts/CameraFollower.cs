using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour
{
    public GameObject objToFollow;
    public bool stopCamera = false;
    private Vector3 velocity = Vector3.zero;

    private float y, z;
    public float smoothFactor;
    // Use this for initialization
    void Start()
    {

        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {//this makes camera follow the player
        if (stopCamera)
        {
            if (GameManager.enemyList.Count == 0)
            {

                transform.position = Vector3.MoveTowards(transform.position, objToFollow.transform.position, smoothFactor);
                transform.position = new Vector3(transform.position.x, y, z);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, objToFollow.transform.position, smoothFactor);
            transform.position = new Vector3(transform.position.x, y, z);
        }
        


    }
}
