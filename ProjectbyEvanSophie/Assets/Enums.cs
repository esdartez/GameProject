using UnityEngine;
[CreateAssetMenu(fileName = "Enums", menuName = "ScriptableObjects/Enums")]
public class Enums : ScriptableObject {
    public override string ToString()
    {
        return name;
    }
}