using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalAnimator : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
    public void Death()
    {
        anim.SetTrigger("Death");
    }
}
