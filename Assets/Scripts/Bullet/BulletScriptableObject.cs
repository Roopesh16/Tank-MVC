using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "Bullets/BulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject
{
    public float bulletSpeed;
    public BulletType bulletType;
    public Material bulletColor;
    public float blastRadius;
    public float firingRate;
}