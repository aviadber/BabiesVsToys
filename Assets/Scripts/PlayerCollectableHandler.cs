using UnityEngine;
using System.Collections;

public class PlayerCollectableHandler : MonoBehaviour
{
    private ArrayList collectables;
    public string pickUpKey;
    public string dropPickUpKey;
    private CollactableWeapon col;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (GameManager.collectableList != null) collectables = GameManager.collectableList;
	    if (Input.GetKeyDown(pickUpKey))
	    {
//            print("trying to pick up");
	        for (int i = 0; i < collectables.Count; i++)
	        {
	            GameObject collectableGameObject = (GameObject) collectables[i];
	            float distance = Vector3.Distance(gameObject.transform.position, collectableGameObject.transform.position);
                if(distance<=1)
	            {
                    PlayerAttack playerAttack = gameObject.GetComponent<PlayerAttack>();
//	                playerAttack.typeOfAttack = 1;
	            col= pickUpCollectable(collectableGameObject);
	            }
	        }
	    }
	    if (Input.GetKeyDown(dropPickUpKey))
	    {
	        if (col != null) col.isPicked = false;

            PlayerAttack playerAttack = gameObject.GetComponent<PlayerAttack>();
	        playerAttack.typeOfAttack = 0;
	    }
	}

    private CollactableWeapon pickUpCollectable(GameObject collect)
    {
        CollactableWeapon c = collect.GetComponent<CollactableWeapon>();
        c.isPicked = true;

        return c;
    }
}
