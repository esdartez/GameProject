using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] CapsuleCollider _collider;
    
    public void Activate()
    {
        _collider.enabled = true;
    }

    public void Deactivate()
    {
        _collider.enabled = false;
    }

    //ICharacter is an interface that all game character inherit from
    [SerializeField] ICharacter owner;
    private void OnValidate()
    {
        //We get a reference to the ICharacter by checking the parent GameObjects
        owner = GetComponentInParent<ICharacter>();
        Debug.Log("Owner set");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered collider");
        var character = other.GetComponent<ICharacter>();
        //Avoid attacking yourself
        if (character == owner)
        {
            Debug.Log("Hit character == owner");
            return;
        }
        if (character != null)
        {
            Debug.Log("Hit character != null");
            character.ReceiveDmg(owner.TotalDmg);
            Debug.Log("Weapon being deactivated");
            //Deactivate the weapon to prevent damaging multiple times with one swing.
            Deactivate();
        }
    }
}