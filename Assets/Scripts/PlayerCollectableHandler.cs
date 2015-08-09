using System.Collections;
using UnityEngine;

public class PlayerCollectableHandler : MonoBehaviour
{
    private CollactableWeapon col;
    private ArrayList collectables;
    public string dropPickUpKey;
    public string pickUpKey;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.collectableList != null) collectables = GameManager.collectableList;
        if (Input.GetKeyDown(pickUpKey))
        {
//            print("trying to pick up");
            for (int i = 0; i < collectables.Count; i++)
            {
                var collectableGameObject = (GameObject) collectables[i];
                float distance = Vector3.Distance(gameObject.transform.position,
                    collectableGameObject.transform.position);
                if (distance <= 1)
                {
                    var playerAttack = gameObject.GetComponent<PlayerAttack>();
//	                playerAttack.typeOfAttack = 1;
                    col = pickUpCollectable(collectableGameObject);
                }
            }
        }
        if (Input.GetKeyDown(dropPickUpKey))
        {
            if (col != null) col.isPicked = false;
            GameManager.setDefenceString("gettingHit");
            var playerAttack = gameObject.GetComponent<PlayerAttack>();
            if(playerAttack.typeOfAttack==1)
			col.transform.position=new Vector3(col.transform.position.x,col.transform.position.y-0.8f,col.transform.position.z);
            playerAttack.typeOfAttack = 0;
        }
    }

    private CollactableWeapon pickUpCollectable(GameObject collect)
    {
        var c = collect.GetComponent<CollactableWeapon>();
//        GameManager.setWalkGunAnim(true);
        c.isPicked = true;

        return c;
    }
}