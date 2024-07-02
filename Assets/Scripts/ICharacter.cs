using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICharacter
{
    float TotalDmg { get; }

    void ReceiveDmg(float damage);

    T Get<T>(Attribute attribute) where T : Wrapper;
}
