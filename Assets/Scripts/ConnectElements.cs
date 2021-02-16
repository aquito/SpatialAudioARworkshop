using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectElements : MonoBehaviour
{
    //private List<GameObject> elements;

    private GameObject[] elements = new GameObject[10];

    private int lengthOfLineRenderer = 2;

    private void Awake()
    {
        elements = GameObject.FindGameObjectsWithTag("element");
        

        if (elements.Length > 0)
        {
            LineRenderer lineRenderer = elements[0].AddComponent<LineRenderer>();

            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.widthMultiplier = 0.2f;

            Vector3[] points;
            points = new Vector3[elements.Length];

            for (int i = 0; i < elements.Length; i++)
            {
                points[i] = elements[i].transform.position;
                Debug.Log(elements[i]);
                Debug.Log(points[i]);
            }

            lineRenderer.SetPositions(points);
        }

    }

}
