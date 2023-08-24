using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyManager : MonoBehaviour
{
    public EnemyHit[] enemyComponents;

    public EnemyRagdoll enemyRagdoll;
    public GameObject particlesPrefab;
    public float impactForce = 1;
    public bool destroyBullet = true;

    void SetEnemyParams()
    {
        foreach(EnemyHit enemyComponent in enemyComponents)
        {
            enemyComponent.enemyRagdoll = enemyRagdoll;
            enemyComponent.particlesPrefab = particlesPrefab;
            enemyComponent.impactForce = impactForce;
            enemyComponent.destroyBullet = destroyBullet;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyComponents = transform.GetComponentsInChildren<EnemyHit>();
        SetEnemyParams();
    }

#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        SetEnemyParams();
    }
#endif

}
