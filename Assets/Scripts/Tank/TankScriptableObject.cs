using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "Tank/TankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankTypes tankType;
    public float movement;
    public float rotation;
    public Material tankColor;
}
