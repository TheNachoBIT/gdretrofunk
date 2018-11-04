using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public bool ifIsPlayer;
    public Vector3 offset;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        if (ifIsPlayer)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        targetPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {
            if (Time.timeScale != 0)
            {
                Vector3 posNoZ = transform.position;
                posNoZ.z = target.transform.position.z;

                Vector3 targetDirection = (target.transform.position - posNoZ);

                interpVelocity = targetDirection.magnitude * 5f;

                targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

                transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
            }

        }
    }
}
