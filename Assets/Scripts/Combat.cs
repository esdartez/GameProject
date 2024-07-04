using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Combat : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Weapon weapon;
    [SerializeField] ThirdPersonController controller;

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<ThirdPersonController>();
    }

    //Should not attack if already attacking
    bool attacking;
    bool Attacking
    {
        set
        {
            attacking = value;
            //Disable the controller so the character does not move while attacking
            controller.enabled = !value;
        }
    }

    //This function is called when the player presses LMB
    public void Attack()
    {
        Debug.Log("Attack was called");
        if (attacking)
            return;
       
        weapon = GetComponentInChildren<Weapon>();
        animator.SetTrigger("Attack");
    }

    //An animation event raised when the sword can damage others
    public void Draw()
    {
        Attacking = true;
        weapon.Activate();
    }

    //An animation event raised when attack animation is done
    public void Sheathe()
    {
        weapon.Deactivate();
        Attacking = false;
        animator.ResetTrigger("Attack");
    }
}

//new testing comment