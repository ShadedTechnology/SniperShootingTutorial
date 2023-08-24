using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetHit : ShootableObject
{
    public float minSpeed = 10f;
    public float maxAngle = 45f;
    public float absorptionMultiplier = 800f;
    public AnimationCurve absorptionCurve;

    public override void OnHit(ref HitInfo hitInfo)
    {
        float angle = 90f - Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(hitInfo.hit.normal, -hitInfo.hitDirection));
        float speedAbsorption = absorptionCurve.Evaluate(Mathf.Lerp(0, 1, angle / maxAngle)) * absorptionMultiplier;
        float speed = hitInfo.hitSpeed - speedAbsorption;
        if (angle < 0 || angle >= maxAngle || speed < minSpeed)
        {
            hitInfo.destroyBullet = true;
            return;
        }
        Vector3 startPos = hitInfo.hit.point + hitInfo.hit.normal * 0.001f;
        Vector3 startForward = Vector3.Reflect(hitInfo.hitDirection, hitInfo.hit.normal);
        hitInfo.bullet.Reinitialize(startPos, startForward, speed);
    }
}
