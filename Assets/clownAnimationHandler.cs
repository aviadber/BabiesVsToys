using UnityEngine;
using System.Collections;

public class clownAnimationHandler : MonoBehaviour
{
    private Animator clownAnimator;

    public bool isAttacking, isWalking;
    // Use this for initialization
    private void Start()
    {
        clownAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {

    }

    //public void setIsAttacking(bool state)
    //{
    //    clownAnimator.SetBool("isAttacking", state);
    //}

    //public void setIsWalking(bool state)
    //{
    //    clownAnimator.SetBool("isWalking", state);
    //}
}

