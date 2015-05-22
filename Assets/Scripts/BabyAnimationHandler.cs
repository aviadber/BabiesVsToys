using UnityEngine;

public class BabyAnimationHandler : MonoBehaviour
{
    public Animator babyAnimator;
    public bool isAttacking;
    public bool isWalking;
    public bool isWalkingGun;
    // Use this for initialization
    private void Start()
    {
        babyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void setWalking(bool state)
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