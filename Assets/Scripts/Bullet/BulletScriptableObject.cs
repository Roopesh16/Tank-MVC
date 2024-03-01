using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "BulletScriptableObject", order = 0)]
public class BulletScriptableObject : ScriptableObject
{
    public float bulletSpeed;
    public BulletType bulletType;
    public Material bulletColor;
    public float damageRadius;
    public float firingRate;
}