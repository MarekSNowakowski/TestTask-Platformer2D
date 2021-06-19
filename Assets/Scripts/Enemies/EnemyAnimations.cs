using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimations : MonoBehaviour
{
    private Animator animator;

    private readonly string DIEING_ANIMATOR_PARAMETER = "dieing";
    private readonly string DAMAGED_ANIMATOR_PARAMETER = "damaged";
    private readonly string STATIONARY_ANIMATOR_PARAMETER = "stationary";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDieingAnimationTrue()
    {
        animator.SetBool(DIEING_ANIMATOR_PARAMETER, true);
    }

    public void SetDieingAnimationFalse()
    {
        animator.SetBool(DIEING_ANIMATOR_PARAMETER, false);
    }

    public void SetDamagedAnimationTrue()
    {
        animator.SetBool(DAMAGED_ANIMATOR_PARAMETER, true);
    }

    internal void SetStationary()
    {
        animator.SetBool(STATIONARY_ANIMATOR_PARAMETER, true);
    }

    public void SetDamagedAnimationFalse()
    {
        animator.SetBool(DAMAGED_ANIMATOR_PARAMETER, false);
    }
}
