

using System;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class boxMov : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float moveZUp = 1f;
    public float moveZDown = 1f;
    public int zLimit = 0;
    public float zFactorUp = 2.0f;
    public float zFactorDown = 2.0f;
    public string left, right, up, down;
    private GameObject leftBorder, rightBorder;
    public bool moveRight;
    public bool moveLeft;
    // #obs
    public bool blockedUp, blockedDown, blockedRight, blockedLeft;
    // #obsend
    // privates





    // Use this for initialization
    void Start()
    {
        leftBorder = GameObject.Find("leftBorder");
        rightBorder = GameObject.Find("rightBorder");
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(right) && !blockedRight)
        {
            if ((rightBorder.transform.position.x - GameManager.playerOne.transform.position.x) > 0)
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y,
                    transform.position.z);
                transform.rotation = new Quaternion(0, 0, 0, 0);
                moveRight = true;
                moveLeft = false;
            }
        }
        if (Input.GetKey(left) && !blockedLeft)
        {
            if ((GameManager.playerOne.transform.position.x - leftBorder.transform.position.x) > 0)
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y,
                    transform.position.z);
                transform.rotation = new Quaternion(0, 180, 0, 0);
                moveRight = false;
                moveLeft = true;
            }

        }
        if (Input.GetKey(up)/*#obs*/&& !blockedUp /*#obsend*/)
        {
           
            if (/*transform.position.z < 1.22 #CHECK-BERMAN &&*/ transform.position.y < 1.78)
                transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(down))
            if (Input.GetKey(down)/*#obs*/&& !blockedDown /*#obsend*/ )
            {
                if (transform.position.y > 0.16)
                    transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, transform.position.z);
                else
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }


    }





}





