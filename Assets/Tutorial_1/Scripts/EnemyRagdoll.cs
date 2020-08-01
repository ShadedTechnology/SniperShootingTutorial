using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour {

    private Rigidbody[] rigids;
    private Animator anim;

    void Start()
    {
        rigids = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();

        DisableRagdoll();
    }

    public void EnableRagdoll()
    {
        anim.enabled = false;
        foreach (Rigidbody rig in rigids)
        {
            rig.useGravity = true;
        }
    }

    public void DisableRagdoll()
    {
        anim.enabled = true;
        foreach (Rigidbody rig in rigids)
        {
            rig.useGravity = false;
        }
    }
}
