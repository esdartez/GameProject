using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wrapper
{
    [SerializeField] protected Attribute attribute;
    public Attribute Attribute => attribute;
    [SerializeField] protected float amount;
    public float Amount => amount;

}
