using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : ShootableObject
{
    public EnemyRagdoll enemyRagdoll;
    public GameObject particlesPrefab;
    public float impactForce = 1000;

    public override void OnHit(RaycastHit hit)
    {
        GameObject instantiatedParticles = (GameObject)Instantiate(particlesPrefab, hit.point + hit.normal * 0.05f,
                                                                   Quaternion.LookRotation(hit.normal),
                                                                   transform.root.parent);
        instantiatedParticles.GetComponent<ParticleSystem>().startColor = Color.red;
        GetComponent<Rigidbody>().AddForceAtPosition(transform.forward * impactForce, hit.point);
        Destroy(instantiatedParticles, 2f);
        enemyRagdoll.EnableRagdoll();
    }
}
