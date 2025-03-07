using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : Plant
{
    public float shooterDuration = 2;
    private float shooterTimer = 0;
    public Transform shootPointTransform;
    public PeaBullet peaBulletPrefab;

    public float bulletSpeed = 5;

    public int atkValue = 20;
    protected override void EnableUpdate()
    {
        shooterTimer += Time.deltaTime;
        if (shooterTimer > shooterDuration) 
        {
            Shoot();
            shooterTimer = 0;
        }
    }

    void Shoot() 
    {
        AudioManager.Instance.PlayClip(Config.shoot,0.3f);
        PeaBullet pb= GameObject.Instantiate(peaBulletPrefab, shootPointTransform.position,Quaternion.identity);
        pb.SetSpeed(bulletSpeed);
        pb.SetATKValue(atkValue);
    }
}
