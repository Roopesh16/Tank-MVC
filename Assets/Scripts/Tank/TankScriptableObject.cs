using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "Tank/TankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankTypes tankType;
    public float movementSpeed;
    public float rotationSpeed;
    public Material tankColor;
}
