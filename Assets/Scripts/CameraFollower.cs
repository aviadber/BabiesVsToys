using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private bool cameraIsStopped;
    public bool firstStop = false;
    public GameObject objToFollow;
    public float smoothFactor;
    public bool stopCamera = false;
    private Vector3 velocity = Vector3.zero;
    private float y, z;
    // Use this for initialization
    private void Start()
    {
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    private void Update()
    {
//this makes camera follow the player
        if (stopCamera)
        {
            if (GameManager.enemyList.Count == 0)
            {
                if (cameraIsStopped && !firstStop)
                {
                    firstStop = true;
                    cameraIsStopped = false;
                }
                transform.position = Vector3.MoveTowards(transform.position, objToFollow.transform.position,
                    smoothFactor);
                transform.position = new Vector3(transform.position.x, y, z);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, objToFollow.transform.position, smoothFactor);
            transform.position = new Vector3(transform.position.x, y, z);
        }
      
        if (firstStop && !cameraIsStopped)
        {
            GameManager.activateContinueTextBlink();
            firstStop = false;
        }
      
        if (GameManager.enemyList.Count > 0 )
        {
            cameraIsStopped = true; 
        }
    }
}