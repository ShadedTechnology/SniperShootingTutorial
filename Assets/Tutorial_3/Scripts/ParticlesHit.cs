using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesHit : ShootableObject
{
    public GameObject particlesPrefab;
    public float particleLifetime = 2f;

    public override void OnHit(ref HitInfo hitInfo)
    {
        GameObject instantiatedParticles = (GameObject)Instantiate(particlesPrefab, hitInfo.hit.point + hitInfo.hit.normal * 0.05f,
                                                                   Quaternion.LookRotation(hitInfo.hit.normal),
                                                                   transform.root.parent);
        instantiatedParticles.GetComponent<ParticleSystem>().startColor = GetComponent<Renderer>().material.color;
        Destroy(instantiatedParticles, particleLifetime);
    }
}
