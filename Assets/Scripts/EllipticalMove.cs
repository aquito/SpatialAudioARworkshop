using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipticalMove : MonoBehaviour
{
    public float a = 215; //a is in AU, Semimajor Axis
    private float angle; // angle theta
    float speed = (2 * Mathf.PI) / 10;
    float x;
    float y;
    float e = 0.9f; // Eccentricity
                    // Update is called once per frame
    void Update()
    {
        float b = Mathf.Sqrt(Mathf.Pow(a, 2) * (1 - Mathf.Pow(e, 2))); // Finding the Semiminor Axis (sqrt);
        var audioObject = gameObject.GetComponent<Transform>(); ;
        angle += speed * Time.deltaTime;
        x = Mathf.Cos(angle) * a; // a is the Radius in the x direction
        y = Mathf.Sin(angle) * b; // b is the  Radius in the y direction
        audioObject.position = new Vector3(x, 0, y);


    }
}
