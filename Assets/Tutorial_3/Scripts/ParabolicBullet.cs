using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicBullet : MonoBehaviour {

    private Vector2 wind;
    private float speed;
    private float gravity;
    private Vector3 startPosition;
    private Vector3 startForward;

    private bool isInitialized = false;

    private float startTime = -1;

    public void Initialize(Transform startPoint, float speed, float gravity, Vector2 wind)
    {
        this.startPosition = startPoint.position;
        this.startForward = startPoint.forward.normalized;
        this.speed = speed;
        this.gravity = gravity;
        this.wind = wind;
        isInitialized = true;
        startTime = -1f;
    }

    private Vector3 FindPointOnParabola(float time)
    {
        Vector3 movementVec = (startForward * time * speed);
        Vector3 windVec = new Vector3(wind.x, 0, wind.y) * time * time;
        Vector3 gravityVec = Vector3.down * time * time * gravity;
        return startPosition + movementVec + gravityVec + windVec;
    }

    private bool CastRayBetweenPoints(Vector3 startPoint, Vector3 endPoint, out RaycastHit hit)
    {
        Debug.DrawRay(startPoint, endPoint - startPoint, Color.green, 5);
        return Physics.Raycast(startPoint, endPoint - startPoint, out hit, (endPoint - startPoint).magnitude);
    }

    private void OnHit(RaycastHit hit)
    {
        ShootableObject shootableObject = hit.transform.GetComponent<ShootableObject>();
        if (shootableObject)
        {
            shootableObject.OnHit(hit);
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (!isInitialized) return;
        if (startTime < 0) startTime = Time.time;

        float currentTime = Time.time - startTime;
        float prevTime = currentTime - Time.fixedDeltaTime;
        float nextTime = currentTime + Time.fixedDeltaTime;

        RaycastHit hit;
        Vector3 currentPoint = FindPointOnParabola(currentTime);

        if (prevTime > 0)
        {
            Vector3 prevPoint = FindPointOnParabola(prevTime);
            if (CastRayBetweenPoints(prevPoint, currentPoint, out hit))
            {
                OnHit(hit);
            }
        }

        Vector3 nextPoint = FindPointOnParabola(nextTime);
        if (CastRayBetweenPoints(currentPoint, nextPoint, out hit))
        {
            OnHit(hit);
        }
    }

    void Update ()
    {
        if (!isInitialized || startTime < 0) return;

        float currentTime = Time.time - startTime;
        Vector3 currentPoint = FindPointOnParabola(currentTime);
        transform.position = currentPoint;
    }
}
