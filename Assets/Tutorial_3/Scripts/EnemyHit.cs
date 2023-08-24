using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : ShootableObject
{
    public EnemyRagdoll enemyRagdoll;
    public GameObject particlesPrefab;
    public float impactForce = 1;
    public bool destroyBullet = true;

    public override void OnHit(ref HitInfo hitInfo)
    {
        GameObject instantiatedParticles = (GameObject)Instantiate(particlesPrefab, hitInfo.hit.point + hitInfo.hit.normal * 0.05f,
                                                                   Quaternion.LookRotation(hitInfo.hit.normal),
                                                                   transform.root.parent);
        instantiatedParticles.GetComponent<ParticleSystem>().startColor = Color.red;
        GetComponent<Rigidbody>().AddForceAtPosition(hitInfo.hitDirection * hitInfo.hitSpeed * impactForce, hitInfo.hit.point);
        Destroy(instantiatedParticles, 2f);
        enemyRagdoll.EnableRagdoll();
        hitInfo.destroyBullet = destroyBullet;
    }
}
