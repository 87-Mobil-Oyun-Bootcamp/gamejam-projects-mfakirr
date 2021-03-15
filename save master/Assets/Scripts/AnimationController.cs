using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    static int SPEED_HASH = Animator.StringToHash("Speed");
    static int DIE_HASH = Animator.StringToHash("Die");
    static int UP_HASH = Animator.StringToHash("GetUp");
    Animator animator;
    
    // Start is called before the first frame update
    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetSpeed(float speed)
    {
        animator.SetFloat(SPEED_HASH, speed);
    }
    public void SetDie(bool die)
    {
        animator.SetBool(DIE_HASH, die);
    }
    public void GetUp(bool up)
    {
        animator.SetBool(UP_HASH, up);
    }
    public void ResetGetUp()
    {
        animator.SetBool(UP_HASH, false);
        animator.SetBool(DIE_HASH, false);
    }
}


