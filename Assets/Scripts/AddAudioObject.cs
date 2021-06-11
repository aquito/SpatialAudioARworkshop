using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAudioObject : MonoBehaviour
{
    public GameObject audioObject;

    public AudioClip yourAudio;

    public float lifeTime;

    public float triggerTime;

    public bool isInstantiated;

    private AudioSource audioSource;

    private AudioClip audioClip;

    private void Start()
    {
        if (audioObject != null)
        {
            audioSource = audioObject.GetComponent<AudioSource>();
            audioClip = audioSource.GetComponent<AudioClip>();

            audioClip = yourAudio;

            var sphereMesh = gameObject.GetComponentInChildren<MeshRenderer>();

            //print(audioObject.name);
            sphereMesh.enabled = false;
        }
        else
        {
            var obj = GetComponent<GameObject>();
            UnityEngine.Assertions.Assert.IsNotNull<GameObject>(audioObject, audioObject.name + " is missing for " + obj.name);
        }

        if (lifeTime == 0f)
        {
            lifeTime = 10.0f;
        }

        if (triggerTime == 0f)
        {
            triggerTime = 1.0f;
        }

    }

}
