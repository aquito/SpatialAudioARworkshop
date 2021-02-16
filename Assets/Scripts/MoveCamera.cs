using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public GameObject wayPoint;
    //This is how often your waypoint's position will update to the player's position
    private float timer = 0.5f;
    Transform tr;
    Vector3 turnLeft;
    Vector3 turnRight;
    Vector3 turnUp;
    Vector3 turnDown;

    private void Start()
    {
        tr = GetComponent<Transform>();
        turnLeft = new Vector3(0, -1, 0);
        turnRight = new Vector3(0, 1, 0);
        turnUp = new Vector3(1, 0, 0);
        turnDown = new Vector3(-1, 0, 0);

    }

    private void Update()
    {
        

        if (Input.GetKey(KeyCode.A))
            tr.Translate(Vector3.left * Time.deltaTime);
            //rb.AddForce(Vector3.left * 0.1f);
        if (Input.GetKey(KeyCode.D))
            tr.Translate(Vector3.right * Time.deltaTime);
        // rb.AddForce(Vector3.right * 0.1f);
        if (Input.GetKey(KeyCode.W))
            tr.Translate(Vector3.forward * Time.deltaTime);
        // rb.AddForce(Vector3.forward * 0.1f);
        if (Input.GetKey(KeyCode.S))
            tr.Translate(Vector3.back * Time.deltaTime);
        // rb.AddForce(Vector3.back * 0.1f);
        if (Input.GetKey(KeyCode.RightArrow))
            tr.Rotate(turnRight);
        if (Input.GetKey(KeyCode.LeftArrow))
            tr.Rotate(turnLeft);

        if (Input.GetKey(KeyCode.UpArrow))
            tr.Rotate(turnUp);

        if (Input.GetKey(KeyCode.DownArrow))
            tr.Rotate(turnDown);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            //The position of the waypoint will update to the player's position
            UpdatePosition();
            timer = 0.5f;
        }
    }

    void UpdatePosition()
    {
        //The wayPoint's position will now be the player's current position.
        wayPoint.transform.position = transform.position;
    }
}
