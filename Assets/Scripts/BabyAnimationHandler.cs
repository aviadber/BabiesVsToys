using System.Security;
using UnityEngine;
using System.Collections;

public class BabyAnimationHandler : MonoBehaviour
{

    public Animator babyAnimator;
    public  bool isWalking, isAttacking, isWalkingGun;
	// Use this for initialization
	void Start ()
	{
	    babyAnimator = GetComponent<Animator>();
	
	
    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public  void setWalking(bool state)
    {
        isWalking = state;
        
        babyAnimator.SetBool("isWalking", isWalking);
    }
    public void setWalkingGun(bool state)
    {
        isWalkingGun = state;
        
        babyAnimator.SetBool("isWalkingGun", isWalkingGun);
    }
    public void setAttacking(bool state)
    {
        isAttacking = state;
        babyAnimator.SetBool("isAttacking", isAttacking);
    }
}
