using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimationScript : MonoBehaviour
{
    public Animator[] barAnims;
    private void OnEnable()
    {
        PlayerScript.NextRival += Animate;
    }


    private void OnDisable()
    {
        PlayerScript.NextRival -= Animate;
    }

    private void Start()
    {
        Animate();
    }

    public void Animate()
    {
        foreach (Animator barAnim in barAnims)
        {
            barAnim.SetTrigger("Animate");
        }
    }

    
}
