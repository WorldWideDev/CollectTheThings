using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    AudioSource source;

    public AudioClip clip;

    void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log(clip.length);
            source.PlayOneShot(clip);
        }
    }

}
