
using UnityEngine;
using System.Collections;

public class CollactableWeapon : MonoBehaviour
{
    public GameObject projectile;
    public bool isPicked=false;
    public GameObject collectableFx;
    private float time=0;
    private bool isRegistered=false;
    private boxMov playerDirection;
	// Use this for initialization
	void Start () {
	GameManager.RegisterCollectable(this.gameObject);
	   
        
	}
	
	// Update is called once per frame
	void LateUpdate ()

	{
	    if (!isRegistered)
	    {
	        isRegistered = GameManager.RegisterCollectable(this.gameObject);
	    }
	    time += Time.deltaTime;
	    if (time > 5 && !isPicked)
	    {
	        Instantiate(collectableFx, this.transform.position, new Quaternion(0,0,0,0));
	        time = 0;
	    }
	    if (isPicked)
	    {
            playerDirection = GameManager.playerOne.GetComponent<boxMov>();
           
	        PlayerAttack playerAttack = GameManager.playerOne.GetComponent<PlayerAttack>();
            
	        transform.position = playerAttack.offensePoint.transform.position;
	        if (playerDirection.moveRight)
	        {
	           transform.rotation= new Quaternion(0, 0, 0, 0);
	        }
	        if (playerDirection.moveLeft)
	        {
                transform.rotation = new Quaternion(0, 180, 0, 0);
	        }
            GameManager.setWalkGunAnim(true);
	        playerAttack.typeOfAttack = 1;
	    }
	}
}
