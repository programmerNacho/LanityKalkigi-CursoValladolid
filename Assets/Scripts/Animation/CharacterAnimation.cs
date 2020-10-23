using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

   public void SetMoving(bool value)
    {
        //bool value;
        animator.SetBool("Moving", value);
    }

    public void SetPainting(bool value)
    {
        animator.SetBool("Painting", value);
    }

    public void SetAttack(bool value)
    {
        animator.SetBool("Attack", value);
    }

    public void SetIdle(bool value)
    {
        animator.SetBool("Idle", value);
    }
}
