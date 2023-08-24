using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : ShootableObject
{
    public float speedAbsorption = 200f;
    public bool alwaysDestroyBullet = true;

    public override void OnHit(ref HitInfo hitInfo)
    {
        float newSpeed = hitInfo.hitSpeed - speedAbsorption;
        if (alwaysDestroyBullet || newSpeed <= 0)
        {
            hitInfo.destroyBullet = true;
            return;
        }
        const float offset = 0.01f;
        Vector3 startPos = hitInfo.hit.point + hitInfo.hitDirection * offset;
        hitInfo.bullet.Reinitialize(startPos, hitInfo.hitDirection, newSpeed);
    }
}
