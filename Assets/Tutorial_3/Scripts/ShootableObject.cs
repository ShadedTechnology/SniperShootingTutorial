using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObject : MonoBehaviour {

    public abstract void OnHit(ref HitInfo hitInfo);
}
