using UnityEngine;

public class CollactableWeapon : MonoBehaviour
{
    public GameObject collectableFx;
    public bool isPicked = false;
    private bool isRegistered;
    private boxMov playerDirection;
    public GameObject projectile;
    private float time;
    // Use this for initialization
    private void Start()
    {
        GameManager.RegisterCollectable(gameObject);
    }

    // Update is called once per frame
    private void LateUpdate()

    {
        if (!isRegistered)
        {
            isRegistered = GameManager.RegisterCollectable(gameObject);
        }
        time += Time.deltaTime;
        if (time > 5 && !isPicked)
        {
            Instantiate(collectableFx, transform.position, new Quaternion(0, 0, 0, 0));
            time = 0;
        }
        if (isPicked)
        {
            playerDirection = GameManager.playerOne.GetComponent<boxMov>();

            var playerAttack = GameManager.playerOne.GetComponent<PlayerAttack>();

            transform.position = playerAttack.offensePoint.transform.position;
            if (playerDirection.moveRight)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
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