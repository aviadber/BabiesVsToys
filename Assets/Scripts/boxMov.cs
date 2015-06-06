

using System;

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
    public bool moveUp;
    public bool moveDown;
    public bool isWalking = false;
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

    void LateUpdate()
    {
//        setAnimations();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isWithGun)
        {
            GameManager.setWalkGunAnim(false);
            GameManager.setWalkingAnim(false);
            GameManager.setStandGunAnim(true);
        }
        else
        {
            GameManager.setWalkGunAnim(false);
            GameManager.setWalkingAnim(false);
            GameManager.setStandGunAnim(false); 
        }
        if (Input.GetKey(right) && !blockedRight)
        {
            setIsWalkingWithGun();
           setAnimations();
            isWalking = true;
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
            setIsWalkingWithGun();
            setAnimations();
            isWalking = true;
            if ((GameManager.playerOne.transform.position.x - leftBorder.transform.position.x) > 0)
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y,
                    transform.position.z);
                transform.rotation = new Quaternion(0, 180, 0, 0);
                moveRight = false;
                moveLeft = true;
              
            }

        }
        if (Input.GetKey(up)&& !blockedUp )
        {
            setIsWalkingWithGun();
            setAnimations();
            isWalking = true;
            if (transform.position.y < 1.78)
                transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            moveUp = true;
            moveDown = false;
      
        }
        if (Input.GetKey(down))
            if (Input.GetKey(down)&& !blockedDown )
            {
                setIsWalkingWithGun();
                setAnimations();
                isWalking = true;
                if (transform.position.y > 0.16)
                    transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, transform.position.z);
                else
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                moveUp = false;
                moveDown = true;
           
            }
        

    }

    private static void setIsWalkingWithGun()
    {
        if (GameManager.isWithGun)
            GameManager.isWalkingWithGun = true;
        else
        {
            GameManager.isWalkingWithGun = false;
        }
    }

    private void setAnimations()
    {
        if (GameManager.isWalkingWithGun)
        {
            GameManager.setWalkingAnim(false);
            GameManager.setStandGunAnim(false);
            GameManager.setWalkGunAnim(true);
        }
        if (!GameManager.isWalkingWithGun && !GameManager.isWithGun)
        {
            GameManager.setWalkingAnim(true);
            GameManager.setStandGunAnim(false);
            GameManager.setWalkGunAnim(false);
        }
        if (!GameManager.isWalkingWithGun && GameManager.isWithGun)
        {
            GameManager.setWalkingAnim(false);
            GameManager.setWalkGunAnim(false);
            GameManager.setStandGunAnim(true);
        }
       
    }

    private void checkIsWithGun()
    {
        if (GameManager.isWithGun)
        {
            GameManager.isWalkingWithGun = true;
            GameManager.setWalkGunAnim(true);
            GameManager.setWalkingAnim(false);
            GameManager.setStandGunAnim(false);
            
        }
        else
        {
            GameManager.isWalkingWithGun = false;
            GameManager.setWalkGunAnim(false);
            GameManager.setWalkingAnim(true);
            GameManager.setStandGunAnim(false);
        }
    }
}





