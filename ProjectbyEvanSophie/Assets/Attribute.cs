using UnityEngine;
[CreateAssetMenu(fileName = "Attribute", menuName = "ScriptableObjects/Attribute", order = 2)]
public class Attribute : ScriptableObject
{
    public override string ToString()
    {
        return name;
    }
}
