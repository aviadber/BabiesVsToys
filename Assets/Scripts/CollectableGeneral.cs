using UnityEngine;
using System.Collections;

public class CollectableGeneral : MonoBehaviour
{
    public GameObject collectable;
    public bool isRegistered = false;
    public int healthBoost;
    public int scoreBoost;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (collectable != null && !isRegistered)
        {
            RegisterAndInstantiate();
        }

    }

    private void RegisterAndInstantiate()
    {
        GameManager.RegisterCollectable(collectable);
        isRegistered = false;
        Instantiate(collectable, transform.position, transform.rotation);
    }
}