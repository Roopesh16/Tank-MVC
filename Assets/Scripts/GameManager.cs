using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private int bulletDamage;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void SetBulletDamage(int bulletDamage)
    {
        this.bulletDamage = bulletDamage;
    }

    public int GetBulletDamage()
    {
        return bulletDamage;
    }
}
