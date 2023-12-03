using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    private int Health = 5;
    private bool hasToCrumble = false;


    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void Hit()
    {
        if (!hasToCrumble)
        {
            Health = Health - 1;

            if (Health == 0)
            {
                hasToCrumble = true;
                Animator.SetBool("hasToExplode", true);
            }
        }
    }
}
