using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAway : MonoBehaviour
{
    private Transform cameraTransform;

    public float distanceFromCamera;

    private GameObject wayPoint;
    private Vector3 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed;

    private void Start()
    {
        GameObject camera = GameObject.Find("AR Camera");
        cameraTransform = camera.GetComponent<Transform>();
        wayPoint = GameObject.Find("waypoint");

    }

    void Update()
    {
        if (cameraTransform != null)
        {

            wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
            //Here, the zombie's will follow the waypoint.
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);

            float distance = Vector3.Distance(transform.position, wayPointPos);
            //Debug.Log(distance);

            if (distance > 2.0f)
            {
                speed = 0.1f;
            } else
            {
                speed = -0.5f;
            }
        }

    }
}
