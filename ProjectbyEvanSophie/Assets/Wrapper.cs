using UnityEngine;
public abstract class Wrapper
{
    [SerializeField] protected Attribute attribute;
    public Attribute Attribute => attribute;
    [SerializeField] protected float amount;
    public float Amount => amount;

}