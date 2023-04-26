using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInRange : MonoBehaviour
{
    Transform objectToDetect;
    public float detectionRange = 5;
    public bool hasDetected;

    private void Start()
    {
        objectToDetect = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    void Update()
    {
        if (objectToDetect != null)
        {
            if (Vector2.Distance(transform.position, objectToDetect.position) <= detectionRange)
            {
                if (!hasDetected)
                {
                    hasDetected = true;
                    OnObjectDetected();
                }
            }
            else
            {
                if (hasDetected)
                {
                    hasDetected = false;
                    OnObjectLost();
                }
            }
        }
    }

    void OnObjectDetected()
    {
        GetComponent<FollowPath>().enabled = false;
        GetComponent<MoveTowardsObject>().enabled = true;
    }

    void OnObjectLost()
    {
        GetComponent<FollowPath>().enabled = true;
        GetComponent<MoveTowardsObject>().enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
