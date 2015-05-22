using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContinueText : MonoBehaviour
{
    public string whatToWrite;
    public bool activate = false;
    private float timeSoFar=0;
    public float blinkTime;
    public Text continueText;
    private bool coin = true;
    public float timeToRun;
    private float runningSoFar=0;
	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (activate)
	    {
            
	        timeSoFar += Time.deltaTime;
	        if (timeSoFar >= blinkTime)
	        {
                if (!coin)
                {

                    continueText.text = "";
                    
                }
	            if (coin)
	            {
                   
                    continueText.text = whatToWrite;
	                
	            }
	            if (coin)
	            {
	                coin = false;
	            }
	            else
	            {
	                coin = true;
                }
	         
	            timeSoFar = 0;
	        }
	        runningSoFar += Time.deltaTime;
	        if (runningSoFar >= timeToRun)
	        {
	            activate = false;
	            runningSoFar = 0;
	            continueText.text = "";
	        }

	    }
	}
}
