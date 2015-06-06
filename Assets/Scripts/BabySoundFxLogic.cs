using UnityEngine;
using System.Collections;

public class BabySoundFxLogic : MonoBehaviour
{
    public float timeToPlayRandomSound;
    private float timePassed=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timePassed += Time.deltaTime;
	    if (timePassed >= timeToPlayRandomSound)
	    {
	        GameManager.playRandomBabySoundFx();
	        timePassed = 0;
	    }

	}
}
