using UnityEngine;

[CreateAssetMenu(menuName ="Bullet")]
public class BulletType : ScriptableObject
{
    public int damage;
    public int speed;
    public float fireRate;
    public string bulletName;
    public int areaOfEffect;
    public Sprite projectileImage;
}
