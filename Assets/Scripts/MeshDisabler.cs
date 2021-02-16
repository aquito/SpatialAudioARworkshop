using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDisabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }
}
