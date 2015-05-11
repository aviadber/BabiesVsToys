﻿using UnityEngine;
using System.Collections;

public class PlayerRaycast : MonoBehaviour
{
    public bool showRays = true;

    private boxMov p_boxMov;
    public float ray = 0.45f;

    //Avoid layers
    int _layerMask = -1;

    int layerMask
    {
        get
        {
            if (_layerMask == -1)
            {
                _layerMask = ~(1 << LayerMask.NameToLayer("Enemies"));
            }
            return _layerMask;
        }
    }
    // Use this for initialization
    void Start()
    {
        p_boxMov = transform.parent.GetComponent<boxMov>();
    }

    // Update is called once per frame
    void Update()
    {
        // forward - green ray
                if (Physics.Raycast(transform.position, Vector3.forward, ray, layerMask)) 
                p_boxMov.blockedUp = true;
        else
                p_boxMov.blockedUp = false;

        //back - yellow ray
        if (Physics.Raycast(transform.position, Vector3.back, ray, layerMask)) 
                p_boxMov.blockedDown = true;
        else
                p_boxMov.blockedDown = false;

        // right - blue ray
        if (Physics.Raycast(transform.position, Vector3.right, ray, layerMask))
                p_boxMov.blockedRight = true;
        else
                p_boxMov.blockedRight = false;

        // left - red ray
        if (Physics.Raycast(transform.position, Vector3.left, ray, layerMask))
                p_boxMov.blockedLeft = true;
        else
                p_boxMov.blockedLeft = false;


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