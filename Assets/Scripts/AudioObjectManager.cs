using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]

public class AudioObjectManager : MonoBehaviour
{
    private ARPlaneManager m_ARPlaneManager;
    private ARRaycastManager m_RaycastManager;

    static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

    private bool audioInitiated = false;
    private bool _planesFound;
    private int _objPlacedIndex;
    private List<GameObject> audioElements = new List<GameObject>();
    private List<GameObject> audioObjectsInTheScene = new List<GameObject>();
    public List<GameObject> elements;

    private AudioSource audioSource;
    private float[] startTime;

    //private AddAudioObject addAudioObject;

    // Start is called before the first frame update
    private void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_ARPlaneManager = GetComponent<ARPlaneManager>();

    }

    private void Start()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            var audioObject = elements[i].GetComponent<AddAudioObject>().audioObject;
           // print(audioObject.name);
            var audioClip = elements[i].GetComponent<AddAudioObject>().yourAudio;

            audioElements.Add(audioObject);
            audioObject.GetComponent<AudioSource>().clip = audioClip;

        }

        startTime = new float[elements.Count];
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!_planesFound)
        {
            ScanPlanes();
        }
        else
        {
            PlaceObject();
        }

        if (Input.GetKeyDown("space") && !audioInitiated)
        {
            InitiateAudioElements();
        }

        if (Input.GetKeyDown(KeyCode.RightShift) && audioInitiated)
        {
            ActivateAudioElement();
        }

        

        if (audioObjectsInTheScene.Count != 0)
        {
            for (int i = 0; i < audioObjectsInTheScene.Count; i++)
            {
                startTime[i] = startTime[i] + Time.deltaTime;

                if (startTime[i] > elements[i].GetComponent<AddAudioObject>().lifeTime)
                {
                    if(audioObjectsInTheScene[i])
                    {
                        Debug.Log(audioObjectsInTheScene[i].name + " reached end of its life cycle");
                    }
                        
                    Destroy(audioObjectsInTheScene[i]);
                }
            }


        }

    }

    private void ScanPlanes()
    {
        if (m_ARPlaneManager.trackables.count > 0)
        {
            _planesFound = true;
        }
    }

    private void PlaceObject()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (m_RaycastManager.Raycast(touch.position, s_hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_hits[0].pose;

                    ActivateAudioElement();
                }
            }
        }

    }

    private void ActivateAudioElement()
    {
        if (_objPlacedIndex == audioElements.Count)
        {
            audioSource.Play();
        }   

        if (_objPlacedIndex < audioElements.Count && audioElements[_objPlacedIndex] != null)
        {
            GameObject obj = Instantiate(audioElements[_objPlacedIndex], elements[_objPlacedIndex].GetComponent<Transform>().position, elements[_objPlacedIndex].GetComponent<Transform>().rotation);
            audioObjectsInTheScene.Add(obj);
            startTime[_objPlacedIndex] = 0f;
        }
        else
        {
            HidePlanes();
        }
      
        if (_objPlacedIndex < audioElements.Count)
        {
            _objPlacedIndex++;
        }
            


        
    }

    private void InitiateAudioElements()
    {
        audioInitiated = true;
        Debug.Log("audio initiated");
    }

    private void HidePlanes()
    {
        foreach (var plane in m_ARPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }

    void OnApplicationQuit()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            var audioObject = elements[i].GetComponent<AddAudioObject>().audioObject;

            //audioObject.SetActive(true);
            //audioObject.GetComponent<AudioSource>().enabled = true;
            audioObject.GetComponent<AudioSource>().clip = null;

        }
    }
}
