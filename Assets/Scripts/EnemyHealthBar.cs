using System.ComponentModel;
using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour
{

    public GameObject frontBar;
    public GameObject backBar;
	public float div = 340f;
    private EnemyHealth enemyHealth;

    private float newScale;



    void Awake()
    {
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();
        // bar = GetComponent<Sprite>()
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        newScale = enemyHealth.currentHealth / div ;
        if (newScale >= 0)
        {

            frontBar.transform.localScale = new Vector3(newScale, 0.7f, 1f);
            backBar.transform.localScale = new Vector3(newScale, 0.7f, 1f);
            if (newScale < 0.3)
            {
                frontBar.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

    }

}
