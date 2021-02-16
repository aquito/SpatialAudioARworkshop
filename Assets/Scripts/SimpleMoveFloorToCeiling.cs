using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveFloorToCeiling : MonoBehaviour
{
    private Transform objTransform;
    private Vector3 movementVector = Vector3.up;
    private Vector3 movementVectorReverse = Vector3.down;
    public bool reverse;

    void Start()
    {
        objTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!reverse)
        {
            objTransform.Translate(movementVector * Time.deltaTime * 0.3f);
        }
        else
        {
            objTransform.Translate(movementVectorReverse * Time.deltaTime * 0.3f);
        }

    }
}
