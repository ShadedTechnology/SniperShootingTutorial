using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalHit : ShootableObject
{
    public GameObject decalObject;
    public float maxScale = 2f;
    public float minScale = 1f;
    public float lifeTime = 5f;

    public override void OnHit(ref HitInfo hitInfo)
    {
        GameObject instantiatedDecal = (GameObject)Instantiate(decalObject, hitInfo.hit.point + hitInfo.hit.normal * 0.01f,
                           Quaternion.LookRotation(hitInfo.hit.normal, Quaternion.LookRotation(hitInfo.hit.normal) * Random.insideUnitCircle),
                           transform.root.parent);
        instantiatedDecal.transform.localScale *= Random.Range(minScale, maxScale);
        Destroy(instantiatedDecal, lifeTime);
    }
}
