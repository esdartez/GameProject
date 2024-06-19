using UnityEngine;

[CreateAssetMenu(fileName = "NewCustomObject", menuName = "CustomObjects/New Custom Object")]
public class CustomObject : ScriptableObject
{
    // Define fields and properties for your custom object here
    public string objectName;
    public int objectValue;
}