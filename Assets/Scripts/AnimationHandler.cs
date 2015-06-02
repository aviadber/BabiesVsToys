using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator;
    public bool isAttacking;
    public bool isWalking;
    public bool isWalkingGun;
    // Use this for initialization
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void setWalking(bool state)
    {
        isWalking = state;

        animator.SetBool("isWalking", isWalking);
    }

    public void setWalkingGun(bool state)
    {
        isWalkingGun = state;

        animator.SetBool("isWalkingGun", isWalkingGun);
    }

    public void setAttacking(bool state)
    {
        isAttacking = state;
        animator.SetBool("isAttacking", isAttacking);
    }
}