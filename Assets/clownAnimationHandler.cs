using UnityEngine;
using System.Collections;

public class clownAnimationHandler : MonoBehaviour
{
    private Animator clownAnimator;

    private bool isAttacking, isWalk;
	// Use this for initialization
	void Start ()
	{
	    clownAnimator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setIsAttacking(bool state)
    {
        isAttacking = state;
        clownAnimator.SetBool("isAttacking",isAttacking);
    }
}
