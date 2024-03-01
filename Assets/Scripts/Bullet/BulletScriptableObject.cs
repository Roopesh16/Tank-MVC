using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "Bullets/BulletScriptableObject", order = 0)]
public class BulletScriptableObject : ScriptableObject
{
    public float bulletSpeed;
    public BulletType bulletType;
    public Material bulletColor;
    public float damageRadius;
    public float firingRate;
}

[CreateAssetMenu(fileName ="BulletSOList", menuName ="Bullets/BulletSOList")]
public class BulletSOList:ScriptableObject
{
    public BulletScriptableObject[] bullets = new BulletScriptableObject[3];
}