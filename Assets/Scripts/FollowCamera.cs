using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform cameraTransform;
    
    public float distanceFromCamera;

    private GameObject wayPoint;
    private Vector3 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 0.6f;

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

        }
        
    }
}
