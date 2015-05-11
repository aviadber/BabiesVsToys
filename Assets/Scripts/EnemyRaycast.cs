using UnityEngine;
using System.Collections;

public class EnemyRaycast : MonoBehaviour
{
    public bool showRays = true;
    private float nextRayCheck = 0.0f;
    public float dodgeTime = 1.0f;
    public float ray = 0.1f;

    private EnemyAI p_EnemyAI;
    //Avoid layers
    int _layerMask = -1;

    int layerMask
    {
        get
        {
            if (_layerMask == -1)
            {
                _layerMask = ~(1 << LayerMask.NameToLayer("Player"));
            }
            return _layerMask;
        }
    }
    // Use this for initialization
    void Start()
    {
        p_EnemyAI = transform.parent.GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        //{
        if (p_EnemyAI.MOVEMENT == BLOCKED.NULL || Time.time > nextRayCheck)
        {
            if (Physics.Raycast(transform.position, Vector3.forward, ray, layerMask))
                p_EnemyAI.MOVEMENT = BLOCKED.UP;
            else if (Physics.Raycast(transform.position, Vector3.back, ray, layerMask))
                p_EnemyAI.MOVEMENT = BLOCKED.DOWN;
            else if (Physics.Raycast(transform.position, Vector3.right, ray, layerMask))
                p_EnemyAI.MOVEMENT = BLOCKED.RIGHT;
            else if (Physics.Raycast(transform.position, Vector3.left, ray, layerMask))
                p_EnemyAI.MOVEMENT = BLOCKED.LEFT;
            else
                p_EnemyAI.MOVEMENT = BLOCKED.NULL;

            nextRayCheck = Time.time + dodgeTime;
        }
        //  }

        if (showRays)
        {
            Debug.DrawRay(transform.position, Vector3.forward,
                Color.green);
            Debug.DrawRay(transform.position, Vector3.back,
                Color.yellow);
            Debug.DrawRay(transform.position, Vector3.right,
                Color.blue);
            Debug.DrawRay(transform.position, Vector3.left,
                Color.red);
        }
    }
}
